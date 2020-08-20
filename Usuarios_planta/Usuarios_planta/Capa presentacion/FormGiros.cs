using System;
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
        
        
        
        private void FormGiros_Load(object sender, EventArgs e)
        {
            dtpcargue.Value = Convert.ToDateTime("01/01/2020");
            lbafiliacion.Visible = false;


        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar limpiar = new limpiar(); //llamo la clase para limpiar todos los textbox que se encuentran en los groupbox
            limpiar.BorrarCampos(groupBox1);
            limpiar.BorrarCampos(groupBox2);
            limpiar.BorrarCampos(groupBox4);
            cmbDestino.Text = "";
            cmbfuerza.Text = "";
            cmbrechazo.Text = "";
            cmbresultado.Text = "";
            Cmbestado.Text = "";
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
                Txtplano_pre.Text= "PRE000000" + Txtcedula.Text;
            }
            else if (length == "7")
            {
                Txtplano_dia.Text = "DIA00000" + Txtcedula.Text;
                Txtplano_pre.Text = "PRE00000" + Txtcedula.Text;
            }
            else if (length == "8")
            {
                Txtplano_dia.Text = "DIA0000" + Txtcedula.Text;
                Txtplano_pre.Text = "PRE0000" + Txtcedula.Text;
            }
            else if (length == "9")
            {
                Txtplano_dia.Text = "DIA000" + Txtcedula.Text;
                Txtplano_pre.Text = "PRE000" + Txtcedula.Text;
            }
            else if (length == "10")
            {
                Txtplano_dia.Text = "DIA00" + Txtcedula.Text;
                Txtplano_pre.Text = "PRE00" + Txtcedula.Text;
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

            cmds.buscar_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring, cmbDestino,
            cmbfuerza, Txtmonto, Txtplazo, Txtcuota,Txttotal, Txtpagare, Txtnit, Txtcuota_letras, Txttotal_letras, cmbresultado, cmbrechazo, Cmbestado,
            dtpcargue, dtpproximo, dtpfecha_desembolso, Txtplano_dia, Txtplano_pre, Txtcomentarios, TxtIDfuncionario, TxtNomFuncionario);

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

        private void cmbresultado_Validated(object sender, EventArgs e)
        {
            if (cmbresultado.Text == "Negado" && cmbDestino.Text == "Retanqueo"  )
            {
                MessageBox.Show("Proceder a recuperar el descuento");
            }
            if (cmbresultado.Text == "Negado" && cmbDestino.Text == "Ck Libranza y Rtq")
            {
                MessageBox.Show("Proceder a recuperar el descuento");
            }
            if (cmbresultado.Text == "Negado" && cmbDestino.Text == "Ck Consumo y Rtq")
            {
                MessageBox.Show("Proceder a recuperar el descuento");
            }
        }

        private void Txtmonto_Validated(object sender, EventArgs e)
        {
            double numero = Convert.ToDouble(Txtmonto.Text);
            Txtmonto.Text = "$" + numero.ToString("N2");
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
            Txttotal.Text = (double.Parse(Txtcuota.Text) * double.Parse(Txtplazo.Text)).ToString();

            //separar por miles el valor de la cuota//
            double numero = Convert.ToDouble(Txtcuota.Text);
            Txtcuota.Text = numero.ToString("N2");
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (cmb_gestion.Text == "Negados")
            {
                cmds.buscar_negados(dtpfecha, dataGridView1);
            }
            else if (cmb_gestion.Text == "Contabilizados")
            {
                cmds.buscar_contabilizados(dtpfecha, dataGridView1);

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
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (validar())
            {
                cmds.Insertar_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo, Txtscoring, cmbDestino,
                                    cmbfuerza, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare,Txtnit, Txtcuota_letras, Txttotal_letras, cmbresultado, cmbrechazo, Cmbestado,
                                    dtpcargue, dtpproximo, dtpfecha_desembolso, Txtplano_dia, Txtplano_pre, Txtcomentarios, TxtIDfuncionario, TxtNomFuncionario);

                //cmds.historico_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txtscoring, cmbDestino, cmbfuerza, Txtmonto, Txtplazo,
                //              Txtentidad, Txtcuota, Txttotal, Txtcuota_letras, Txttotal_letras, dtpcargue, dtpproximo, Txtplano_dia,
                //              Txtplano_pre, cmbresultado, cmbrechazo, Cmbestado, Txtcomentarios, TxtIDfuncionario, TxtNomFuncionario);

                Btnactualizar.Enabled = true;
                BtnGuardar.Enabled = true;
            }
        }

        private void Btn_Actualizar_Click_1(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (validar())
            {
                cmds.actualizar_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txttotal_recaudo,Txtscoring, cmbDestino,
                                    cmbfuerza, Txtmonto, Txtplazo, Txtcuota, Txttotal, Txtpagare,Txtnit, Txtcuota_letras, Txttotal_letras, cmbresultado, cmbrechazo, Cmbestado,
                                    dtpcargue, dtpproximo, dtpfecha_desembolso, Txtplano_dia, Txtplano_pre, Txtcomentarios, TxtIDfuncionario, TxtNomFuncionario);

                //cmds.historico_colp(Txtradicado, Txtcedula, Txtnombre, TxtEstado_cliente, Txtafiliacion1, Txtafiliacion2, Txtscoring, cmbDestino, cmbfuerza, Txtmonto, Txtplazo,
                //              Txtentidad, Txtcuota, Txttotal, Txtcuota_letras, Txttotal_letras, dtpcargue, dtpproximo, Txtplano_dia,
                //              Txtplano_pre, cmbresultado, cmbrechazo, Cmbestado, Txtcomentarios, TxtIDfuncionario, TxtNomFuncionario);

                Btnactualizar.Enabled = true;
                BtnGuardar.Enabled = true;
            }
        }

        //int renglon;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //renglon = e.RowIndex;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Txtcedula.Text = dataGridView1.Rows[renglon].Cells["Cedula"].Value.ToString();
            //Txtscoring.Text = dataGridView1.Rows[renglon].Cells["Scoring"].Value.ToString();
            //Txtnombre.Text = dataGridView1.Rows[renglon].Cells["Nombre_cliente"].Value.ToString();
            //dtpfecha_desembolso.Text = dataGridView1.Rows[renglon].Cells["Fecha_desembolso"].Value.ToString();
            //Txtmonto.Text = dataGridView1.Rows[renglon].Cells["Importe"].Value.ToString();
            //Txtplazo.Text = dataGridView1.Rows[renglon].Cells["Plazo"].Value.ToString();
            //Txtcuota.Text = dataGridView1.Rows[renglon].Cells["Cuota"].Value.ToString();
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.Close();
            Form formulario = new FormGiros();
            formulario.Show();
        }

        private void Txtplano_pre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtscoring_Validated(object sender, EventArgs e)
        {
            string extrae;
            
            extrae = Txtscoring.Text.Substring(Txtscoring.Text.Length - 5); // extrae los ultimos 5 digitos del textbox 
            Txtpagare.Text = "0158" + extrae;
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btncopy_pagare_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txtpagare.Text, true);
        }
    }
}
