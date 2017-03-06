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
            foreach (Nota iterator in entity.Note)
            {
                _entities.Note.Attach(iterator);
                _entities.Cursuri.Attach(iterator.Curs);
                _entities.Studenti.Attach(iterator.Student);
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
