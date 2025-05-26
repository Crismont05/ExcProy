using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Existencia
    {
        public int idInvProd { get; }
        public int idInventario { get; set; }
        public int idProducto { get; set; }
        public int stock { get; set; }
    }
}
