using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Repository_Interfaces.Generic_Repository;
using onlineGrades.Core.Entity;
using System.Data.Entity;
using onlineGrades.Core.Configuration.EF_Configuration;
using onlineGrades.Core.Repository_Interfaces;

namespace onlineGrades.Infrastructure.Repository
{
    //testat si merge,
    public class CategorieRepository:GenericRepositoryAbstract<DataBaseManagement, Categorie>,ICategorieRepository
    {
        public Categorie getCategoryById(Guid id)
        {
            return FindBy(e => e.CategorieId == id).FirstOrDefault();
        }
        //cand inseram notele nu au cum sa existe
        public override void Add(Categorie entity)
        {
            _entities.Categorii.Add(entity);
            attach(entity);
        }

        public override void Edit(Categorie entity)
        {
            base.Edit(entity);
            attach(entity);
        }

        private void attach(Categorie entity)
        {
            foreach (Nota iterator2 in entity.Note)
            {
                _entities.Note.Attach(iterator2);
                _entities.Cursuri.Attach(iterator2.Curs);

                foreach (Student iterator3 in iterator2.Curs.Student)
                    {
                        _entities.Studenti.Attach(iterator3);

                        foreach (Nota it in iterator3.Nota)
                        {
                            _entities.Categorii.Attach(it.Categorie);
                            _entities.Studenti.Attach(it.Student);
                            _entities.Note.Attach(it);
                        }

                        foreach (Curs it in iterator3.Curs)
                        {
                            _entities.Cursuri.Attach(it);

                        }

                    }

                    foreach (Profesor iterator3 in iterator2.Curs.Profesor)
                    {
                        _entities.Profesori.Attach(iterator3);

                        foreach (Curs it in iterator3.Curs)
                        {
                            _entities.Cursuri.Attach(it);

                        foreach(Profesor it2 in it.Profesor)
                        {
                            _entities.Profesori.Attach(it2);
                        }

                    }
                }
                _entities.Studenti.Attach(iterator2.Student);
            }
        }

        public override IQueryable<Categorie> GetAll()
        {
            return GetAll();
        }

        public void IsertNewCategory(Categorie categorie)
        {
            Add(categorie);
            Save();
        }
    }
}
