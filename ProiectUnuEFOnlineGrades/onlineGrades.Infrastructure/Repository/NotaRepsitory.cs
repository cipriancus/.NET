using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Repository_Interfaces.Generic_Repository;
using onlineGrades.Core.Entity;
using System.Data.Entity;
using onlineGrades.Core.Configuration.EF_Configuration;
using onlineGrades.Core.Repository_Interfaces;

//testat operatiile de add si edit
namespace onlineGrades.Infrastructure.Repository
{
    public class NotaRepsitory: GenericRepositoryAbstract<DataBaseManagement, Nota>,INotaRepository
    {
        public override void Add(Nota entity)
        {
            base.Add(entity);
            attach(entity);
        }
        public override void Edit(Nota entity)
        {
            base.Edit(entity);
            attach(entity);
        }

        private void attach(Nota entity)
        {
            _entities.Cursuri.Attach(entity.Curs);
            _entities.Categorii.Attach(entity.Categorie);
            _entities.Studenti.Attach(entity.Student);

        }

        public Nota getNotaById(Guid id)
        {
            return FindBy(e => e.NotaId == id).FirstOrDefault();
        }

        public void inserNewNota(Nota nota)
        {
            Add(nota);
            Save();
        }
    }
}
