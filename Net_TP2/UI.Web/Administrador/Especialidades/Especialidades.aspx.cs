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
    public partial class Especialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                Usuario usu = (Usuario)Session["Usuario"];
                dgvEspecialidades.DataSource = new EspecialidadLogic().DameEspecialidades();
                dgvEspecialidades.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaEspecialidad.aspx");
        }

        protected void dgvEspecialidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnBaja")
            {
                dgvEspecialidades.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvEspecialidades.SelectedRow;
                string id = row.Cells[0].Text;
                EspecialidadLogic el = new EspecialidadLogic();
                el.Delete(Convert.ToInt32(id));
            }

            if (e.CommandName == "btnModificar")
            {
                dgvEspecialidades.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvEspecialidades.SelectedRow;
                string id = row.Cells[0].Text;
                Response.Redirect("ModificarEspecialidad.aspx?id=" + id);
            }
        }
    }
}