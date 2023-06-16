using HomieCore.Models;
using ErrorOr;
using HomieCore.ServiceErrors;
namespace HomieCore.Services.Users;

public class UserService : IUserService
{
    private static readonly Dictionary<Guid, User> _users = new();
    public ErrorOr<Created> CreateUser(User user)
    {
        _users.Add(user.Id, user);

        return Result.Created;
    }
    public ErrorOr<User> GetUser(Guid id)
    {
        if(_users.TryGetValue(id, out var user))
        {
            return user;
        }
       return Errors.User.NotFound;
    }
    public ErrorOr<Deleted> DeleteUser(Guid id){
        //TODO: remove user from all groups that they are in.
        _users.Remove(id);
        return Result.Deleted;
    }
    public ErrorOr<UpsertedUser> UpsertUser(User user)
    {
        var IsNewUser = !_users.ContainsKey(user.Id);
        _users[user.Id]= user;
        return new UpsertedUser(IsNewUser);
    }
}