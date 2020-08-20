namespace Usuarios_planta.Capa_presentacion
{
    partial class Planos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.Btn_Crear_plano = new FontAwesome.Sharp.IconButton();
            this.ch_plano_baja = new System.Windows.Forms.CheckBox();
            this.ch_plano_alta = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_proximo_cargue2 = new System.Windows.Forms.DateTimePicker();
            this.TxtCod_funcionario = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_Gestion2 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnnegados = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Txtnombre_plano = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblfecha_plano = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnnegados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.Txtnombre_plano);
            this.panel3.Controls.Add(this.Btn_Crear_plano);
            this.panel3.Controls.Add(this.ch_plano_baja);
            this.panel3.Controls.Add(this.ch_plano_alta);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dtp_proximo_cargue2);
            this.panel3.Controls.Add(this.TxtCod_funcionario);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.cmb_Gestion2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.btnnegados);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(11, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 373);
            this.panel3.TabIndex = 49;
            // 
            // Btn_Crear_plano
            // 
            this.Btn_Crear_plano.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Crear_plano.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.Btn_Crear_plano.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.Btn_Crear_plano.IconColor = System.Drawing.Color.Black;
            this.Btn_Crear_plano.IconSize = 18;
            this.Btn_Crear_plano.Location = new System.Drawing.Point(76, 318);
            this.Btn_Crear_plano.Name = "Btn_Crear_plano";
            this.Btn_Crear_plano.Rotation = 0D;
            this.Btn_Crear_plano.Size = new System.Drawing.Size(89, 30);
            this.Btn_Crear_plano.TabIndex = 59;
            this.Btn_Crear_plano.Text = "Crear Plano";
            this.Btn_Crear_plano.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Crear_plano.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Crear_plano.UseVisualStyleBackColor = true;
            this.Btn_Crear_plano.Click += new System.EventHandler(this.Btn_Crear_plano_Click);
            // 
            // ch_plano_baja
            // 
            this.ch_plano_baja.AutoSize = true;
            this.ch_plano_baja.Location = new System.Drawing.Point(11, 340);
            this.ch_plano_baja.Name = "ch_plano_baja";
            this.ch_plano_baja.Size = new System.Drawing.Size(47, 17);
            this.ch_plano_baja.TabIndex = 58;
            this.ch_plano_baja.Text = "Baja";
            this.ch_plano_baja.UseVisualStyleBackColor = true;
            this.ch_plano_baja.CheckedChanged += new System.EventHandler(this.ch_plano_baja_CheckedChanged);
            // 
            // ch_plano_alta
            // 
            this.ch_plano_alta.AutoSize = true;
            this.ch_plano_alta.Location = new System.Drawing.Point(11, 309);
            this.ch_plano_alta.Name = "ch_plano_alta";
            this.ch_plano_alta.Size = new System.Drawing.Size(44, 17);
            this.ch_plano_alta.TabIndex = 57;
            this.ch_plano_alta.Text = "Alta";
            this.ch_plano_alta.UseVisualStyleBackColor = true;
            this.ch_plano_alta.CheckedChanged += new System.EventHandler(this.ch_plano_alta_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Codigo Funcionario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_proximo_cargue2
            // 
            this.dtp_proximo_cargue2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_proximo_cargue2.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_proximo_cargue2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_proximo_cargue2.Location = new System.Drawing.Point(10, 266);
            this.dtp_proximo_cargue2.Name = "dtp_proximo_cargue2";
            this.dtp_proximo_cargue2.Size = new System.Drawing.Size(108, 25);
            this.dtp_proximo_cargue2.TabIndex = 55;
            // 
            // TxtCod_funcionario
            // 
            this.TxtCod_funcionario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtCod_funcionario.BackColor = System.Drawing.SystemColors.Menu;
            this.TxtCod_funcionario.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCod_funcionario.Location = new System.Drawing.Point(3, 47);
            this.TxtCod_funcionario.Multiline = true;
            this.TxtCod_funcionario.Name = "TxtCod_funcionario";
            this.TxtCod_funcionario.Size = new System.Drawing.Size(44, 24);
            this.TxtCod_funcionario.TabIndex = 53;
            this.TxtCod_funcionario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtCod_funcionario.TextChanged += new System.EventHandler(this.TxtCod_funcionario_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "Seleccionar Estado";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_Gestion2
            // 
            this.cmb_Gestion2.BackColor = System.Drawing.SystemColors.Menu;
            this.cmb_Gestion2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_Gestion2.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Gestion2.FormattingEnabled = true;
            this.cmb_Gestion2.Items.AddRange(new object[] {
            "Negados",
            "Contabilizados",
            "Pte Respuesta"});
            this.cmb_Gestion2.Location = new System.Drawing.Point(5, 201);
            this.cmb_Gestion2.Name = "cmb_Gestion2";
            this.cmb_Gestion2.Size = new System.Drawing.Size(148, 25);
            this.cmb_Gestion2.TabIndex = 9;
            this.cmb_Gestion2.Text = " ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 24);
            this.panel4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Validacion por Fechas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnnegados
            // 
            this.btnnegados.BackColor = System.Drawing.Color.White;
            this.btnnegados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnegados.Image = global::Usuarios_planta.Properties.Resources.eye_50px;
            this.btnnegados.Location = new System.Drawing.Point(137, 266);
            this.btnnegados.Name = "btnnegados";
            this.btnnegados.Size = new System.Drawing.Size(28, 24);
            this.btnnegados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnnegados.TabIndex = 41;
            this.btnnegados.TabStop = false;
            this.btnnegados.Click += new System.EventHandler(this.btnnegados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(518, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 43);
            this.label3.TabIndex = 52;
            this.label3.Text = "Generador de planos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Usuarios_planta.Properties.Resources.índice1;
            this.pictureBox8.Location = new System.Drawing.Point(10, 10);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(120, 77);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 51;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Usuarios_planta.Properties.Resources.colpensiones;
            this.pictureBox6.Location = new System.Drawing.Point(1015, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(185, 75);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 50;
            this.pictureBox6.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(263, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(937, 523);
            this.dataGridView1.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(187)))), ((int)(((byte)(33)))));
            this.pictureBox3.Location = new System.Drawing.Point(1045, 792);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(269, 20);
            this.pictureBox3.TabIndex = 59;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(101)))), ((int)(((byte)(124)))));
            this.pictureBox2.Location = new System.Drawing.Point(537, 792);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 20);
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            this.pictureBox1.Location = new System.Drawing.Point(1, 792);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 20);
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // Txtnombre_plano
            // 
            this.Txtnombre_plano.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txtnombre_plano.BackColor = System.Drawing.SystemColors.Menu;
            this.Txtnombre_plano.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtnombre_plano.Location = new System.Drawing.Point(5, 128);
            this.Txtnombre_plano.Multiline = true;
            this.Txtnombre_plano.Name = "Txtnombre_plano";
            this.Txtnombre_plano.Size = new System.Drawing.Size(153, 24);
            this.Txtnombre_plano.TabIndex = 60;
            this.Txtnombre_plano.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 61;
            this.label5.Text = "Plano";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblfecha_plano
            // 
            this.lblfecha_plano.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblfecha_plano.AutoSize = true;
            this.lblfecha_plano.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha_plano.Location = new System.Drawing.Point(146, 85);
            this.lblfecha_plano.Name = "lblfecha_plano";
            this.lblfecha_plano.Size = new System.Drawing.Size(140, 17);
            this.lblfecha_plano.TabIndex = 60;
            this.lblfecha_plano.Text = "Codigo Funcionario";
            this.lblfecha_plano.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Planos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1212, 788);
            this.Controls.Add(this.lblfecha_plano);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Planos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnnegados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_Gestion2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnnegados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox TxtCod_funcionario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_proximo_cargue2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox ch_plano_baja;
        private System.Windows.Forms.CheckBox ch_plano_alta;
        private FontAwesome.Sharp.IconButton Btn_Crear_plano;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Txtnombre_plano;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblfecha_plano;
    }
}