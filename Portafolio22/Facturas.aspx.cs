using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio22
{
    public partial class Facturas : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarFacturas();
        }
        private void cargarFacturas()
        {
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();
            var consulta = from factura in dataContext.ENCABEZADO_FACTURA
                           select factura;
            grdFacturas.DataSource = consulta;
            grdFacturas.DataBind();
        }


        private void cargarDetalle(int id)
        {
            BD_PracticaLinQDataContext dataContext = new BD_PracticaLinQDataContext();
            var consulta = from detalle in dataContext.DETALLE_FACTURA
                           where detalle.ID_FACTURA == id
                           select detalle;
            grdDetalle.DataSource = consulta;
            grdDetalle.DataBind();
        }

        protected void lnkDetalle_Command(object sender, CommandEventArgs e)
        {
            int id = -1;
            id = Convert.ToInt32(e.CommandArgument.ToString());
            cargarDetalle(id);
            grdDetalle.Visible = true;
            btnCancelar.Visible = true;
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            grdDetalle.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}