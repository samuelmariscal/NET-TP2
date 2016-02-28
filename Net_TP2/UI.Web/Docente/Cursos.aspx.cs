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
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];

            dgvCursos.DataSource = new CursoLogic().DameCursos();
            dgvCursos.DataBind();
            this.lblVacio.Text = "";
        }

        protected void dgvCursos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList cargos = (DropDownList)e.Row.FindControl("ddlCargos");
                cargos.DataSource = Enum.GetValues(typeof(DocenteCurso.TiposCargos));
                cargos.DataBind();
            }
        }


        protected void dgvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnInscribir")
            {
                CursoLogic cl = new CursoLogic();
                DocenteCurso dc = new DocenteCurso();
                int index = Convert.ToInt32(e.CommandArgument);
                dgvCursos.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvCursos.SelectedRow;
                string idCurso = row.Cells[0].Text;
                dc.IDCurso = int.Parse(idCurso);
                dc.IDDocente=UsuarioSesion.Sesion.ID;
                DropDownList ddlCargos = (DropDownList)dgvCursos.Rows[index].FindControl("ddlCargos");
                if (ddlCargos.SelectedItem.Text == DocenteCurso.TiposCargos.Suplente.ToString())
                {
                    dc.Cargo = DocenteCurso.TiposCargos.Suplente;
                }
                else if (ddlCargos.SelectedItem.Text == DocenteCurso.TiposCargos.Adjunto.ToString())
                {
                    dc.Cargo = DocenteCurso.TiposCargos.Adjunto;
                }
                else if (ddlCargos.SelectedItem.Text == DocenteCurso.TiposCargos.Titular.ToString())
                {
                    dc.Cargo = DocenteCurso.TiposCargos.Titular;
                }
                else
                {
                    dc.Cargo = BusinessEntity.TiposCargos.Ayudante;
                }

                if (cl.ValidarCurso(int.Parse(idCurso), UsuarioSesion.Sesion.ID).Rows.Count == 0)
                {
                    this.lblVacio.Text = "Inscripcion realizada";
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    dcl.AgregarDocenteACurso(dc);
                }
                else
                {
                    this.lblVacio.Text = "Error, Ya esta inscripto en este curso";
                }
            }
        }
    }
}