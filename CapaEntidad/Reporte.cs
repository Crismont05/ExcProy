using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reporte
    {
       public string FechaVenta { get; set; }
       public string NombredelProducto { get; set; }
       public decimal precio { get; set; }
       public int cantidad { get; set; }
       public decimal total { get; set; }
    }
}
