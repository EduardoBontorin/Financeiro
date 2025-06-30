using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Models
{
    public class Local
    {
        public long Id { get; set; }
        public long CodigoLocal { get; set; } 
        public string LocalDeApontamento { get; set; } = string.Empty;
    }
}
