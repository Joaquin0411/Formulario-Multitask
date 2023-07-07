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

namespace FormularioMultitarea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
            int numLineas = int.Parse(txtTexto.Text);

            
            StreamWriter escritor = new StreamWriter("archivodetextoformmultitask.txt");

           
            for (int i = 0; i < numLineas; i++)
            {
                Application.DoEvents();

                escritor.WriteLine("Línea " + (i + 1));

                
                pbProgreso.Value = (i + 1) * 100 / numLineas;
            }

            
            escritor.Close();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de texto|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        string texto = sr.ReadToEnd();
                        richTextBox1.Text = texto;
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
