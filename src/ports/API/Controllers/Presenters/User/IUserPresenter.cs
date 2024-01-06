using API.Controllers.Presenters.Request.User;
using API.Controllers.Presenters.Response.User;

namespace API.Controllers.Presenters.User
{
    /// <summary>
    /// Ge
    /// </summary>
    public interface IUserPresenter
    {
        Task SaveAsync(UserCreateAndUpdateRequest request);

        Task<AuthResponse> GetUserByEmail(AuthRequest request);
    }
}
