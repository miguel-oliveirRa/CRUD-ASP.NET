using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Microsoft.AspNetCore.Mvc;  
using Context;
using Models;

namespace Controllers
{
    public class TarefaController : Controller
    {

        private readonly TarefaContext _context;

        public TarefaController(TarefaContext tarefa)
        {
            _context = tarefa;
        }

        public IActionResult Index()
        {   
            var tarefas = _context.Tarefas.ToList();

            return View(tarefas);
        }


        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa NovaTarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(NovaTarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int Id)
        {
            var TarefaBanco = _context.Tarefas.Find(Id);

             if (TarefaBanco == null)
                return NotFound(); 

            return View("Editar", TarefaBanco);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var TarefaBanco = _context.Tarefas.Find(tarefa.Id);

             if (TarefaBanco == null)
                return NotFound();

            TarefaBanco.Titulo = tarefa.Titulo;
            TarefaBanco.Descricao = tarefa.Descricao;
            TarefaBanco.Status =    tarefa.Status;

            _context.Tarefas.Update(TarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int Id)
        {
            var tarefaBanco = _context.Tarefas.Find(Id);

            if (tarefaBanco == null)
                return NotFound();

            return View(tarefaBanco);
        }


        [HttpPost]
        public IActionResult Deletar(Tarefa TarefaRM)
        {
            var tarefaBnaco = _context.Tarefas.Find(TarefaRM.Id);

            if(tarefaBnaco == null)
                return NotFound();

            _context.Tarefas.Remove(tarefaBnaco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult ObterPorId(int Id)
        {
            var TarefaBanco = _context.Tarefas.Find(Id);

            if (TarefaBanco == null)
                return NotFound();

            return View("Filtros/ObterPorId", TarefaBanco);
        }

        public IActionResult ObterPorTitulo(string titulo)
        {   
            var TarefaBanco = _context.Tarefas.Where(x => x.Titulo == titulo);

            if (TarefaBanco == null)
                return NotFound();

            return View("Filtros/ObterPorTitulo", TarefaBanco);
        }
        public IActionResult ObterPorData(DateTime data)
        {   
            var TarefaBanco = _context.Tarefas.Where(x => x.Data.Date == data.Date);

            if (TarefaBanco == null)
                return NotFound();

            return View("Filtros/ObterPorData", TarefaBanco);
        }


        public IActionResult ObterPorStatus(bool status)
        {   
            var TarefaBanco = _context.Tarefas.Where(x => x.Status == status);

            if (TarefaBanco == null)
                return NotFound();

            return View("Filtros/ObterPorStatus", TarefaBanco);
        }

    }
}