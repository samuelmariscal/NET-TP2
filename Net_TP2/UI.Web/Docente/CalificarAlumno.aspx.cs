using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Docente
{
    public partial class CalificarAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];
            int[] notas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ddlNotas.DataSource = notas;
            ddlNotas.DataBind();
            this.txtInscripcion.Text = Request.QueryString["id"];
            this.txtEstado.Focus();
        }

        //NO ME ASIGNA LA NOTA QUE SELECCIONO
        protected void btnCalificar_Click(object sender, EventArgs e)
        {
            if (this.txtEstado.Text != "")
            {
                InscripcionLogic il = new InscripcionLogic();
                AlumnoInscripcion ai = new AlumnoInscripcion();
                ai.ID = int.Parse(this.txtInscripcion.Text);
                ai.Nota = int.Parse(this.ddlNotas.SelectedValue);
                ai.Condicion = this.txtEstado.Text;
                il.ActualizarInscripcion(ai);
                Response.Redirect("Calificaciones.aspx");
            }
            else 
            {
                this.txtEstado.Focus();
            }
        }

    }
}