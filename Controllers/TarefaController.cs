using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefas.Context;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    public class TarefaController: Controller
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var asynctarefas = await _context.Tarefas.OrderBy(x => x.DataInicio).AsNoTracking().ToListAsync();
            return View(asynctarefas);
        }
        public IActionResult NovaTarefa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovaTarefa(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                await _context.Tarefas.AddAsync(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if(tarefa.DataInicio == DateTime.MinValue)
            {
                return BadRequest("A data não pode ser vazia");
            }
            return View(tarefa);
        }

        public async Task<IActionResult> EditarTarefa(int id)
        {
            var asynctarefa = await _context.Tarefas.FindAsync(id);
            if(asynctarefa == null)
            {
                return NotFound("Item não existe");
            }
            return View(asynctarefa);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarefa(Tarefa tarefa)
        {
            var asyncTarefaBanco = await _context.Tarefas.FindAsync(tarefa.Id);
            asyncTarefaBanco.Titulo = tarefa.Titulo;
            asyncTarefaBanco.Descricao = tarefa.Descricao;
            asyncTarefaBanco.Status = tarefa.Status;
            asyncTarefaBanco.DataInicio = tarefa.DataInicio;
            asyncTarefaBanco.DataConclusao = tarefa.DataConclusao;

            _context.Update(asyncTarefaBanco);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DetalhesTarefa(int id)
        {
            var asynctarefa = await _context.Tarefas.FindAsync(id);
            if(asynctarefa == null)
            {
                return NotFound("Item não existe");
            }
            return View(asynctarefa);
        }

        public async Task<IActionResult> DeletarTarefa(int id)
        {
            var asynctarefa = await _context.Tarefas.FindAsync(id);
            if (asynctarefa == null)
                return NotFound("Item não existe");
            return View(asynctarefa);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarTarefa(Tarefa tarefa)
        {
            var asynctarefaBanco = await _context.Tarefas.FindAsync(tarefa.Id);
            _context.Remove(asynctarefaBanco);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Concluidas()
        {
            var asynctarefas = await _context.Tarefas.Where(x => x.Status.Equals(EnumStatus.Concluido)).OrderBy(x => x.DataConclusao).AsNoTracking().ToListAsync();
            return View(asynctarefas);
        }

        public async Task<IActionResult> Pendentes()
        {
            var asynctarefas =  await _context.Tarefas.Where(x => x.Status.Equals(EnumStatus.Pendente)).OrderBy(x => x.DataInicio).AsNoTracking().ToListAsync();
            return View(asynctarefas);
        }

        public async Task<IActionResult> EmAndamento()
        {
            var asyncTarefas = await _context.Tarefas.Where(x => x.Status.Equals(EnumStatus.Em_Andamento)).OrderBy(x => x.DataInicio).AsNoTracking().ToListAsync();
            return View(asyncTarefas);
        }
    }
}