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
    public partial class CursosInscripto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Usuario usu = (Usuario)Session["Usuario"];

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            dgvCursosIns.AutoGenerateColumns = false;
            dgvCursosIns.DataSource = dcl.DameCursosDocente(UsuarioSesion.Sesion.ID);
            dgvCursosIns.DataBind();
        }
    }
}