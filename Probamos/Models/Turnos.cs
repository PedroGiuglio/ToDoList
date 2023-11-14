using System;
using System.ComponentModel.DataAnnotations;

namespace Probamos.Models
{
    public class Turnos
    {
        [Key]
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdProfesional { get; set; }
        public string Dia { get; set; }
        public TimeSpan Horario { get; set; }
    }
}
