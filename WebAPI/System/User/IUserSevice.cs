using ObjectBussiness;

namespace WebAPI.System.User
{
    public interface IUserSevice
    {
        Task<bool> Authencate(ExamRegister request);
        Task<bool> Register(ExamRegister request);
    }
}
