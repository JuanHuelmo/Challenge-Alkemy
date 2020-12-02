using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Challenge.Models
{
    public class Context :DbContext
    {
        public DbSet<admin> Admins { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Persona> AlumnosDocentes { get; set; }
        public Context() : base("MiConexion") {

        }
        
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .HasMany(b => b.Materias)
   .WithMany(c => c.Inscripciones)
   .Map(cs =>
   {
       cs.MapLeftKey("AlumnoId");
       cs.MapRightKey("MateriaId");
       cs.ToTable("Inscriptions");
   });







        }

     

}
}