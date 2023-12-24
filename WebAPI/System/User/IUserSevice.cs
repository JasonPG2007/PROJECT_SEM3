using ObjectBussiness;

namespace WebAPI.System.User
{
    public interface IUserSevice
    {
        Task<bool> Authencate(Account request);
        Task<bool> Register(ExamRegister request);
    }
}
