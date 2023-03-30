using demo1.chapter10.model.userDto;
using System.Threading.Tasks;

namespace demo1.chapter10.Interface
{

    public interface ILogin_JWT
    {

        Task<bool> ValidateUser(LoginRequestDto loginRequest);
        Task<string> CreateToken();
    }

}
