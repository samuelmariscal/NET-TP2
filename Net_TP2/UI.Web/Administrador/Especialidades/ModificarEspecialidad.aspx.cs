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
    public partial class ModificarEspecialidad : System.Web.UI.Page
    {
        private Especialidad _especialidadActual;
        public Especialidad EspecialidadActual
        {
            get
            {
                return _especialidadActual;
            }
            set
            {
                _especialidadActual = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];

            if (!IsPostBack)
            {
                EspecialidadLogic el = new EspecialidadLogic();

                EspecialidadActual = el.GetOne(Convert.ToInt32(Request.QueryString["id"]));                
                this.txtEspecialidad.Text = EspecialidadActual.Descripcion;

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {                 
            Especialidad esp = new Especialidad();           
            EspecialidadActual = esp; 
            esp.ID = Convert.ToInt32(Request.QueryString["id"]);
            esp.Descripcion = this.txtEspecialidad.Text;            
            this.EspecialidadActual.State = BusinessEntity.States.Modified;
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
            Response.Redirect("Especialidades.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx");
        }
    }
}