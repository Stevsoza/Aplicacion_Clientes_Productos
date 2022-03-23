using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class Productos : System.Web.UI.Page
    {
        string mensajeScript = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }
        private void cargarProductos()
        {
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();
            var consulta = from producto in dataContext.PRODUCTOS
                           select producto;
            grdProductos.DataSource = consulta;
            grdProductos.DataBind();
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["id_producto"] = e.CommandArgument.ToString();
            Response.Redirect("modProducto.aspx");
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();

            //booleano revisa consulta si es mayor a 0
            //significa que hay clientes con facturas
            bool productoConFactura = (from producto in dataContext.PRODUCTOS
                                      join detalle in dataContext.DETALLE_FACTURA on
                                      producto.ID_PRODUCTO equals detalle.ID_PRODUCTO
                                      where producto.ID_PRODUCTO == id
                                      select producto).Count() > 0;

            if (!productoConFactura)
            {
                var query = from producto in dataContext.PRODUCTOS
                            where producto.ID_PRODUCTO == id
                            select producto;

                dataContext.PRODUCTOS.DeleteAllOnSubmit(query);
                dataContext.SubmitChanges();
                mensajeScript = string.Format("javascript:mostrarMensaje('Producto eliminado')");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
            else
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('Producto tiene facturas')");
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
            cargarProductos();
        }
    }
}