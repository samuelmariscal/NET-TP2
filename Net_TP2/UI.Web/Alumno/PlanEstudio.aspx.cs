using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Alumno
{
    public partial class PlanEstudio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];

            MateriaLogic ml = new MateriaLogic();
            dgvPlanEstudio.AutoGenerateColumns = false;
            dgvPlanEstudio.DataSource = ml.GetAll(UsuarioSesion.Sesion.IDPlan);
            dgvPlanEstudio.DataBind();
        }
    }
}