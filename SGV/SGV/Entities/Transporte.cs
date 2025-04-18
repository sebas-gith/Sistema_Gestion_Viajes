using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Entities
{
    public class Transporte
    {
        public int TransporteId { get; set; }
        public string Tipo { get; set; }
        public string Empresa { get; set; }
        public string Numero { get; set; }
        public string Capacidad { get; set; }
    }
}
