using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class modCliente : System.Web.UI.Page
    {
        string mensajeScript;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();
            try
            {
                if (!Page.IsPostBack)
                {
                    id = int.Parse(Session["id_cliente"].ToString());

                    var query = (from cliente in dataContext.CLIENTES
                                    where cliente.ID_CLIENTE == id
                                    select new
                                    {
                                        ID_CLIENTE = cliente.ID_CLIENTE,
                                        NOMBRE = cliente.NOMBRE,
                                        TELEFONO = cliente.TELEFONO,
                                        DIRECCION = cliente.DIRECCION
                                    }).FirstOrDefault();

                    if (query.ID_CLIENTE > 0)
                    {
                        txtId.Text = query.ID_CLIENTE.ToString();
                        txtNombre.Text = query.NOMBRE;
                        txtTelefono.Text = query.TELEFONO;
                        txtDireccion.Text = query.DIRECCION;
                    }
                    else
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Cliente no encontrado')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }

            
        }

        private CLIENTES GenerarEntidadCliente()
        {
            CLIENTES cliente = new CLIENTES();

            if(Session["id_cliente"]!= null)
            {
                cliente.ID_CLIENTE = int.Parse(Session["id_cliente"].ToString());
            }
            else
            {
                cliente.ID_CLIENTE = -1;
            }

            cliente.NOMBRE = txtNombre.Text;
            cliente.TELEFONO = txtTelefono.Text;
            cliente.DIRECCION = txtDireccion.Text;

            return cliente;
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            CLIENTES cliente;
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();
            try
            {
                cliente = GenerarEntidadCliente();
                if(cliente.ID_CLIENTE > 0)
                {
                    var query = (from q_clientes in dataContext.CLIENTES
                                 where q_clientes.ID_CLIENTE == cliente.ID_CLIENTE
                                 select q_clientes).FirstOrDefault();

                    query.ID_CLIENTE = cliente.ID_CLIENTE;
                    query.NOMBRE = cliente.NOMBRE;
                    query.TELEFONO = cliente.TELEFONO;
                    query.DIRECCION = cliente.DIRECCION;

                    dataContext.SubmitChanges();
                    mensajeScript = string.Format("javascript:mostrarMensaje('Datos Guardados')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Clientes.aspx");
                }
                else
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('No se encontro cliente')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }
    }
}