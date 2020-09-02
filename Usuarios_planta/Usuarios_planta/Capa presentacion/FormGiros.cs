﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;
using Color = System.Drawing.Color;

namespace Usuarios_planta.Formularios
{
    public partial class FormGiros : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Uid=root;password=Indr42020$;database=dblibranza;port=3306;persistsecurityinfo=True;");
        

        Comandos cmds = new Comandos();
        Conversion c = new Conversion();
        private Button currentBtn;
        


        public FormGiros()
        {
            InitializeComponent();
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(251, 187, 33);
            public static Color color2 = Color.FromArgb(52, 179, 29);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(53, 41, 237);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = Color.FromArgb(215,219,222);
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 66, 84);
                currentBtn.ForeColor = Color.Gainsboro;
            }
        }

       
        private void FormGiros_Load(object sender, EventArgs e)
        {
            lbafiliacion.Visible = false;
            dtpcargue.Text = "01/01/2020";
            dtpfecha_desembolso.Text = "01/01/2020";
            dtpproximo.Text = "01/01/2020";
            dtpfecha_rpta.Text = "01/01/2020";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar limpiar = new limpiar(); //llamo la clase para limpiar todos los textbox que se encuentran en los groupbox
            limpiar.BorrarCampos(groupBox1);
            limpiar.BorrarCampos(groupBox2);
            limpiar.BorrarCampos(groupBox4);
            cmbfuerza.Text = "";
            cmbrechazo.Text = "";
            cmbresultado.Text = "";
            cmbcargue.Text = "";
            Btn_Actualizar.Enabled = true;
            Btn_Guardar.Enabled = true;

        }

        private void Txtcuota_TextChanged(object sender, EventArgs e)
        {
              Txtcuota_letras.Text = c.enletras(Txtcuota.Text).ToLower();           
        }

        private void Txtcedula_TextChanged(object sender, EventArgs e)
        {
            string largo = Txtcedula.Text;
            string length = Convert.ToString(largo.Length);

            if (length=="6")
            {
                Txtplano_dia.Text= "DIA000000" + Txtcedula.Text;
                Txtplano_pre.Text= "PPRE000000" + Txtcedula.Text;
            }
            else if (length == "7")
            {
                Txtplano_dia.Text = "DIA00000" + Txtcedula.Text;
                Txtplano_pre.Text = "PPRE00000" + Txtcedula.Text;
            }
            else if (length == "8")
            {
                Txtplano_dia.Text = "DIA0000" + Txtcedula.Text;
                Txtplano_pre.Text = "PPRE0000" + Txtcedula.Text;
            }
            else if (length == "9")
            {
                Txtplano_dia.Text = "DIA000" + Txtcedula.Text;
                Txtplano_pre.Text = "PPRE000" + Txtcedula.Text;
            }
            else if (length == "10")
            {
                Txtplano_dia.Text = "DIA00" + Txtcedula.Text;
                Txtplano_pre.Text = "PPRE00" + Txtcedula.Text;
            }          
        }

        private void cmbrechazo_MouseClick(object sender, MouseEventArgs e)
        {
            string query = "SELECT id_rechazo, codigo from tfrechazos_colp";
            MySqlCommand comando = new MySqlCommand(query, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            cmbrechazo.ValueMember = "id_rechazo";
            cmbrechazo.DisplayMember = "codigo";
            cmbrechazo.DataSource = dt;
        }

        private void TxtIDfuncionario_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM tf_usuarios WHERE Identificacion = @Identificacion ", con);
            comando.Parameters.AddWithValue("@Identificacion", TxtIDfuncionario.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TxtNomFuncionario.Text = registro["Nombre"].ToString();
            }
            con.Close();
        }

        private void Txttotal_TextChanged(object sender, EventArgs e)
        {
            Txttotal_letras.Text = c.enletras(Txttotal.Text).ToLower();
        }

        private void Txtafiliacion2_Validated(object sender, EventArgs e)
        {
            if (Txtafiliacion1.Text == Txtafiliacion2.Text)
                lbafiliacion.Text = "Ok Afiliacion";
            else
            {
                MessageBox.Show("Numero de Afiliacion no coincide");
                lbafiliacion.Visible = false;
                Txtafiliacion1.Focus();
            }
            cmds.recaudo(Txtafiliacion2,Txttotal_recaudo);
            cmds.cargues_cliente(Txtafiliacion2, TxtCargues);
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {

            cmds.buscar_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring, Txtconsecutivo,
                             cmbfuerza, cmbdestino, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare, Txtnit, Txtentidad, Txtcuota_letras,
                             Txttotal_letras, cmbestado, cmbcargue, dtpcargue, dtpfecha_desembolso, cmbresultado, dtpproximo, cmbrechazo, dtpfecha_rpta,
                             Txtplano_dia, Txtplano_pre, TxtN_Plano, Txtcomentarios, TxtIDfuncionario, TxtNomFuncionario);

            cmds.cargues_cliente(Txtafiliacion2, TxtCargues);


            if (Txtnombre.TextLength == 0)
            {
                MessageBox.Show("Caso no existe");
                Btn_Actualizar.Enabled = false;
                Btn_Guardar.Enabled = true;
            }
            else
            {
                Btn_Actualizar.Enabled = true;
                Btn_Guardar.Enabled = false;
            }
        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btncopy1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txtcuota_letras.Text, true);
        }

        private void Btncopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txttotal_letras.Text, true);
        }

        private void Btncopy2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txtcomentarios.Text, true);
        }

        private void Txtmonto_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Txtmonto.Text) > 0)
            {
                Txtmonto.Text = string.Format("{0:#,##0}", double.Parse(Txtmonto.Text));
                
            }
            else if (Txtmonto.Text == "")
            {
                Txtmonto.Text = Convert.ToString(0);
            }
        }


        private bool validar()
        {
            bool ok = true;

            if (Txtafiliacion1.Text == "")
            {
                ok = false;
                epError.SetError(Txtafiliacion1, "Debes digitar N° Afiliacion");
            }
            if (Txtafiliacion2.Text == "")
            {
                ok = false;
                epError.SetError(Txtafiliacion2, "Debes digitar N° Afiliacion");
            }
            if (Txtscoring.Text == "")
            {
                ok = false;
                epError.SetError(Txtscoring, "Debes digitar N° Scoring");
            }
            if (Txtmonto.Text == "")
            {
                ok = false;
                epError.SetError(Txtmonto, "Debes digitar Monto");
            }
            if (Txtplazo.Text == "")
            {
                ok = false;
                epError.SetError(Txtplazo, "Debes digitar Plazo");
            }
            if (TxtIDfuncionario.Text == "")
            {
                ok = false;
                epError.SetError(TxtIDfuncionario, "Debes digitar N° Identificación");
            }
            return ok;
        }

        private void BorrarMensajeError()
        {
            epError.SetError(Txtafiliacion1, "");
            epError.SetError(Txtafiliacion2, "");
            epError.SetError(Txtscoring, "");
            epError.SetError(Txtmonto, "");
            epError.SetError(Txtplazo, "");
            epError.SetError(TxtIDfuncionario, "");
        }


        private void Txtcuota_Validated(object sender, EventArgs e)
        {
            Txtcuota.Text = string.Format("{0:#,##0}", double.Parse(Txtcuota.Text));
            Txttotal.Text = (double.Parse(Txtcuota.Text) * double.Parse(Txtplazo.Text)).ToString();

            if (Convert.ToDouble(Txttotal.Text) > 0)
            {
                Txttotal.Text = string.Format("{0:#,##0}", double.Parse(Txttotal.Text));

            }
            else if (Txttotal.Text == "")
            {
                Txttotal.Text = Convert.ToString(0);
            }
        }

        private void TxtEstado_cliente_TextChanged(object sender, EventArgs e)
        {
            if (TxtEstado_cliente.Text == "Fallecido")
            {
                MessageBox.Show("Por favor validar cliente fallecido");
            }
        }

        private void Txtcedula_Validated(object sender, EventArgs e)
        {
            cmds.buscar_fallecido(Txtcedula,TxtEstado_cliente);
            cmds.cargues_cliente(Txtafiliacion2, TxtCargues);
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (validar())
            {
                cmds.Insertar_colp(Txtradicado,Txtcedula,Txtnombre,TxtEstado_cliente,Txtafiliacion1,Txtafiliacion2,Txttotal_recaudo,
                                   Txtscoring,Txtconsecutivo,cmbfuerza,cmbdestino,Txtmonto,Txtplazo,Txtcuota,Txttotal,Txtpagare,Txtnit,Txtentidad,
                                   Txtcuota_letras,Txttotal_letras,cmbestado,cmbcargue,dtpcargue,dtpfecha_desembolso,cmbresultado,
                                   dtpproximo,cmbrechazo,dtpfecha_rpta,Txtplano_dia,Txtplano_pre,TxtN_Plano,Txtcomentarios,TxtIDfuncionario,
                                   TxtNomFuncionario);


                cmds.historico_colp(Txtradicado,Txtcedula,Txtnombre,TxtEstado_cliente,Txtafiliacion1,Txtafiliacion2,Txttotal_recaudo,
                                   Txtscoring,Txtconsecutivo,cmbfuerza,cmbdestino,Txtmonto,Txtplazo,Txtcuota,Txttotal,Txtpagare,Txtnit,Txtentidad,
                                   Txtcuota_letras,Txttotal_letras,cmbestado,cmbcargue,dtpcargue,dtpfecha_desembolso,cmbresultado,
                                   dtpproximo,cmbrechazo,dtpfecha_rpta,Txtplano_dia,Txtplano_pre,TxtN_Plano,Txtcomentarios,TxtIDfuncionario,
                                   TxtNomFuncionario);

                Btn_Actualizar.Enabled = true;
                Btn_Guardar.Enabled = true;
            }
        }

        private void Btn_Actualizar_Click_1(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (validar())
            {
                cmds.actualizar_colp(Txtradicado,Txtcedula,Txtnombre,TxtEstado_cliente,Txtafiliacion1,Txtafiliacion2,Txttotal_recaudo,
                                    Txtscoring,Txtconsecutivo,cmbfuerza,cmbdestino,Txtmonto,Txtplazo,Txtcuota,Txttotal,Txtpagare,Txtnit,Txtentidad,
                                    Txtcuota_letras,Txttotal_letras,cmbestado,cmbcargue,dtpcargue,dtpfecha_desembolso,cmbresultado,
                                    dtpproximo,cmbrechazo,dtpfecha_rpta,Txtplano_dia,Txtplano_pre,TxtN_Plano,Txtcomentarios,TxtIDfuncionario,
                                    TxtNomFuncionario);

                cmds.historico_colp(Txtradicado,Txtcedula,Txtnombre,TxtEstado_cliente,Txtafiliacion1,Txtafiliacion2,Txttotal_recaudo,
                                   Txtscoring,Txtconsecutivo,cmbfuerza,cmbdestino,Txtmonto,Txtplazo,Txtcuota,Txttotal,Txtpagare,Txtnit,Txtentidad,
                                   Txtcuota_letras,Txttotal_letras,cmbestado,cmbcargue,dtpcargue,dtpfecha_desembolso,cmbresultado,
                                   dtpproximo,cmbrechazo,dtpfecha_rpta,Txtplano_dia,Txtplano_pre,TxtN_Plano,Txtcomentarios,TxtIDfuncionario,
                                   TxtNomFuncionario);

                Btn_Actualizar.Enabled = true;
                Btn_Guardar.Enabled = true;
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {

            this.Close();
            Form formulario = new FormGiros();
            formulario.Show();
        }

        private void Txtscoring_Validated(object sender, EventArgs e)
        {
            string extrae;
            
            extrae = Txtscoring.Text.Substring(Txtscoring.Text.Length - 5); // extrae los ultimos 5 digitos del textbox 
            Txtpagare.Text = "0158" + extrae;
        }

        private void btncopy_pagare_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txtpagare.Text, true);
        }

        private void Txtplazo_Validated(object sender, EventArgs e)
        {
            string largo = Txtplazo.Text;
            string length = Convert.ToString(largo.Length);

            if (length == "2")
            {
                Txtplazo.Text = "0" + Txtplazo.Text;
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txtcuota.Text, true);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txtplazo.Text, true);
        }

        private void Btn_Guardar_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void Btn_Actualizar_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void Btn_Nuevo_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form formulario = new VoBo();
            formulario.Show();
        }

        private void cmbresultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbresultado.Text=="Negada")
            {
                dtpproximo.Value = dtpcargue.Value.AddDays(15);
            }
        }
    }
}
