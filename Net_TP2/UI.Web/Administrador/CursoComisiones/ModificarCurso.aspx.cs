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
    public partial class ModificarCurso : System.Web.UI.Page
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
                CursoActual = new CursoLogic().GetOne(Convert.ToInt32(Request.QueryString["id"]));
                this.txtComision.Text = new ComisionLogic().GetComision(Convert.ToInt32(Request.QueryString["comision"])).Descripcion;
                this.txtPlan.Text = new PlanLogic().GetOne(Convert.ToInt32(Request.QueryString["plan"])).Descripcion;
                this.txtCupo.Text = CursoActual.Cupo.ToString();
                this.txtDescripcion.Text = CursoActual.Descripcion;
                this.txtMateria.Text = new MateriaLogic().GetOne(CursoActual.IDMateria).Descripcion;                
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CursoActual = new CursoLogic().GetOne(Convert.ToInt32(Request.QueryString["id"]));
            int idmat = new MateriaLogic().GetOne(CursoActual.IDMateria).ID;                
            Curso cur = new Curso();
            CursoActual = cur;
            cur.ID = Convert.ToInt32(Request.QueryString["id"]);
            cur.IDMateria = idmat;
            cur.Descripcion = this.txtDescripcion.Text;
            cur.Cupo = int.Parse(this.txtCupo.Text);
            cur.IDComision = Convert.ToInt32(Request.QueryString["comision"]);
            this.CursoActual.State = BusinessEntity.States.Modified;
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