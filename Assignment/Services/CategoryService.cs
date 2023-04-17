using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class CategoryService : ICategoryService
    {
        AssDbContext context = new AssDbContext();
        public bool CreateCategory(Category ct)
        {
            try
            {
                context.Categories.Add(ct);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCategory(Guid id)
        {

            try
            {
                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Category> GetAllCategory()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryById(Guid id)
        {
            return context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateCategory(Category ct)
        {
            try
            {
                var category = context.Categories.Find(ct.Id);
                category.Name = ct.Name;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
