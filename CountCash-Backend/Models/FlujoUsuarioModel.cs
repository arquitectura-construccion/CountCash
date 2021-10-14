using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountCash_Backend.Models
{
    public class FlujoUsuarioModel
    {
        public int FlujoUsuarioID { get; set; }
        public int UsuarioID { get; set; }
        public int TipoMontoID { get; set; }
        public decimal Monto { get; set; }

        public string Descripcion { get; set; }

        public int TipoFlujoID { get; set; }

        public DateTime FechaRealizacion { get; set; }
    }
}
