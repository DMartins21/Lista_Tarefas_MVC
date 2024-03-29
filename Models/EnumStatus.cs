using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models
{
    public enum EnumStatus
    {
        [Display(Name = "Pendente")]
        Pendente,
        [Display(Name = "Em Andamento")]
        Em_Andamento,
        [Display(Name = "Concluido")]
        Concluido
    }
}
