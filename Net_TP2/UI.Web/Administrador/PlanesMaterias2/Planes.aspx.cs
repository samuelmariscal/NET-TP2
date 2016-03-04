using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web.Administrador.PlanesMaterias2
{
    public partial class Planes : System.Web.UI.Page
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

                Usuario usu = (Usuario)Session["Usuario"];
                dgvMaterias.DataSource = new MateriaLogic().GetAll(int.Parse(this.ddlPlanes.SelectedValue));
                dgvMaterias.DataBind();
            }
        }


        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaPlan.aspx");
        }
        protected void dgvMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnBaja")
            {
                dgvMaterias.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvMaterias.SelectedRow;
                string id = row.Cells[0].Text;
                MateriaLogic ml = new MateriaLogic();
                ml.Delete(Convert.ToInt32(id));
            }

            if (e.CommandName == "btnModificar")
            {
                dgvMaterias.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvMaterias.SelectedRow;
                string id = row.Cells[0].Text;
                Response.Redirect("ModificarMateria.aspx?id=" + id);
            }
        }


        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {            
                dgvMaterias.DataSource = new MateriaLogic().GetAll(int.Parse(this.ddlPlanes.SelectedValue));
                dgvMaterias.DataBind();          
        }


    }
    
}