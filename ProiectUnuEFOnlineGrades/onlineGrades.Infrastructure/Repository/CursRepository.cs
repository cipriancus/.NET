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
    //testat ok
    public class CursRepository : GenericRepositoryAbstract<DataBaseManagement, Curs>,ICursRepository
    {
        public override void Add(Curs entity)
        {
            _entities.Cursuri.Add(entity);
            attach(entity);
        }

        public override void Edit(Curs entity)
        {
            base.Edit(entity);
            attach(entity);
        }

        private void attach(Curs entity)
        {
            foreach(Student iterator in entity.Student)
            {
                _entities.Studenti.Attach(iterator);
                foreach(Nota it in iterator.Nota)
                {
                    _entities.Categorii.Attach(it.Categorie);
                    _entities.Studenti.Attach(it.Student);
                    _entities.Note.Attach(it);
                }

                foreach (Curs it in iterator.Curs)
                {
                    _entities.Cursuri.Attach(it);

                }

            }

            foreach (Profesor iterator in entity.Profesor)
            {
                _entities.Profesori.Attach(iterator);

                foreach (Curs it in iterator.Curs)
                {
                    _entities.Cursuri.Attach(it);
                }
            }
        }

        public Curs getCursById(Guid id)
        {
            return FindBy(e => e.CursId == id).FirstOrDefault();
        }

        public void InsertNewCurs(Curs curs)
        {
            Add(curs);
            Save();
        }
    }
}
