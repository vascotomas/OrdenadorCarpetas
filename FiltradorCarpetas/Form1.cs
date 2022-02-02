using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiltradorCarpetas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog().Equals(DialogResult.OK))
            {
                txtRuta.Text = fbd.SelectedPath;
                MessageBox.Show(fbd.SelectedPath);

            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (clbExtensiones.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecciona una extension a filtrar", "Alerta");
                return;
            }
            if (txtRuta.Text == "")
            {
                MessageBox.Show("Selecciona una ruta", "Alerta");
                return;
            }

            foreach (string clbitems in clbExtensiones.CheckedItems)
            {

                if (clbitems.ToString() == "Fotos")
                {
                    //FUNCION PARA OBTENER LISTA CON EXTENSIONES DE FOTOS(JPG,JPEG,PNG)
                    List<Extensiones> extensionesFotos = Metodos.listaExtensiones("*jpg", "*jpeg", "*png");

                    //FUNCION PARA OBTENER LISTA DE STRINGS[] CON RUTAS DE CADA EXTENSION, DIVIDIDO POR []
                    List<string[]> arrayFotos = Metodos.recolectorRutas(extensionesFotos, txtRuta.Text);

                    //METODO PARA MOVER ARCHIVOS
                    Metodos.movedorArchivos(arrayFotos, txtRuta.Text + "\\Fotos");
                }

                if (clbitems.ToString() == "Musica")
                {
                    List<Extensiones> extensionesMusica = Metodos.listaExtensiones("*mp3");

                    List<string[]> arrayMusica = Metodos.recolectorRutas(extensionesMusica, txtRuta.Text);

                    Metodos.movedorArchivos(arrayMusica, txtRuta.Text + "\\Musica");
                }

                if (clbitems.ToString() == "Docx")
                {
                    List<Extensiones> extensionesDocx = Metodos.listaExtensiones("*docx");

                    List<string[]> arrayDocx = Metodos.recolectorRutas(extensionesDocx, txtRuta.Text);

                    Metodos.movedorArchivos(arrayDocx, txtRuta.Text + "\\Documentos");
                }

                if (clbitems.ToString() == "Xlxs")
                {
                    List<Extensiones> extensionesXlxs = Metodos.listaExtensiones("*xlsx", "*xls");

                    List<string[]> arrayXlxs = Metodos.recolectorRutas(extensionesXlxs, txtRuta.Text);

                    Metodos.movedorArchivos(arrayXlxs, txtRuta.Text + "\\Excels");
                }


            }
        }
    }
}
