using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Models
{
    public class Apontamento
    {
        public long Id { get; set; }
        public DateTime DataApontamento { get; set; } = DateTime.Now;
        public string OrdemDeProducao { get; set; } = string.Empty;
        public long LocalId { get; set; }
        public Local Local { get; set; } = null!;
        public string Usuario { get; set; } = string.Empty;
    }
}
