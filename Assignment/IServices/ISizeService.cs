using Assignment.Models;

namespace Assignment.IServices
{
    public interface ISizeService
    {
        public bool CreateSize(Size sz);
        public bool UpdateSize(Size sz);
        public bool DeleteSize(Guid id);

        public List<Size> GetAllSize();
        public Size GetSizeById(Guid id);
    }
}
