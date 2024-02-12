using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductoVendido
    {
        private int _id;
        private int _idProducto;
        private int _stock;
        private int _idVenta;

        public int Id { get; set; }
        public int IdProducto { get; set; }

        public int Stock { get; set; }

        public int IdVenta { get; set; }
    }
}
