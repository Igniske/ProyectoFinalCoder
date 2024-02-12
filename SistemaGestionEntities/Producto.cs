using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Producto
    {
        private int _id;
        private string _descripcion;
        private double _costo;
        private double _precioVenta;
        private int _stock;
        private int _idUsuario;

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
