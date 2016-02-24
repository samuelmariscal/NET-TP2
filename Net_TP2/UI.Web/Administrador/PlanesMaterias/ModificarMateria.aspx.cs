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
    public partial class ModificarMateria : System.Web.UI.Page
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

                MateriaLogic ml = new MateriaLogic();

                MateriaActual = ml.GetOne(Convert.ToInt32(Request.QueryString["id"]));
                this.ddlPlanes.SelectedValue = MateriaActual.IDPlan.ToString();
                this.txtMateria.Text = MateriaActual.Descripcion;
                this.txtHsSemanales.Text = MateriaActual.HSSemanales.ToString();
                this.txtHsTotales.Text = MateriaActual.HSTotales.ToString();

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Materia mat = new Materia();
            MateriaActual = mat;
            mat.ID = Convert.ToInt32(Request.QueryString["id"]);
            mat.Descripcion = this.txtMateria.Text;
            mat.HSSemanales = int.Parse(this.txtHsSemanales.Text);
            mat.HSTotales = int.Parse(this.txtHsTotales.Text);
            mat.IDPlan = int.Parse(this.ddlPlanes.SelectedValue);
            this.MateriaActual.State = BusinessEntity.States.Modified;
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