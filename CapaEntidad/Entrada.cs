using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entrada
    {
        public int idEntrada { get; set; }
        public int idInventario { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
    }
}
