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
    public partial class AltaCurso : System.Web.UI.Page
    {
        private Curso _cursoActual;
        public Curso CursoActual
        {
            get
            {
                return _cursoActual;
            }
            set
            {
                _cursoActual = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];
            this.txtDescripcion.Focus();
            if (!IsPostBack)
            {
                this.ddlMaterias.DataSource = new MateriaLogic().GetAll(Convert.ToInt32(Request.QueryString["plan"]), Convert.ToInt32(Request.QueryString["comision"]));
                this.ddlMaterias.DataTextField = "desc_materia";
                this.ddlMaterias.DataValueField = "id_materia";
                this.ddlMaterias.DataBind();
                this.txtPlan.Text = new PlanLogic().GetOne(Convert.ToInt32(Request.QueryString["plan"])).Descripcion;
                this.txtComision.Text = new ComisionLogic().GetComision(Convert.ToInt32(Request.QueryString["comision"])).Descripcion;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Curso cur = new Curso();
            CursoActual = cur;
            cur.IDComision = Convert.ToInt32(Request.QueryString["comision"]);
            cur.IDMateria = int.Parse(this.ddlMaterias.SelectedValue);
            cur.Descripcion = this.txtDescripcion.Text;
            cur.Cupo = int.Parse(this.txtCupo.Text);
            cur.AnioCalendario = DateTime.Now.Year;
            this.CursoActual.State = BusinessEntity.States.New;
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
            Response.Redirect("CursoComisiones.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("CursoComisiones.aspx");
        }
    }
}