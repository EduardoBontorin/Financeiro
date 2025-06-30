using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Local
{
    public class UpdateLocalRequest : BaseRequest
    {
        [Required(ErrorMessage = "Código local inválido")]
        [MaxLength(255, ErrorMessage = "Código local inválido")]
        public long CodigoLocal { get; set; }

        [Required(ErrorMessage = "Local de apontamento inválido")]
        [MaxLength(255, ErrorMessage = "Local de apontamento inválido")]
        public string LocalDeApontamento { get; set; }
    }
}
