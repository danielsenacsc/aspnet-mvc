using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DesafioCap4.Models
{
    public class Matricula
    {
        [Key]
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int AlunoId { get; set; }
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }
    }
}