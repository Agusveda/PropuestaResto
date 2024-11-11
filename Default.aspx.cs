using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropuestaResto
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      
        protected void btnMesas_Click(object sender, EventArgs e)
        {

            Response.Redirect("PantallaMesas.aspx", false);

        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {

            Response.Redirect("PantallaAdmin.aspx", false);
        }
    }
}