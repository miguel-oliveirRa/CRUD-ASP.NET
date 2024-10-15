using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Tarefa
    {
        public int Id { get; set;}
        public string Titulo { get; set;}
        public string Descricao { get; set;}
        public DateTime Data {get; set;} = DateTime.Now;
        public bool Status { get; set;}

        [NotMapped]
        public string DataFormatada => Data.ToString("dd/MMM/yyyy");
    }
}