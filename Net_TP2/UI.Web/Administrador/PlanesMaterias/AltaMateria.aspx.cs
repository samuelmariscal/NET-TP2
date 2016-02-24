using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Administrador.PlanesMaterias
{
    public partial class AltaMateria : System.Web.UI.Page
    {

        private Materia _materiaActual;
        public Materia MateriaActual 
        {
            get 
            {
                return _materiaActual;
            }
            set 
            {
                _materiaActual = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];
            this.txtMateria.Focus();
            if (!IsPostBack)
            {
                ddlPlanes.DataSource = new PlanLogic().GetAll();
                ddlPlanes.DataTextField = "desc_plan";
                ddlPlanes.DataValueField = "id_plan";
                ddlPlanes.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Materia mat = new Materia();
            MateriaActual = mat;
            mat.IDPlan = int.Parse(this.ddlPlanes.SelectedValue);
            mat.Descripcion = this.txtMateria.Text;
            mat.HSSemanales = int.Parse(this.txtHsSemanales.Text);
            mat.HSTotales = int.Parse(this.txtHsTotales.Text);
            this.MateriaActual.State = BusinessEntity.States.New;
            MateriaLogic ml = new MateriaLogic();
            ml.Save(MateriaActual);
            Response.Redirect("Materias.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Materias.aspx");
        }
    }
}