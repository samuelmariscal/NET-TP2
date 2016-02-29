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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        string clave;
        DateTime fechaNac;
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
            this.txtNombre.Focus();
            if (!IsPostBack)
            {
                UsuarioLogic ul = new UsuarioLogic();

                ddlsTipoPersona.DataSource = new UsuarioLogic().GetTiposPersonas();
                ddlsTipoPersona.DataTextField = "desc_tipo_persona";
                ddlsTipoPersona.DataValueField = "id_tipo_persona";
                ddlsTipoPersona.DataBind();

                ddlPlan.DataSource = new PlanLogic().GetAll();
                ddlPlan.DataTextField = "desc_plan";
                ddlPlan.DataValueField = "id_plan";
                ddlPlan.DataBind();

                UsuarioActual = ul.GetOne(Convert.ToInt32(Request.QueryString["id"]));
                this.txtNombre.Text = UsuarioActual.Nombre;
                this.txtApellido.Text = UsuarioActual.Apellido;
                this.txtDireccion.Text = UsuarioActual.Direccion;
                this.txtEmail.Text = UsuarioActual.Email;                
                this.txtLegajo.Text = UsuarioActual.NombreUsuario;
                this.txtTelefono.Text = UsuarioActual.Telefono.ToString();
                this.ddlsTipoPersona.DataTextField = UsuarioActual.TipoPersona.ToString();
                this.ddlPlan.SelectedValue = UsuarioActual.IDPlan.ToString();
                this.clave = UsuarioActual.Clave;
                this.fechaNac = UsuarioActual.FechaNacimiento;
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usr = new Usuario();
            UsuarioActual = usr;
            usr.ID = Convert.ToInt32(Request.QueryString["id"]);
            usr.Clave = clave;
            usr.Apellido = this.txtApellido.Text;
            usr.Email = this.txtEmail.Text;
            usr.setTipoPersona(this.ddlsTipoPersona.SelectedItem.Text);
            usr.Nombre = this.txtNombre.Text;
            usr.NombreUsuario = this.txtLegajo.Text;
            usr.Legajo = int.Parse(this.txtLegajo.Text);            
            usr.Direccion = this.txtDireccion.Text;
            usr.Telefono = this.txtTelefono.Text;
            usr.IDPlan = int.Parse(this.ddlPlan.SelectedValue);
            usr.FechaNacimiento = this.fechaNac;
            this.UsuarioActual.State = BusinessEntity.States.Modified;
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);            

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
    }
}