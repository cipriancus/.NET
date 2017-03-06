using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;


namespace onlineGrades.Core.Repository_Interfaces
{
    public interface ICategorieRepository:IGenericRepository<Categorie>
    {
        Categorie getCategoryById(Guid id);
        void IsertNewCategory(Categorie categorie);
    }
}
