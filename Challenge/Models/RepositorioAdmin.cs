using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Challenge.Models;

namespace Challenge.Models
{
    public class RepositorioAdmin
    {



        public admin LoginAdmin(string UserName, string Password)
        {
            admin u = null;
            using (Context c = new Context())
            {
            
                u = c.Admins.Where(d => d.UserName == UserName && d.Password == Password).SingleOrDefault();
                return u;
            }
        }



       



        public bool AltaMateria(Materia m,int idDocente)
        {
            bool retorno = false;

            using (Context c = new Context())
            {

                try
                {   c.Materias.Add(m);
                    m.Professor = c.Profesores.Where(p => p.id == idDocente).SingleOrDefault();
                    if (m.Professor != null)
                    {
                        c.SaveChanges();
                        retorno = true;
                        return retorno;
                    }
                    
                }
                catch
                {
                    throw;
                    
                    
                }

                return retorno;

            }

        }
//1==s2 returns 0  
//s1>s2 returns 1  
//s1<s2 returns -1 


        public bool ModificarMateria(Materia m)
        {
            bool retorno = false;

            using (Context c = new Context())
            {

                try
                {

                    
                    c.Entry(m).State = System.Data.Entity.EntityState.Modified;
                    c.SaveChanges();
                    retorno = true;
                    return retorno;
                }
                catch
                {
                    return retorno;
                }



            }

        }


        public Materia BuscarMateriaPorId(int id)
        {
            Materia m;

            using (Context c = new Context())
            {
                 m = c.Materias.Where(mat => mat.Id == id).SingleOrDefault();

            }


            return m;
        }

        public List<Materia> ListaMateria(int? idAlumno)
        {
            List<Materia> lista = new List<Materia>();

            using (Context c = new Context())
            {
                if (idAlumno != null)
                {
                    Alumno alu = (Alumno)c.Alumnos.Where(a => a.id == idAlumno).SingleOrDefault();
                    var aux = alu.Materias.Select(x => x.Id).ToArray();

                    lista = c.Materias.Where(m => !aux.Contains(m.Id)).OrderBy(m => m.Name).ToList();
                }
                else {
                    lista = c.Materias.OrderBy(m => m.Name).ToList();
                }


            }


            return lista;
        }













        public bool AltaAlumno(Alumno a)
        {
            bool retorno = false;

            using (Context c = new Context())
            {

                try
                {


                    Persona per = c.AlumnosDocentes.Where(x => x.Dni ==a.Dni ).SingleOrDefault();
                    Alumno al = c.Alumnos.Where(z => z.UserName == a.UserName).SingleOrDefault();
                    if (per == null && al == null)
                    {
                    
                        c.Alumnos.Add(a);
                        c.SaveChanges();
                        retorno = true;
                        return retorno;
                    }
                }
                catch
                {
                    return retorno;
                }



            }
            return retorno;
        }




        public bool AltaProfesor(Profesor p ) {
            bool retorno = false;

            using (Context c = new Context()) {

                try { 


                   Persona per = c.AlumnosDocentes.Where(x => x.Dni == p.Dni ).SingleOrDefault();
                if (per == null) {
                    c.Profesores.Add(p);
                    c.SaveChanges();
                    retorno = true;
                    return retorno;
                }
                }
                catch {
                    return retorno;
                }
                
              

            }
            return retorno;
        }


        public bool ModificarProfesor(Profesor p)
        {
            bool retorno = false;

            using (Context c = new Context())
            {

                try
                {
                  

                    c.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    c.SaveChanges();
                    retorno = true;
                    return retorno;
                }
                catch
                {
                    return retorno;
                }



            }

        }


        public Profesor BuscarProfesorPorId(int id)
        {
            Profesor p;

            using (Context c = new Context())
            {
                p =
                p = c.Profesores.Where(prof => prof.id == id).SingleOrDefault();

            }


            return p;
        }


        public List<Profesor> ListaProfesores()
        {
            List<Profesor> lista = new List<Profesor>();

            using (Context c = new Context())
            {
                lista = c.Profesores.ToList();

            }


            return lista;
        }


        public List<Profesor> ListaProfesoresActivos()
        {
            List<Profesor> lista = new List<Profesor>();

            using (Context c = new Context())
            {
                lista = c.Profesores.Where(p=> p.Active == true).ToList();

            }


            return lista;
        }









    }


    


}

