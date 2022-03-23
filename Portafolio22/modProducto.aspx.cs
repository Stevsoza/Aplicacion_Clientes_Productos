using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class modProducto : System.Web.UI.Page
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
                    id = int.Parse(Session["id_producto"].ToString());

                    var query = (from producto in dataContext.PRODUCTOS
                                 where producto.ID_PRODUCTO== id
                                 select new
                                 {
                                     ID_PRODUCTO= producto.ID_PRODUCTO,
                                     DESCRIPCION = producto.DESCRIPCION,
                                     PRECIOCOMPRA = producto.PRECIOCOMPRA,
                                     PRECIOVENTA = producto.PRECIOVENTA,
                                     GRAVADO = producto.GRAVADO
                                 }).FirstOrDefault();

                    if (query.ID_PRODUCTO > 0)
                    {
                        txtId.Text = query.ID_PRODUCTO.ToString();
                        txtDescripcion.Text = query.DESCRIPCION;
                        txtPrecioCompra.Text = query.PRECIOCOMPRA.ToString();
                        txtPrecioVenta.Text = query.PRECIOVENTA.ToString();
                        txtGravado.Text = query.GRAVADO.ToString();
                    }
                    else
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Producto no encontrado')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private PRODUCTOS GenerarEntidadProducto()
        {
            PRODUCTOS producto= new PRODUCTOS();

            if (Session["id_producto"] != null)
            {
                producto.ID_PRODUCTO = int.Parse(Session["id_producto"].ToString());
            }
            else
            {
                producto.ID_PRODUCTO = -1;
            }

            producto.DESCRIPCION = txtDescripcion.Text;
            producto.PRECIOCOMPRA = Convert.ToDecimal(txtPrecioCompra.Text);
            producto.PRECIOVENTA = Convert.ToDecimal(txtPrecioVenta.Text);
            producto.GRAVADO = Convert.ToChar(txtGravado.Text);

            return producto;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            PRODUCTOS producto;
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();
            try
            {
                producto = GenerarEntidadProducto();
                if (producto.ID_PRODUCTO > 0)
                {
                    var query = (from q_productos in dataContext.PRODUCTOS
                                 where q_productos.ID_PRODUCTO == producto.ID_PRODUCTO
                                 select q_productos).FirstOrDefault();

                    query.ID_PRODUCTO = producto.ID_PRODUCTO;
                    query.DESCRIPCION = producto.DESCRIPCION;
                    query.PRECIOVENTA = producto.PRECIOVENTA;
                    query.PRECIOCOMPRA = producto.PRECIOCOMPRA;
                    query.GRAVADO = producto.GRAVADO;

                    dataContext.SubmitChanges();
                    mensajeScript = string.Format("javascript:mostrarMensaje('Datos Guardados')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Productos.aspx");
                }
                else
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('No se encontro producto')");
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
            Response.Redirect("Productos.aspx");
        }
    }
}