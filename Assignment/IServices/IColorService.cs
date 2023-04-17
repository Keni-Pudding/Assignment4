using Assignment.Models;

namespace Assignment.IServices
{
    public interface IColorService
    {
        public bool CreateColor(Color cl);
        public bool UpdateColor(Color cl);
        public bool DeleteColor(Guid id);

        public List<Color> GetAllColor();
        public Color GetColorById(Guid id);
    }
}
