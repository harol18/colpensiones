﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Usuarios_planta.Capa_presentacion
{
    public partial class Planos : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Uid=root;password=Indr42020$;database=dblibranza;port=3306;persistsecurityinfo=True;");
       

        Comandos cmds = new Comandos();

        public Planos()
        {
            InitializeComponent(); 
        }


        private void ch_plano_alta_CheckedChanged(object sender, EventArgs e)
        {
            ch_plano_baja.Checked = false;
        }

        private void ch_plano_baja_CheckedChanged(object sender, EventArgs e)
        {
            ch_plano_alta.Checked = false;

        }

        DateTime fecha = DateTime.Now;
        
        

        private void Btn_Crear_plano_Click(object sender, EventArgs e)
        {
            
            if (ch_plano_alta.Checked)
            {
                //Esta línea de código crea un archivo de texto para la exportación de datos.
                StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + Txtplano_alta.Text + ".txt");
                //StreamWriter file = new StreamWriter(@"D:\\Colpensiones\\" + Txtplano_alta.Text + ".txt");
                try
                {
                    string sLine = "";

                    //Este bucle for recorre cada fila de la tabla
                    for (int r = 0; r <= dgv_altas.Rows.Count - 1; r++)
                    {
                        //Este bucle for recorre cada columna y el número de fila
                        //se pasa desde el bucle for arriba.
                        for (int c = 0; c <= dgv_altas.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dgv_altas.Rows[r].Cells[c].Value;
                            if (c != dgv_altas.Columns.Count - 1)
                            {
                                // Una coma se agrega como delimitador de texto para
                                //para separar cada campo en el archivo de texto.
                                //Puede elegir otro carácter como delimitador, para este caso no se pone delimitador dado
                                //que el plano va toda la informacion pegada sin espacios ni caracteres.
                                sLine = sLine + "";
                            }
                        }
                        //El texto exportado se escribe en el archivo de texto, una línea a la vez.
                        file.WriteLine(sLine);
                        sLine = "";
                    }

                    file.Close();
                    MessageBox.Show("Ok archivo txt creado.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmds.planos_cargue(dgv_altas, Txtplano_alta);                
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }
            else if (ch_plano_baja.Checked)
            {
                //Esta línea de código crea un archivo de texto para la exportación de datos.
                StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + Txtplano_baja.Text + ".txt");
                //StreamWriter file = new StreamWriter(@"D:\\Colpensiones\\" + Txtplano_baja.Text + ".txt");
                try
                {
                    string sLine = "";

                    //Este bucle for recorre cada fila de la tabla
                    for (int r = 0; r <= dgv_bajas.Rows.Count - 1; r++)
                    {
                        //Este bucle for recorre cada columna y el número de fila
                        //se pasa desde el bucle for arriba.
                        for (int c = 0; c <= dgv_bajas.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dgv_bajas.Rows[r].Cells[c].Value;
                            if (c != dgv_bajas.Columns.Count - 1)
                            {
                                // Una coma se agrega como delimitador de texto para
                                //para separar cada campo en el archivo de texto.
                                //Puede elegir otro carácter como delimitador.
                                sLine = sLine + "";
                            }
                        }
                        //El texto exportado se escribe en el archivo de texto, una línea a la vez.
                        file.WriteLine(sLine);
                        sLine = "";
                    }

                    file.Close();
                    MessageBox.Show("Ok archivo txt creado.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar que plano va a crear");
            }
        }
      

        private void TxtCod_funcionario_TextChanged(object sender, EventArgs e)
        {
            String sCadena = dtphoy.Text;
            String año = sCadena.Substring(6, 4);
            String mes = sCadena.Substring(3, 2);
            String dia = sCadena.Substring(0, 2);

            Txtplano_alta.Text = "PR_00860034133_"+año+mes+dia+TxtCod_plano.Text;
            Txtplano_baja.Text = "RP_00860034133_" + año + mes + dia + TxtCod_plano.Text;
        }

        private void btn_Validar_Click(object sender, EventArgs e)
        {
            if (cmb_Gestion2.Text == "Negados")
            {
                cmds.buscar_negados(dtp_cargue, dgv_altas);
            }
            else if (cmb_Gestion2.Text == "Pendiente Cargue")
            {
                cmds.pendiente_cargue(dtp_cargue, dgv_altas);

            }
            else if (cmb_Gestion2.Text == "Contabilizados")
            {
                cmds.contabilizados_altas(dtp_cargue, dgv_altas);
                cmds.contabilizados_bajas(dtp_cargue, dgv_bajas);

            }
            else if (cmb_Gestion2.Text == "Pte Respuesta")
            {
                cmds.pendiente_respuesta(dgv_altas);
            }
        }

        private void btn_Actualizarbd_Click(object sender, EventArgs e)
        {
         
            try
            {
                con.Open();
                string query = "INSERT INTO prueba (Afiliacion, plano, Fecha_cargue) VALUES (@param1, @param2, @param3)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                foreach (DataGridViewRow row in dgv_altas.Rows)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@param1", Convert.ToString(row.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@param2", Txtplano_alta.Text);
                    cmd.Parameters.AddWithValue("@param3", dtphoy.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Ok información actualizada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }
        }

        private void Planos_Load(object sender, EventArgs e)
        {
            String sCadena = dtphoy.Text;
            String año = sCadena.Substring(6, 4);
            String mes = sCadena.Substring(3, 2);
            String dia = sCadena.Substring(0, 2);

            Txtplano_alta.Text = "PR_00860034133_" + año + mes + dia + TxtCod_plano.Text;
            Txtplano_baja.Text = "RP_00860034133_" + año + mes + dia + TxtCod_plano.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
