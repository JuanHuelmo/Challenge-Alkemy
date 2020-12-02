using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models
{
    [Table("Student")]
    public  class Alumno : Persona
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
       public virtual List<Materia> Materias { get; set; }


        public Alumno()
        {

            Materias = new List<Materia>();
        }

    }

    



    }
