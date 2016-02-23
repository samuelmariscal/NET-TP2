using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Administrador
{
    public partial class Usuarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];
            dgvUsuarios.DataSource = new UsuarioLogic().GetAll();
            dgvUsuarios.DataBind();
            
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaUsuario.aspx");
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        protected void dgvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnBaja")
            {

                dgvUsuarios.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvUsuarios.SelectedRow;
                string id = row.Cells[0].Text;
                UsuarioLogic ul = new UsuarioLogic();
                ul.Delete(Convert.ToInt32(id));
            }

            if (e.CommandName == "btnModificar")
            {
                dgvUsuarios.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvUsuarios.SelectedRow;
                string id = row.Cells[0].Text;
                Response.Redirect("ModificarUsuario.aspx?id="+id);
            }
        }
        
    }
}