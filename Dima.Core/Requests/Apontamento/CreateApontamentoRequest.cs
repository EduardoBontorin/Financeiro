using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Apontamento
{
    public class CreateApontamentoRequest : BaseRequest
    {
        public DateTime DataDeApontamento { get; set; }

        [Required(ErrorMessage = "Ordem de produção inválida")]
        [MaxLength(255, ErrorMessage = "Ordem de produção inválida")]
        public string OrdemDeProducao { get; set; } = string.Empty;
        [Required(ErrorMessage = "Local inválido")]
        [MaxLength(255, ErrorMessage = "Local inválido")]
        public long LocalId { get; set; }

    }
}
