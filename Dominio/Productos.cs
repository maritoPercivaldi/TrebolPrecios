using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Productos
    {
        public string productoId { get; set; }
        public string descrip { get; set; }
        public string descripad { get; set; }
        public string descreduc { get; set; }
        public decimal precioUltimaCompra { get; set; }
        public string moneda { get; set; }
        public DateTime fechaUltimaCompra { get; set; }
    }
}
