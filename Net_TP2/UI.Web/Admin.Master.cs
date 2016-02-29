using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }         
  
            Usuario usu = (Usuario)Session["Usuario"];
            this.Master.Bienvenido = usu.Nombre;
            
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();            
            HttpContext.Current.Response.Redirect("../Login.aspx", true); 
        }
        
    }
}