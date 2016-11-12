using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator4
{
    public class CategoryRepository
    {
        private readonly ProductManagement context;

        public CategoryRepository()
        {
            context = new ProductManagement();
        }
        public void CreateCategory(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }
        public void Update(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
        public void Detele(Category category)
        {
            context.Remove(category);
            context.SaveChanges();
        }
        public IEnumerable<Category> GetById(Guid Idd)
        {
            IEnumerable<Category> var = context.Categorii.Where(p => p.Id == Idd);
            return var;
        }
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> var = context.Categorii;
            return var;
        }
    }
}
