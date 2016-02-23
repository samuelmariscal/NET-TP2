using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {

        private ModoForm modoForm;
        public ComisionDesktop(ModoForm modoForm)
        {
            InitializeComponent();
            this.modoForm = modoForm;
        }

        private Comision _comisionActual;
        public Comision ComisionActual
        {
            get
            {
                return _comisionActual;
            }
            set
            {
                _comisionActual = value;
            }
        }


        public ComisionDesktop(int id, ModoForm modo)
        {
            InitializeComponent();
            this.modoForm = modo;
            ComisionLogic cl = new ComisionLogic();
            txtIDPlan.Enabled = false;
            if(modo==ModoForm.Alta)
            {
                txtIDPlan.Text = id.ToString();
            }
            else
            {
                ComisionActual = cl.GetComision(id);
                this.MapearDeDatos();
            }
        }

        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtIDPlan.Text = (this.ComisionActual.IDPlan).ToString();
            this.txtAño.Text = (this.ComisionActual.AnioEspecialidad).ToString();
        }

        public override void MapearADatos()
        {
            if (modoForm == ModoForm.Alta)
            {
                Comision c = new Comision();
                ComisionActual = c;
                c.Descripcion = txtDescripcion.Text;
                c.IDPlan = int.Parse(txtIDPlan.Text);
                c.AnioEspecialidad = int.Parse(txtAño.Text);
                this.ComisionActual.State = BusinessEntity.States.New;
            }
            else if (modoForm == ModoForm.Modificacion)
            {
                this.ComisionActual.IDPlan = int.Parse(txtIDPlan.Text);
                this.ComisionActual.Descripcion = txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = int.Parse(txtAño.Text);
                this.ComisionActual.State = BusinessEntity.States.Modified;
            }
        }
        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Notificar("Aviso", "Comision creada satisfactoriamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Dispose();
        }

        public override bool Validar()
        {
            if (txtAño.Text == "" || txtDescripcion.Text == "")
            {
                Notificar("Error", "Los campos deben estar completos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }

    }
}
