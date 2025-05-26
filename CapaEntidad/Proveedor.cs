using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
        public int idProveedor { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nombreORG { get; set; }
        public bool estado { get; set; }
    }
}
