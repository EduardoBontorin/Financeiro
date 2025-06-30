using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Apontamento
{
    public class UpdateApontamentoRequest : BaseRequest
    {
        public long Id { get; set; }
        public DateTime DataDeApontamento { get; set; }

        [Required(ErrorMessage = "Ordem de produção inválida")]
        [MaxLength(255, ErrorMessage = "Ordem de produção inválida")]
        public string OrdemDeProducao { get; set; } = string.Empty;
        [Required(ErrorMessage = "Local inválido")]
        [MaxLength(255, ErrorMessage = "Local inválido")]
        public string Local { get; set; } = string.Empty;
    }
}
