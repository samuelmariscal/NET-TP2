using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Administrador.PlanesMaterias2
{
    public partial class AltaMateria2 : System.Web.UI.Page
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
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //aca se debe guardar la materia en el datatable materias y pasarla de nuevo a altaPlan
            Materia mat = new Materia();
            MateriaActual = mat;
            mat.Descripcion = this.txtMateria.Text;
            mat.HSSemanales = int.Parse(this.txtHsSemanales.Text);
            mat.HSTotales = int.Parse(this.txtHsTotales.Text);
            Response.Redirect("AltaPlan.aspx?desc="+mat.Descripcion+"&hsSem="+mat.HSSemanales+"&hsTot="+mat.HSTotales);
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaPlan.aspx");
        }
    }
}