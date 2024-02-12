using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Usuario
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contrasenia;
        private string _mail;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Mail { get; set; }
    }
}
