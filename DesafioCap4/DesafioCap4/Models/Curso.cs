using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCap4.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}