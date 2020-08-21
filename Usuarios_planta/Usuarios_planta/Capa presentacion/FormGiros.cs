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


namespace Usuarios_planta.Formularios
{
    public partial class FormGiros : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Uid=root;password=Indr42020$;database=dblibranza;port=3306;persistsecurityinfo=True;");
        Comandos cmds = new Comandos();
        Conversion c = new Conversion();
              

        public FormGiros()
        {
            InitializeComponent();
        }

        DateTime thisDay = DateTime.Today;

        private void FormGiros_Load(object sender, EventArgs e)
        {
            dtpcargue.Value = Convert.ToDateTime("01/01/2020");
            lbafiliacion.Visible = false;
            Console.WriteLine(thisDay.ToString("d"));


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
            Btnactualizar.Enabled = true;
            BtnGuardar.Enabled = true;

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

        private void dtpcargue_ValueChanged(object sender, EventArgs e)
        {
            dtpproximo.Value = dtpcargue.Value.AddDays(15);
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
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {

            cmds.buscar_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring,
                             cmbfuerza, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare, Txtnit, Txtentidad,Txtcuota_letras, Txttotal_letras, dtpcargue,
                             dtpproximo, dtpfecha_desembolso, cmbestado,cmbcargue, cmbresultado, cmbrechazo, Txtplano_dia, Txtplano_pre, Txtcomentarios,
                             TxtIDfuncionario, TxtNomFuncionario);

            cmds.cargues_cliente(Txtcedula, TxtCargues);


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
            string largo = Txtcuota.Text;
            string length = Convert.ToString(largo.Length);

            Txttotal.Text = (double.Parse(Txtcuota.Text) * double.Parse(Txtplazo.Text)).ToString();

            if (Convert.ToDouble(Txttotal.Text) > 0)
            {
                Txttotal.Text = string.Format("{0:#,##0}", double.Parse(Txttotal.Text));

            }
            else if (Txttotal.Text == "")
            {
                Txttotal.Text = Convert.ToString(0);
            }

            if (length == "3")
            {
                Txtcuota.Text = "00000" + Txtcuota.Text;
            }
            else if (length == "4")
            {
                Txtcuota.Text = "0000" + Txtcuota.Text;
            }
            else if (length == "5")
            {
                Txtcuota.Text = "000" + Txtcuota.Text;
            }
            else if (length == "6")
            {
                Txtcuota.Text = "00" + Txtcuota.Text;
            }
            else if (length == "7")
            {
                Txtcuota.Text = "0" + Txtcuota.Text;
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
            cmds.cargues_cliente(Txtcedula, TxtCargues);
            string largo = Txtcedula.Text;
            string length = Convert.ToString(largo.Length);

            if (length == "6")
            {
                Txtcedula.Text = "000000" + Txtcedula.Text;
            }
            else if (length == "7")
            {
                Txtcedula.Text = "00000" + Txtcedula.Text;
            }
            else if (length == "8")
            {
                Txtcedula.Text = "0000" + Txtcedula.Text;
            }
            else if (length == "9")
            {
                Txtcedula.Text = "000" + Txtcedula.Text;
            }
            else if (length == "10")
            {
                Txtcedula.Text = "00" + Txtcedula.Text;
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (validar())
            {
                cmds.Insertar_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring,
                                   cmbfuerza, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare, Txtnit, Txtentidad,Txtcuota_letras, Txttotal_letras, dtpcargue,
                                   dtpproximo, dtpfecha_desembolso, cmbestado, cmbcargue, cmbresultado, cmbrechazo, Txtplano_dia, Txtplano_pre, Txtcomentarios,
                                   TxtIDfuncionario, TxtNomFuncionario);

                cmds.historico_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring,
                                   cmbfuerza, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare, Txtnit, Txtentidad,Txtcuota_letras, Txttotal_letras, dtpcargue,
                                   dtpproximo, dtpfecha_desembolso, cmbestado, cmbcargue, cmbresultado, cmbrechazo, Txtplano_dia, Txtplano_pre, Txtcomentarios,
                                   TxtIDfuncionario, TxtNomFuncionario);

                Btnactualizar.Enabled = true;
                BtnGuardar.Enabled = true;
            }
        }

        private void Btn_Actualizar_Click_1(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (validar())
            {
                cmds.actualizar_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring,
                                     cmbfuerza, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare, Txtnit, Txtentidad,Txtcuota_letras, Txttotal_letras, dtpcargue,
                                     dtpproximo, dtpfecha_desembolso, cmbestado, cmbcargue, cmbresultado, cmbrechazo, Txtplano_dia, Txtplano_pre, Txtcomentarios,
                                     TxtIDfuncionario, TxtNomFuncionario);

                cmds.historico_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring,
                                   cmbfuerza, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare, Txtnit, Txtentidad,Txtcuota_letras, Txttotal_letras, dtpcargue,
                                   dtpproximo, dtpfecha_desembolso, cmbestado, cmbcargue, cmbresultado, cmbrechazo, Txtplano_dia, Txtplano_pre, Txtcomentarios,
                                   TxtIDfuncionario, TxtNomFuncionario);

                Btnactualizar.Enabled = true;
                BtnGuardar.Enabled = true;
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
    }
}
