using System.ComponentModel.DataAnnotations;

namespace demo1.chapter10.model.userDto
{
    public class RoleRequestDto
    {
        [Required(ErrorMessage = " Role is a required fiels")]
        public string Role { get; set; }
    }
}
