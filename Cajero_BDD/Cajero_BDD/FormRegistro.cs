using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibreria;


namespace Cajero_BDD
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("EXEC proc_RegistrarUsuario'{0}','{1}','{2}','{3}'", txtNombre.Text.Trim(), txtApellidos.Text.Trim(), txtClave.Text.Trim(), txtMonto.Text.Trim());
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Usuario Guardado con éxito!");
                //return true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error" + error.Message);
                //return false;
            }
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
   
