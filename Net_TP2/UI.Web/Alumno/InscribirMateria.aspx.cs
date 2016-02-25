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
    public partial class InscribirMateria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) 
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];
            PlanLogic pl = new PlanLogic();
            this.txtPlan.Text = (pl.GetOne(UsuarioSesion.Sesion.IDPlan)).Descripcion;
            CursoLogic cl = new CursoLogic();
            dgvCursosDisp.AutoGenerateColumns = false;
            int idPlan = UsuarioSesion.Sesion.IDPlan;
            dgvCursosDisp.DataSource = cl.DameCursosAInscribir(idPlan, UsuarioSesion.Sesion.ID);
            dgvCursosDisp.DataBind();
            if (dgvCursosDisp.Rows.Count == 0)
            {
                this.lblVacio.Visible = true;
                this.lblVacio.Text = "No existen mas cursos disponibles para usted";                
            }
        }

        protected void dgvMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnInscribir")
            {
                AlumnoInscripcion ai = new AlumnoInscripcion();
                dgvCursosDisp.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvCursosDisp.SelectedRow;
                string idCurso = row.Cells[0].Text;
                ai.IDCurso = int.Parse(idCurso);
                ai.IDAlumno = UsuarioSesion.Sesion.ID;
                ai.Condicion = "Cursando";
                InscripcionLogic il = new InscripcionLogic();
                il.GenerarInscripcion(ai);
                CursoLogic cl = new CursoLogic();
                string cupo = row.Cells[4].Text;
                cl.ActualizarCupoCurso(ai.IDCurso, int.Parse(cupo));
                Response.Redirect("EstadoAcademico.aspx");
            }
        }
    }
}