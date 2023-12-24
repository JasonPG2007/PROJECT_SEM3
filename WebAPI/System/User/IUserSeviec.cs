using ObjectBussiness;

namespace WebAPI.System.User
{
    public interface IUserSeviec
    {
        Task<bool> Authencate(Account request);
        Task<bool> Register(ExamRegister request);
    }
}
