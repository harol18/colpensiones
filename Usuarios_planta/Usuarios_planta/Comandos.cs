﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using MySql.Data.MySqlClient;



namespace Usuarios_planta
{
    class Comandos
    {
        MySqlConnection con = new MySqlConnection("server=localhost;Uid=;password=;database=dblibranza;port=3306;persistsecurityinfo=True;");
        //MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=dblibranza;port=3306;persistsecurityinfo=True;");



        public void Insertar_colp(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, TextBox Txtafiliacion1, TextBox Txtafiliacion2,
            TextBox Txttotal_recaudo, TextBox Txtscoring, ComboBox cmbfuerza, TextBox Txtmonto, TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal, TextBox Txtpagare,
            TextBox Txtnit, TextBox Txtentidad, TextBox Txtcuota_letras, TextBox Txttotal_letras, ComboBox cmbestado, ComboBox cmbcargue, DateTimePicker dtpcargue, DateTimePicker dtpproximo,
            DateTimePicker dtpfecha_desembolso, ComboBox cmbresultado, ComboBox cmbrechazo, TextBox Txtplano_dia, TextBox Txtplano_pre,
            TextBox Txtcomentarios, TextBox TxtIDfuncionario, TextBox TxtNomFuncionario)
        {
            con.Open(); 
            MySqlCommand cmd = new MySqlCommand("insertar_colp", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente 

            try
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Cliente", Txtnombre.Text);
                cmd.Parameters.AddWithValue("@_Estado_Cliente", TxtEstado_cliente.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion1", Txtafiliacion1.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion2", Txtafiliacion2.Text);
                cmd.Parameters.AddWithValue("@_Recaudo", Txttotal_recaudo.Text);
                cmd.Parameters.AddWithValue("@_Scoring", Txtscoring.Text);
                cmd.Parameters.AddWithValue("@_Fuerza_Venta", cmbfuerza.Text);
                cmd.Parameters.AddWithValue("@_Monto_Aprobado", Txtmonto.Text);
                cmd.Parameters.AddWithValue("@_Plazo_Aprobado", Txtplazo.Text);
                cmd.Parameters.AddWithValue("@_Cuota", Txtcuota.Text);
                cmd.Parameters.AddWithValue("@_Total", Txttotal.Text);
                cmd.Parameters.AddWithValue("@_Pagare", Txtpagare.Text);
                cmd.Parameters.AddWithValue("@_Nit", Txtnit.Text);
                cmd.Parameters.AddWithValue("@_Entidades", Txtentidad.Text);
                cmd.Parameters.AddWithValue("@_Cuota_Letras", Txtcuota_letras.Text);
                cmd.Parameters.AddWithValue("@_Total_Letras", Txttotal_letras.Text);
                cmd.Parameters.AddWithValue("@_Estado_operacion", cmbestado.Text);
                cmd.Parameters.AddWithValue("@_Estado_cargue", cmbcargue.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtpcargue.Text);
                cmd.Parameters.AddWithValue("@_Proximo_Cargue", dtpproximo.Text);
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtpfecha_desembolso.Text);                
                cmd.Parameters.AddWithValue("@_Respuesta_Cargue", cmbresultado.Text);
                cmd.Parameters.AddWithValue("@_Causal_Rechazo", cmbrechazo.Text);   
                cmd.Parameters.AddWithValue("@_Plano_Dia", Txtplano_dia.Text);
                cmd.Parameters.AddWithValue("@_Plano_Pre", Txtplano_pre.Text);
                cmd.Parameters.AddWithValue("@_Comentarios", Txtcomentarios.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", TxtIDfuncionario.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", TxtNomFuncionario.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Registrada");
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show("Se encontró una excepción de tipo" + ex.GetType() +
                                                      " al intentar revertir la transacción..");
                        Console.WriteLine(e);

                    }
                }
                MessageBox.Show("Se encontró una excepción de tipo " + e.GetType() +
                                              " al insertar los datos.");
                Console.WriteLine(e);
                MessageBox.Show("Ninguno de los registros se escribió en la base de datos.");
            }
            finally
            {
                con.Close();
            }
        }

        public void actualizar_colp(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, TextBox Txtafiliacion1, TextBox Txtafiliacion2,
                                    TextBox Txttotal_recaudo, TextBox Txtscoring, ComboBox cmbfuerza, TextBox Txtmonto, TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal, 
                                    TextBox Txtpagare, TextBox Txtnit, TextBox Txtentidad, TextBox Txtcuota_letras, TextBox Txttotal_letras, ComboBox cmbestado, ComboBox cmbcargue,
                                    DateTimePicker dtpcargue, DateTimePicker dtpproximo, DateTimePicker dtpfecha_desembolso, ComboBox cmbresultado, ComboBox cmbrechazo, TextBox Txtplano_dia, 
                                    TextBox Txtplano_pre,TextBox Txtcomentarios, TextBox TxtIDfuncionario, TextBox TxtNomFuncionario)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("actualizar_colp", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente 

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Cliente", Txtnombre.Text);
                cmd.Parameters.AddWithValue("@_Estado_Cliente", TxtEstado_cliente.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion1", Txtafiliacion1.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion2", Txtafiliacion2.Text);
                cmd.Parameters.AddWithValue("@_Recaudo", Txttotal_recaudo.Text);
                cmd.Parameters.AddWithValue("@_Scoring", Txtscoring.Text);
                cmd.Parameters.AddWithValue("@_Fuerza_Venta", cmbfuerza.Text);
                cmd.Parameters.AddWithValue("@_Monto_Aprobado", Txtmonto.Text);
                cmd.Parameters.AddWithValue("@_Plazo_Aprobado", Txtplazo.Text);
                cmd.Parameters.AddWithValue("@_Cuota", Txtcuota.Text);
                cmd.Parameters.AddWithValue("@_Total", Txttotal.Text);
                cmd.Parameters.AddWithValue("@_Pagare", Txtpagare.Text);
                cmd.Parameters.AddWithValue("@_Nit", Txtnit.Text);
                cmd.Parameters.AddWithValue("@_Entidades", Txtentidad.Text);
                cmd.Parameters.AddWithValue("@_Cuota_Letras", Txtcuota_letras.Text);
                cmd.Parameters.AddWithValue("@_Total_Letras", Txttotal_letras.Text);
                cmd.Parameters.AddWithValue("@_Estado_operacion", cmbestado.Text);
                cmd.Parameters.AddWithValue("@_Estado_cargue", cmbcargue.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtpcargue.Text);
                cmd.Parameters.AddWithValue("@_Proximo_Cargue", dtpproximo.Text);
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtpfecha_desembolso.Text);                
                cmd.Parameters.AddWithValue("@_Respuesta_Cargue", cmbresultado.Text);
                cmd.Parameters.AddWithValue("@_Causal_Rechazo", cmbrechazo.Text);
                cmd.Parameters.AddWithValue("@_Plano_Dia", Txtplano_dia.Text);
                cmd.Parameters.AddWithValue("@_Plano_Pre", Txtplano_pre.Text);
                cmd.Parameters.AddWithValue("@_Comentarios", Txtcomentarios.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", TxtIDfuncionario.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", TxtNomFuncionario.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Actualizada");
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine(e);
                        MessageBox.Show("Se encontró una excepción de tipo" + ex.GetType() +
                                                      " al intentar revertir la transacción..");

                    }
                }
                MessageBox.Show("Se encontró una excepción de tipo " + e.GetType() +
                                              " al insertar los datos.");
                MessageBox.Show("Ninguno de los registros se escribió en la base de datos.");
            }
            finally
            {
                con.Close();
            }
        }

        public void buscar_colp(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, TextBox Txtafiliacion1, TextBox Txtafiliacion2,
                                TextBox Txttotal_recaudo, TextBox Txtscoring, ComboBox cmbfuerza, TextBox Txtmonto, TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal,
                                TextBox Txtpagare, TextBox Txtnit, TextBox Txtentidad, TextBox Txtcuota_letras, TextBox Txttotal_letras, ComboBox cmbestado, ComboBox cmbcargue,
                                DateTimePicker dtpcargue, DateTimePicker dtpproximo, DateTimePicker dtpfecha_desembolso, ComboBox cmbresultado, ComboBox cmbrechazo, TextBox Txtplano_dia,
                                TextBox Txtplano_pre, TextBox Txtcomentarios, TextBox TxtIDfuncionario, TextBox TxtNomFuncionario)
        {
            
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_colp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    Txtcedula.Text = registro["Cedula"].ToString();
                    Txtnombre.Text = registro["Nombre_Cliente"].ToString();
                    TxtEstado_cliente.Text = registro["Estado_Cliente"].ToString();
                    Txtafiliacion1.Text = registro["N_Afiliacion1"].ToString();
                    Txtafiliacion2.Text = registro["N_Afiliacion2"].ToString();
                    Txttotal_recaudo.Text = registro["Recaudo"].ToString();
                    Txtscoring.Text = registro["Scoring"].ToString();
                    cmbfuerza.Text = registro["Fuerza_Venta"].ToString();
                    Txtmonto.Text = registro["Monto_Aprobado"].ToString();
                    Txtplazo.Text = registro["Plazo_Aprobado"].ToString();
                    Txtcuota.Text = registro["Cuota"].ToString();
                    Txttotal.Text = registro["Total"].ToString();
                    Txtpagare.Text = registro["Pagare"].ToString();
                    Txtnit.Text = registro["Nit"].ToString();
                    Txtentidad.Text = registro["Entidades"].ToString();
                    Txtcuota_letras.Text = registro["Cuota_Letras"].ToString();
                    Txttotal_letras.Text = registro["Total_Letras"].ToString();
                    cmbestado.Text = registro["Estado_operacion"].ToString();
                    cmbcargue.Text = registro["Estado_cargue"].ToString();
                    dtpcargue.Text = registro["Fecha_Cargue"].ToString();
                    dtpproximo.Text = registro["Proximo_Cargue"].ToString();
                    dtpfecha_desembolso.Text = registro["Fecha_desembolso"].ToString();                    
                    cmbresultado.Text = registro["Respuesta_Cargue"].ToString();
                    cmbrechazo.Text = registro["Causal_Rechazo"].ToString();
                    Txtplano_dia.Text = registro["Plano_Dia"].ToString();
                    Txtplano_pre.Text = registro["Plano_Pre"].ToString();
                    Txtcomentarios.Text = registro["Comentarios"].ToString();
                    TxtIDfuncionario.Text = registro["Id_Funcionario"].ToString();
                    TxtNomFuncionario.Text = registro["Nombre_Funcionario"].ToString();          
                    con.Close();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);   
                MessageBox.Show("Caso no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }

        }

        public void total_cargue(TextBox Txtcedula, TextBox TxtCargues)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("total_cargues", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_cedula", Txtcedula.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtCargues.Text = registro[0].ToString();
                    con.Close();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }

        }

        public void historico_colp(TextBox Txtradicado, TextBox Txtcedula, TextBox Txtnombre, TextBox TxtEstado_cliente, TextBox Txtafiliacion1, TextBox Txtafiliacion2,
                                   TextBox Txttotal_recaudo, TextBox Txtscoring, ComboBox cmbfuerza, TextBox Txtmonto, TextBox Txtplazo, TextBox Txtcuota, TextBox Txttotal,
                                   TextBox Txtpagare, TextBox Txtnit, TextBox Txtentidad, TextBox Txtcuota_letras, TextBox Txttotal_letras, ComboBox cmbestado, ComboBox cmbcargue,
                                   DateTimePicker dtpcargue, DateTimePicker dtpproximo, DateTimePicker dtpfecha_desembolso, ComboBox cmbresultado, ComboBox cmbrechazo, TextBox Txtplano_dia,
                                   TextBox Txtplano_pre, TextBox Txtcomentarios, TextBox TxtIDfuncionario, TextBox TxtNomFuncionario)
        {

            con.Open();
            MySqlCommand cmd = new MySqlCommand("historico_colp", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente 
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Cliente", Txtnombre.Text);
                cmd.Parameters.AddWithValue("@_Estado_Cliente", TxtEstado_cliente.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion1", Txtafiliacion1.Text);
                cmd.Parameters.AddWithValue("@_N_Afiliacion2", Txtafiliacion2.Text);
                cmd.Parameters.AddWithValue("@_Recaudo", Txttotal_recaudo.Text);
                cmd.Parameters.AddWithValue("@_Scoring", Txtscoring.Text);
                cmd.Parameters.AddWithValue("@_Fuerza_Venta", cmbfuerza.Text);
                cmd.Parameters.AddWithValue("@_Monto_Aprobado", Txtmonto.Text);
                cmd.Parameters.AddWithValue("@_Plazo_Aprobado", Txtplazo.Text);
                cmd.Parameters.AddWithValue("@_Cuota", Txtcuota.Text);
                cmd.Parameters.AddWithValue("@_Total", Txttotal.Text);
                cmd.Parameters.AddWithValue("@_Pagare", Txtpagare.Text);
                cmd.Parameters.AddWithValue("@_Nit", Txtnit.Text);
                cmd.Parameters.AddWithValue("@_Entidades", Txtentidad.Text);
                cmd.Parameters.AddWithValue("@_Cuota_Letras", Txtcuota_letras.Text);
                cmd.Parameters.AddWithValue("@_Total_Letras", Txttotal_letras.Text);
                cmd.Parameters.AddWithValue("@_Estado_operacion", cmbestado.Text);
                cmd.Parameters.AddWithValue("@_Estado_cargue", cmbcargue.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtpcargue.Text);
                cmd.Parameters.AddWithValue("@_Proximo_Cargue", dtpproximo.Text);
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtpfecha_desembolso.Text);
                cmd.Parameters.AddWithValue("@_Respuesta_Cargue", cmbresultado.Text);
                cmd.Parameters.AddWithValue("@_Causal_Rechazo", cmbrechazo.Text);
                cmd.Parameters.AddWithValue("@_Plano_Dia", Txtplano_dia.Text);
                cmd.Parameters.AddWithValue("@_Plano_Pre", Txtplano_pre.Text);
                cmd.Parameters.AddWithValue("@_Comentarios", Txtcomentarios.Text);
                cmd.Parameters.AddWithValue("@_Id_Funcionario", TxtIDfuncionario.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", TxtNomFuncionario.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();

            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("Se encontró una excepción de tipo" + ex.GetType() +
                                                      " al intentar revertir la transacción..");
                    }
                }
                Console.WriteLine("Se encontró una excepción de tipo " + e.GetType() +
                                              " al insertar los datos.");
                Console.WriteLine("Ninguno de los registros se escribió en la base de datos.");
            }
            finally
            {
                con.Close();
            }

        }

        public void total_negadas(Label lbtotal_negados)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("total_negadas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    lbtotal_negados.Text = registro[0].ToString();
                    con.Close();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Caso no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }

        }

        public void total_pendientes(Label lbtotal_rta)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("total_pendientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@_Radicado", Txtradicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    lbtotal_rta.Text = registro[0].ToString();
                    con.Close();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Caso no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }

        }

        public void buscar_negados(DateTimePicker dtpfecha, DataGridView dataGridView2)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("buscar_cargue", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Proximo_Cargue", dtpfecha.Text);
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


        public void contabilizados_altas(DateTimePicker dtp_cargue, DataGridView dgv_altas)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("contabilizados_altas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtp_cargue.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_altas.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("No hay operaciones desembolsadas para cargar el dia seleccionado", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }
        }

        public void contabilizados_bajas(DateTimePicker dtp_cargue, DataGridView dgv_bajas)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("contabilizados_bajas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtp_cargue.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgv_bajas.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("No hay operaciones desembolsadas para cargar el dia seleccionado", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }
        }

        public void pendiente_cargue(DateTimePicker dtp_cargue, DataGridView dgvresultado)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("pendiente_cargue", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Cargue", dtp_cargue.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvresultado.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("No hay operaciones desembolsadas para cargar el dia seleccionado", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }
        }

        public void pendiente_respuesta(DataGridView dataGridView1)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("pendientes_respuesta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@_proximo_cargue", dtp_proximo_cargue.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dataGridView1.DataSource = dt;
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

        public void cargues_cliente(TextBox Txtafiliacion2, TextBox TxtCargues)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand("SELECT COUNT(*) FROM historico_colp WHERE N_Afiliacion2 = @N_Afiliacion2 ", con);
                comando.Parameters.AddWithValue("@N_Afiliacion2", Txtafiliacion2.Text);
                con.Open();
                MySqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    TxtCargues.Text = registro[0].ToString();
                }
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

        public void recaudo(TextBox Txtafiliacion2, TextBox Txttotal_Recaudo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand("SELECT COUNT(*) FROM recaudos_colp WHERE Afiliacion = @Afiliacion ", con);
                comando.Parameters.AddWithValue("@Afiliacion", Txtafiliacion2.Text);
                con.Open();
                MySqlDataReader registro = comando.ExecuteReader();

                if (registro.Read())
                {
                    Txttotal_Recaudo.Text = registro[0].ToString();
                
                }
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

        public void buscar_fallecido(TextBox Txtcedula, TextBox TxtEstado_cliente)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_fallecido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Cedula", Txtcedula.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtEstado_cliente.Text = "Fallecido";
                    con.Close();
                }
                else
                {
                    TxtEstado_cliente.Text = "Activo";
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");

            }

        }
    }
}
