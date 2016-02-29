namespace UI.Desktop
{
    partial class ReporteCurso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvReporteCursos = new System.Windows.Forms.DataGridView();
            this.btnGenerarRep = new System.Windows.Forms.Button();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_calendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvReporteCursos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerarRep, 0, 1);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.81967F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.180327F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 339);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvReporteCursos
            // 
            this.dgvReporteCursos.AllowUserToAddRows = false;
            this.dgvReporteCursos.AllowUserToDeleteRows = false;
            this.dgvReporteCursos.AllowUserToResizeColumns = false;
            this.dgvReporteCursos.AllowUserToResizeRows = false;
            this.dgvReporteCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporteCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_curso,
            this.anio_calendario,
            this.cupo,
            this.descripcion,
            this.id_materia,
            this.desc_comision,
            this.nombre,
            this.apellido});
            this.dgvReporteCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporteCursos.Location = new System.Drawing.Point(3, 3);
            this.dgvReporteCursos.MultiSelect = false;
            this.dgvReporteCursos.Name = "dgvReporteCursos";
            this.dgvReporteCursos.ReadOnly = true;
            this.dgvReporteCursos.Size = new System.Drawing.Size(767, 301);
            this.dgvReporteCursos.TabIndex = 0;
            // 
            // btnGenerarRep
            // 
            this.btnGenerarRep.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGenerarRep.Location = new System.Drawing.Point(652, 310);
            this.btnGenerarRep.Name = "btnGenerarRep";
            this.btnGenerarRep.Size = new System.Drawing.Size(118, 26);
            this.btnGenerarRep.TabIndex = 1;
            this.btnGenerarRep.Text = "Generar Reporte";
            this.btnGenerarRep.UseVisualStyleBackColor = true;
            this.btnGenerarRep.Click += new System.EventHandler(this.btnGenerarRep_Click);
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // desc_comision
            // 
            this.desc_comision.DataPropertyName = "desc_comision";
            this.desc_comision.HeaderText = "Comision";
            this.desc_comision.Name = "desc_comision";
            this.desc_comision.ReadOnly = true;
            // 
            // id_materia
            // 
            this.id_materia.DataPropertyName = "id_materia";
            this.id_materia.HeaderText = "ID Materia";
            this.id_materia.Name = "id_materia";
            this.id_materia.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cupo
            // 
            this.cupo.DataPropertyName = "cupo";
            this.cupo.HeaderText = "Cupo";
            this.cupo.Name = "cupo";
            this.cupo.ReadOnly = true;
            // 
            // anio_calendario
            // 
            this.anio_calendario.DataPropertyName = "anio_calendario";
            this.anio_calendario.HeaderText = "Año Calendario";
            this.anio_calendario.Name = "anio_calendario";
            this.anio_calendario.ReadOnly = true;
            // 
            // id_curso
            // 
            this.id_curso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_curso.DataPropertyName = "id_curso";
            this.id_curso.HeaderText = "ID Curso";
            this.id_curso.Name = "id_curso";
            this.id_curso.ReadOnly = true;
            // 
            // ReporteCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 339);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReporteCurso";
            this.Text = "ReporteCurso";
            this.Load += new System.EventHandler(this.ReporteCurso_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteCursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvReporteCursos;
        private System.Windows.Forms.Button btnGenerarRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_calendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;

    }
}