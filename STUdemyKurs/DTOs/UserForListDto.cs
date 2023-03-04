using STUdemyKurs.Models;

namespace STUdemyKurs.DTOs
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public Image Image { get; set; }

    }
}
