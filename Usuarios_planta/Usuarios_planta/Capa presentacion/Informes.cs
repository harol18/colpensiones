using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Usuarios_planta.Capa_presentacion;

namespace Usuarios_planta.Formularios
{
    public partial class Informes : Form
    {
        
        MySqlConnection con = new MySqlConnection("server=localhost;Uid=;password=;database=dblibranza;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();
       
        public Informes()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           
            if (cmb_Gestion.Text=="Negados")
            {
                cmds.buscar_negadosckl(dtpfecha, dataGridView2);
            }
            else if (cmb_Gestion.Text == "Contabilizados")
            {
                cmds.contabilizados_altas(dtpfecha, dataGridView2);

            }
            else if (cmb_Gestion.Text == "Pte Respuesta")
            {
                cmds.pendiente_respuesta(dataGridView2);
            }      
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("buscar_contabilizados", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_proximo_cargue", dtpfecha.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("No hay operaciones para cargar el dia seleccionado", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }
        }

        private void Informes_Load(object sender, EventArgs e)
        {
            dtpfecha.Value = Convert.ToDateTime("01/01/2020");
            cmds.total_negadas(lbtotal_negados);
            cmds.total_pendientes(lbtotal_rta);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new Planos();
            formulario.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
