using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        [DisplayName("Tarefa")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }
        [DisplayName("Data a ser Concluído")]
        public DateTime DataConclusao { get; set; }
        public EnumStatus Status { get; set; }

    }
}
