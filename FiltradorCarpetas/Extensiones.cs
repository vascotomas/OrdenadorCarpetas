using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltradorCarpetas
{
    public class Extensiones
    {
        public string extension;
        public string nombreArchivo;

        public Extensiones(string extension, string nombreArchivo)
        {
            this.extension = extension;
            this.nombreArchivo = nombreArchivo;
        }

        
    }
}
