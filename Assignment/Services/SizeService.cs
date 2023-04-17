using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class SizeService : ISizeService
    {
        AssDbContext context = new AssDbContext();
        public bool CreateSize(Size sz)
        {
            try
            {
                context.Sizes.Add(sz);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                var size = context.Sizes.Find(id);
                context.Sizes.Remove(size);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Size> GetAllSize()
        {
            return context.Sizes.ToList();
        }

        public Size GetSizeById(Guid id)
        {
            return context.Sizes.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateSize(Size sz)
        {
            try
            {
                var size = context.Sizes.Find(sz.Id);
                size.NameSize= sz.NameSize;
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
