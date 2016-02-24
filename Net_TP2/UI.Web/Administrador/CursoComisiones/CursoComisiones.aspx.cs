using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Administrador.CursoComisiones
{
    public partial class CursoComisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                ddlPlanes.DataSource = new PlanLogic().GetAll();
                ddlPlanes.DataTextField = "desc_plan";
                ddlPlanes.DataValueField = "id_plan";
                ddlPlanes.DataBind();
                if (!IsPostBack)
                {
                    if (this.ddlPlanes.SelectedValue != null)
                    {
                        ddlComision.DataSource = new ComisionLogic().DameComisiones(int.Parse(this.ddlPlanes.SelectedValue));
                        ddlComision.DataTextField = "desc_comision";
                        ddlComision.DataValueField = "id_comision";
                        ddlComision.DataBind();
                    }
                }
                Usuario usu = (Usuario)Session["Usuario"];
                dgvCursos.DataSource = new CursoLogic().DameCursos(int.Parse(this.ddlComision.SelectedValue));
                dgvCursos.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            int plan = int.Parse(this.ddlPlanes.SelectedValue);
            int comision = int.Parse(this.ddlComision.SelectedValue);
            Response.Redirect("AltaCurso.aspx?plan="+plan+"&comision="+comision);
        }
        protected void dgvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnBaja")
            {
                dgvCursos.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvCursos.SelectedRow;
                string id = row.Cells[0].Text;
                CursoLogic cl = new CursoLogic();
               // cl.Delete(Convert.ToInt32(id));
            }

            if (e.CommandName == "btnModificar")
            {
                int plan = int.Parse(this.ddlPlanes.SelectedValue);
                int comision = int.Parse(this.ddlComision.SelectedValue);
                dgvCursos.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvCursos.SelectedRow;
                string id = row.Cells[0].Text;
                Response.Redirect("ModificarCurso.aspx?id=" + id+"&plan="+plan+"&comision="+comision);
            }
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlComision.DataSource = new ComisionLogic().DameComisiones(int.Parse(this.ddlPlanes.SelectedValue));
            ddlComision.DataTextField = "desc_comision";
            ddlComision.DataValueField = "id_comision";
            ddlComision.DataBind();
            dgvCursos.DataSource = new CursoLogic().DameCursos(int.Parse(this.ddlComision.SelectedValue));
            dgvCursos.DataBind();
        }
        protected void ddlComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCursos.DataSource = new CursoLogic().DameCursos(int.Parse(this.ddlComision.SelectedValue));
            dgvCursos.DataBind();
        }

    }
}