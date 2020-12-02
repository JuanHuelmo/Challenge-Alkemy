using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Challenge.Models
{
        [Table("Subjects")]
    public class Materia
    {
        [Key,Index(IsUnique = true)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "debe ingresar formato HH:MM")]
        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "debe ingresar formato HH:MM")]
        public string TimeFrom { get; set; }

        [Required]
        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "debe ingresar formato HH:MM")]
        public string TimeTo { get; set; }
        public virtual  Profesor Professor { get; set; }
        [Required]
        public int Quota { get; set; }

        public int Inscriptos { get; set; }
       // [HiddenInput(DisplayValue = false)]
  
       public virtual List<Alumno> Inscripciones { get; set; }


        public Materia()
        {
            Inscripciones = new List<Alumno>();
            Inscriptos = 0;
        }



    }
}