using System;
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
        MySqlConnection con = new MySqlConnection("server=localhost;Uid=UserApp;password=Indra2020;database=dblibranza;port=3306;persistsecurityinfo=True;");
        Comandos cmds = new Comandos();

        public Planos()
        {
            InitializeComponent();
        }

        private void btnnegados_Click(object sender, EventArgs e)
        {
            if (cmb_Gestion2.Text == "Negados")
            {
                cmds.buscar_negados(dtp_proximo_cargue2, dataGridView1);
            }
            else if (cmb_Gestion2.Text == "Contabilizados")
            {
                cmds.buscar_contabilizados(dtp_proximo_cargue2, dataGridView1);

            }
            else if (cmb_Gestion2.Text == "Pte Respuesta")
            {
                cmds.pendiente_respuesta(dataGridView1);
            }
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
                StreamWriter file = new StreamWriter(@"C:\\Users\\bbva\\Desktop\\Colpensiones\\prueba.txt");
                try
                {
                    string sLine = "";

                    //Este bucle for recorre cada fila de la tabla
                    for (int r = 0; r <= dataGridView1.Rows.Count - 1; r++)
                    {
                        //Este bucle for recorre cada columna y el número de fila
                        //se pasa desde el bucle for arriba.
                        for (int c = 0; c <= dataGridView1.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dataGridView1.Rows[r].Cells[c].Value;
                            if (c != dataGridView1.Columns.Count - 1)
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
            else if (ch_plano_baja.Checked)
            {
                MessageBox.Show("lady todo mal");
            }
            else
            {
                MessageBox.Show("Debe seleccionar que plano va a crear");
            }
        }

        private void Btn_crear_Click(object sender, EventArgs e)
        {

        }

        private void TxtCod_funcionario_TextChanged(object sender, EventArgs e)
        {
            Txtnombre_plano.Text = "PR_00860034133_" + lblfecha_plano.Text;
        }
    }
}
