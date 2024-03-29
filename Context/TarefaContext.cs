using Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarefas.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options): base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
