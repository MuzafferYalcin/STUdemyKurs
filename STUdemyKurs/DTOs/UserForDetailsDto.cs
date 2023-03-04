using STUdemyKurs.Models;

namespace STUdemyKurs.DTOs
{
    public class UserForDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public List<Image> Images  { get; set; }
    }
}
