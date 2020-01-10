using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using MyLibreria;


namespace Cajero_BDD
{
    public partial class FormAtm : Form
    {
        public static string AuxPass = string.Empty;
        public static string SaldoCuenta = string.Empty;
        public static string Opcion = string.Empty;
        public FormAtm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source =LAPTOP-MUS3J725;Initial Catalog=CajeroAutomatico1;User ID=andrea;Password=andrea");
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormAtm_Load(object sender, EventArgs e)
        {

        }

        private void lbl0_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "0";
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "1";
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "2";
        }

        private void lbl3_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "3";
        }

        private void lbl4_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "4";
        }

        private void lbl5_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "5";
        }

        private void lbl6_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "6";
        }

        private void lbl7_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "7";
        }

        private void lbl8_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "8";
        }

        private void lbl9_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "0";
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            string lastChar = txtPassword.Text.Substring(0,txtPassword.Text.Length-1);
            txtPassword.Text = lastChar;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void logear(string contrasena)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from usuario Where claveUsuario = @claveUsuario", con);
                cmd.Parameters.AddWithValue("claveUsuario", contrasena);
               

                SqlDataReader reader = cmd.ExecuteReader();  //permite leer la fila a consultar
                if (reader.Read())
                {
                    AuxPass = reader["claveUsuario"].ToString(); //obtenemos la clave y usuario
                    SaldoCuenta = reader["saldo"].ToString();

                }
                else
                {
                    MessageBox.Show("Error de lectura de Base de Datos")
                }
                if (AuxPass == contrasena)  //verificacion de clave
                {
                    MessageBox.Show("Clave correcta");
                    tabControl1.SelectTab(1);
                }
                else
                {
                    MessageBox.Show("Clave Incorrecta");
                }
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                con.Close();
            }

        }


        private void lblEnter_Click(object sender, EventArgs e)
        {
            logear(this.txtPassword.Text);
            

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            //lblBalance.Text =; 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            txtPassword.Text = " ";
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            Opcion = "Retiro";
            //aux.text=property
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            withDraw(20);
        }

        private void withDraw(int cantidad)
        {
            int AuxSaldo = Int32.Parse(SaldoCuenta);
            int Saldo;

            if(Opcion=="Retiro")
            {
                if (AuxSaldo >= cantidad)
                {
                    Saldo = AuxSaldo - cantidad;
                    string cmd = string.Format("EXEC proc_retiro1'{0}','{1}','{2}'", cantidad, AuxPass, Saldo);
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Retiro realizado con éxito!");
                }
                else
                {
                    MessageBox.Show("No tiene fondos suficientes, Intente con otra cantidad");
                }
            }
            else if(Opcion=="Deposito")
            {
                if (AuxSaldo >= cantidad)
                {
                    Saldo = AuxSaldo + cantidad;
                    string cmd = string.Format("EXEC proc_deposito1'{0}','{1}','{2}'", cantidad, AuxPass, Saldo);
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Deposito realizado con éxito!");
                }
                else
                {
                    MessageBox.Show("No se pudo realizar el deposito");
                }
            }
            
        }

        private void btn40_Click(object sender, EventArgs e)
        {
            withDraw(40);
        }

        private void btn60_Click(object sender, EventArgs e)
        {
            withDraw(60);
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            withDraw(100);
        }

        private void btn300_Click(object sender, EventArgs e)
        {
            withDraw(300);
        }

        private void btnOtra_Click(object sender, EventArgs e)
        {
            string request = Microsoft.VisualBasic.Interaction.InputBox("Ingrese otra cantidad","Otra cantidad","0");
            int money = Int32.Parse(request);
            MessageBox.Show(""+money);
            withDraw(money);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDeposito_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            Opcion = "Deposito";
            //aux.text=property
        }
    }
}
