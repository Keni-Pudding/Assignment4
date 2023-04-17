using Assignment.Models;

namespace Assignment.IServices
{
    public interface ICategoryService
    {
        public bool CreateCategory(Category ct);
        public bool UpdateCategory(Category ct);
        public bool DeleteCategory(Guid id);

        public List<Category> GetAllCategory();
        public Category GetCategoryById(Guid id);
    }
}
