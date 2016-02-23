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
    public partial class AltaUsuario : System.Web.UI.Page
    {
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get
            {
                return _usuarioActual;
            }
            set
            {
                _usuarioActual = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                Usuario usu = (Usuario)Session["Usuario"];
                ddlsTipoPersona.DataSource = new UsuarioLogic().GetTiposPersonas();
                ddlsTipoPersona.DataTextField = "desc_tipo_persona";
                ddlsTipoPersona.DataValueField = "id_tipo_persona";
                ddlsTipoPersona.DataBind();

                ddlPlan.DataSource = new PlanLogic().GetAll();
                ddlPlan.DataTextField = "desc_plan";
                ddlPlan.DataValueField = "id_plan";
                ddlPlan.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usr = new Usuario();
            UsuarioActual = usr;
            usr.Apellido = this.txtApellido.Text;
            usr.Clave = "123456";
            usr.Email = this.txtEmail.Text;
            usr.IDPlan = int.Parse(this.ddlPlan.SelectedValue);
            usr.setTipoPersona(this.ddlsTipoPersona.SelectedItem.Text);
            usr.Nombre = this.txtNombre.Text;
            usr.NombreUsuario = this.txtLegajo.Text;
            usr.Legajo = int.Parse(this.txtLegajo.Text);
            usr.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text);
            usr.Direccion = this.txtDireccion.Text;
            usr.Telefono = this.txtTelefono.Text;
            this.UsuarioActual.State = BusinessEntity.States.New;
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
            Response.Redirect("Usuarios.aspx");

        }
    }
}