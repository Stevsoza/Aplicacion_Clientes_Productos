using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class PracticaLinQ : System.Web.UI.Page
    {

        string mensajeScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void cargarClientes()
        {
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();
            var consulta = from cliente in dataContext.CLIENTES
                           select cliente;
            grdClientes.DataSource = consulta;
            grdClientes.DataBind();
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["id_cliente"] = e.CommandArgument.ToString();
            Response.Redirect("modCliente.aspx");
        }

        protected void lnkEliminar_Command1(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();

            //booleano revisa consulta si es mayor a 0
            //significa que hay clientes con facturas
            bool clienteConFactura = (from cliente in dataContext.CLIENTES
                                      join facturas in dataContext.ENCABEZADO_FACTURA on
                                      cliente.ID_CLIENTE equals facturas.ID_CLIENTE
                                      where cliente.ID_CLIENTE == id
                                      select cliente).Count() > 0;

            if (!clienteConFactura)
            {
                var query = from cliente in dataContext.CLIENTES
                            where cliente.ID_CLIENTE == id
                            select cliente;

                dataContext.CLIENTES.DeleteAllOnSubmit(query);
                dataContext.SubmitChanges();
                mensajeScript = string.Format("javascript:mostrarMensaje('Cliente eliminado')");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
            else
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('El Cliente tiene facturas')");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }

            cargarClientes();
        }
    }
}