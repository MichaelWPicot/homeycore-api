using HomieCore.Models;
using ErrorOr;

namespace HomieCore.Services.Users;

public interface IUserService
{
    ErrorOr<Created> CreateUser(User user);
    ErrorOr<User> GetUser(Guid id);
    ErrorOr<Deleted> DeleteUser(Guid id);
    ErrorOr<UpsertedUser> UpsertUser(User user);
}