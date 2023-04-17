using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class ColorService : IColorService
    {
        AssDbContext context = new AssDbContext();  
        public bool CreateColor(Color cl)
        {
            try
            {
                context.Colors.Add(cl);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                var color = context.Colors.Find(id);
                context.Colors.Remove(color);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Color> GetAllColor()
        {
            return context.Colors.ToList();
        }

        public Color GetColorById(Guid id)
        {
            return context.Colors.FirstOrDefault(p => p.ID == id);
        }

        public bool UpdateColor(Color cl)
        {

            try
            {
                var color = context.Colors.Find(cl.ID);
                color.NameColor = cl.NameColor;
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
