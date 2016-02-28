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
                dgvCursos.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvCursos.SelectedRow;
                string idCurso = row.Cells[0].Text;
                dc.IDCurso = int.Parse(idCurso);
                dc.IDDocente=UsuarioSesion.Sesion.ID;
                DropDownList ddlCargos = (DropDownList)dgvCursos.SelectedRow.FindControl("ddlCargos");
                dc.Cargo = (DocenteCurso.TiposCargos)ddlCargos.DataSource;
                if (cl.ValidarCurso(int.Parse(idCurso), UsuarioSesion.Sesion.ID).Rows.Count == 0)
                {
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    dcl.AgregarDocenteACurso(dc);
                }
                else
                {
                    //mensaje de error
                }
            }
        }
    }
}