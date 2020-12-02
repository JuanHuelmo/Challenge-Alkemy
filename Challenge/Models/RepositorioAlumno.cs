using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Challenge.Models;

public class RepositorioAlumno
    {
        public Alumno LoginAlumno(string UserName, string Password)
        {
            Alumno u = null;
            using (Context c = new Context())
            {
                u = c.Alumnos.Where(d => d.UserName == UserName && d.Password == Password).SingleOrDefault();
                return u;
            }
        }

        public bool Inscribirse(int idMateria, int idAlmuno)
        {
            bool retorno = false;

            using (Context c = new Context())
            {


               
                try
                {
                    Materia m = c.Materias.Where(i => i.Id == idMateria).SingleOrDefault();

                    Alumno alu = c.Alumnos.Where(a => a.id == idAlmuno).SingleOrDefault();
                    if (m.Inscriptos < m.Quota)
                    {
                        m.Inscriptos = m.Inscriptos + 1;
                        c.Entry(m).State = EntityState.Modified;
                        alu.Materias.Add(m);
                        c.SaveChanges();
                        return true;
                    }
                }
                catch
                {

                    return false;
                }




            }


            return retorno;
        }





    
          public bool EliminarInscripcion(int idMateria, int idAlmuno)
    {
        bool retorno = false;

        using (Context c = new Context())
        {



            try
            {

               

                Materia m = c.Materias.Where(i => i.Id == idMateria).SingleOrDefault();

                Alumno alu = c.Alumnos.Where(a => a.id == idAlmuno).SingleOrDefault();
                if (m.Inscriptos < m.Quota)
                {
                    m.Inscriptos = m.Inscriptos - 1;
                    c.Entry(m).State = EntityState.Modified;
                    alu.Materias.Remove(m);
                    c.SaveChanges();
                    return true;
                }
            }
            catch
            {

                return false;
            }




        }


        return retorno;
    }



    public List<Materia> ListaMateriasInscripto(int idAlumno)
        {
            List<Materia> lista = new List<Materia>();

            using (Context c = new Context())
            {

            

                    Alumno alu = (Alumno)c.Alumnos.Where(a => a.id == idAlumno).SingleOrDefault();
                 

                lista = alu.Materias.ToList();
               


            }


            return lista;
        }


        

    }
