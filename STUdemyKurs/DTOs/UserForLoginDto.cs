using System.ComponentModel.DataAnnotations;

namespace STUdemyKurs.DTOs
{
    public class UserForLoginDto
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
