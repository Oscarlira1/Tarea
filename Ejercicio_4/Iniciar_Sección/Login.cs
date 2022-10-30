using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
namespace Iniciar_Sección
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void conectar_Click(object sender, EventArgs e)
        {
            if (usuario.Text == string.Empty){
                errorProvider1.SetError(usuario, "Ingrese un Usuario");
                usuario.Focus();
                return; 
            }
            errorProvider1.Clear();

            if (contraseña.Text == string.Empty)
            {
                errorProvider1.SetError(contraseña, "Ingrese un Contraseña");
                contraseña.Focus();
                return;
            }
            errorProvider1.Clear();

            UsuarioDatos datos = new UsuarioDatos();
            bool valido = await datos.LoginAsync(usuario.Text, contraseña.Text);

            if (valido)
            {
                Menu imagen = new Menu();
                Hide();
                imagen.Show();

            }
            else{
                MessageBox.Show("Se ha producido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
