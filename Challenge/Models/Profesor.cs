using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models
{
    [Table("Professor")]
    public class Profesor : Persona
    {


        public virtual List<Materia> Materias { get; set; }
    
    public bool Active { get; set; }



        public Profesor() {

            Materias = new List<Materia>();
        }
    }

}