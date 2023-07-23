using HomieCore.Models;
using ErrorOr;

namespace HomieCore.Services.Users;

public interface IUserService
{
    Task<ErrorOr<Created>> CreateUser(HomieCore.Data.User user);
    ErrorOr<HomieCore.Data.User> GetUser(int id);
    Task<ErrorOr<Deleted>> DeleteUser(int id);
    Task<ErrorOr<UpsertedUser>> UpsertUser(HomieCore.Data.User user);
    List<HomieCore.Data.User> GetAllUser();
}