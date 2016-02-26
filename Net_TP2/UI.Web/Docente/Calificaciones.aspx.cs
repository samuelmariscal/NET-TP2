using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Docente
{
    public partial class Calificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];
            dgvCalificaciones.AutoGenerateColumns = false;
            CursoLogic cl = new CursoLogic();
            dgvCalificaciones.DataSource = cl.DameAlumnosDocente(UsuarioSesion.Sesion.ID);
            dgvCalificaciones.DataBind();
        }

        protected void dgvCalificaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnCalificar")
            {
                dgvCalificaciones.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvCalificaciones.SelectedRow;
                string id = row.Cells[0].Text;
                Response.Redirect("CalificarAlumno.aspx?id=" + id);   
            }
        }
    }
}