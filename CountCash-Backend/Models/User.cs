using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountCash_Backend.Models
{
    public class User
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}
