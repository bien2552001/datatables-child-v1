using System.ComponentModel.DataAnnotations;

namespace demo1.chapter10.model.userDto
{
    public class LoginRequestDto
    {

        [Required, EmailAddress]
        public string Email { get; set; }



        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
