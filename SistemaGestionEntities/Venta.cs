using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Venta
    {
        private int _id;
        private string _comentarios;
        private int _idUsuario;

        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

    }
}
