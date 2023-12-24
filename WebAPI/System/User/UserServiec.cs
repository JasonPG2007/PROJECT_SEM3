using ObjectBussiness;

namespace WebAPI.System.User
{
    public class UserServiec : IUserSeviec
    {
        public Task<bool> Authencate(Account request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(ExamRegister request)
        {
            throw new NotImplementedException();
        }
    }
}
