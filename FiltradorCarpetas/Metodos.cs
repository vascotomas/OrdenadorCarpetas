using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiltradorCarpetas
{
    public class Metodos
    {


        public static List<Extensiones> listaExtensiones(string ext1, string ext2 = "", string ext3 = "")
        {
            List<Extensiones> listaExtensionesFotos = new List<Extensiones>();
            listaExtensionesFotos.Add(new Extensiones(ext1, ""));
            listaExtensionesFotos.Add(new Extensiones(ext2, ""));
            listaExtensionesFotos.Add(new Extensiones(ext3, ""));
            return listaExtensionesFotos;
        }

        public static List<string[]> recolectorRutas(List<Extensiones> listaExtensionesArchivos, string ruta)
        {
            List<string[]> array = new List<string[]>();


            foreach (Extensiones extensionArchivo in listaExtensionesArchivos)
            {
                array.Add(Directory.GetFiles(ruta, extensionArchivo.extension));
            }
            return array;
        }

        public static void movedorArchivos(List<string[]> arrayArcExt, string ruta)
        {

            System.IO.Directory.CreateDirectory(ruta);

            foreach (string[] array in arrayArcExt)
            {
                foreach (var archivo in array)
                {
                    File.Move(archivo, Path.Combine(ruta, Path.GetFileName(archivo)));

                }
            }

            MessageBox.Show("Filtrado Correcto", "Successful");
        }


    }
}
