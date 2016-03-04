using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Administrador.PlanesMaterias2
{
    
    public partial class AltaPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("desc_materia", typeof(string));
                dt.Columns.Add("hs_semanales", typeof(int));
                dt.Columns.Add("hs_totales", typeof(int));

                EspecialidadLogic el = new EspecialidadLogic();
                ddlEspecialidad.DataSource = el.GetAll();
                ddlEspecialidad.DataTextField = "desc_especialidad";
                ddlEspecialidad.DataValueField = "id_especialidad";
                ddlEspecialidad.DataBind();


                dt.Rows.Add(dt.NewRow());

                dgvMaterias.DataSource = dt;
                dgvMaterias.DataBind();
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("desc_materia", typeof(string));
            dt.Columns.Add("hs_semanales", typeof(int));
            dt.Columns.Add("hs_totales", typeof(int));

            foreach (GridViewRow gvRow in dgvMaterias.Rows)
            {
                    DataRow dr = dt.NewRow();
                    dr["desc_materia"] = (gvRow.Cells[0].FindControl("desc_materia") as TextBox).Text;
                    dr["hs_semanales"] = int.Parse((gvRow.Cells[0].FindControl("hs_semanales") as TextBox).Text);
                    dr["hs_totales"] = int.Parse((gvRow.Cells[0].FindControl("hs_totales") as TextBox).Text);
                    dt.Rows.Add(dr);
            }

            DataRow newRow = dt.NewRow();

            newRow["desc_materia"] = "";
            newRow["hs_semanales"] = 0;
            newRow["hs_totales"] = 0;

            dt.Rows.Add(newRow);

            dgvMaterias.DataSource = dt;
            dgvMaterias.DataBind();
        }

        protected void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            Plan p = new Plan();
            p.IDEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            p.Descripcion = txtDescPlan.Text;

            List<Materia> materias = new List<Materia>();

            foreach (GridViewRow gvRow in dgvMaterias.Rows)
            {
                var m = new Materia {
                    Descripcion = (gvRow.Cells[0].FindControl("desc_materia") as TextBox).Text,
                    HSSemanales = int.Parse((gvRow.Cells[0].FindControl("hs_semanales") as TextBox).Text),
                    HSTotales = int.Parse((gvRow.Cells[0].FindControl("hs_totales") as TextBox).Text)
                };

                materias.Add(m);
            }
            try
            {
                pl.AddPlan(p, materias);
                Response.Redirect("Planes.aspx");
            } catch (Exception ex)
            {
                // Que no te explote en la cara
            }
        }

    }
}