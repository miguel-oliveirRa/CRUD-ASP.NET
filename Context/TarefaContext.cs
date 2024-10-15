using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext( DbContextOptions<TarefaContext> options ) : base(options)
        {}

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}