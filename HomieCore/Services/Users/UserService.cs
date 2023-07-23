using HomieCore.Models;
using ErrorOr;
using HomieCore.ServiceErrors;
namespace HomieCore.Services.Users;

public class UserService : IUserService
{
      private readonly HomieCore.Data.DataContext _dataContext;
     public UserService(HomieCore.Data.DataContext dataContext){
        _dataContext = dataContext;
    }
    public async Task<ErrorOr<Created>> CreateUser(HomieCore.Data.User user)
    {
        _dataContext.Users.Add(user);
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Created;
        } else {
            return Error.Failure("General.Failure");
        }
    }
    public ErrorOr<HomieCore.Data.User> GetUser(int id)
    {
        HomieCore.Data.User? userData = _dataContext.Users.Where(x => x.Id == id).FirstOrDefault();
        return userData ?? (ErrorOr<Data.User>)Errors.User.NotFound;
    }
     public List<HomieCore.Data.User> GetAllUser()
    {
        var userData = _dataContext.Users.ToList();
        return userData;
    }
    public async Task<ErrorOr<Deleted>> DeleteUser(int id){
        //TODO: remove user from group that they are in.
        _dataContext.Remove(_dataContext.Users.Single(t=> t.Id ==id));
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Deleted;
        } else {
            return Error.Failure("General.Failure");
        }
    }
    public async Task<ErrorOr<UpsertedUser>> UpsertUser(HomieCore.Data.User user)
    {
        HomieCore.Data.User? userExists = await _dataContext.Users.FindAsync(user.Id);
        if (userExists!=null){
            userExists.FirstName = user.FirstName;
            userExists.LastName = user.LastName;
            userExists.LastModifiedDateTime=DateTime.UtcNow;
            int changes = await _dataContext.SaveChangesAsync();
            if (changes>0){
                return new UpsertedUser(false);
            } else {
                return Error.Failure("General.Failure");
            }
        } else {
            _dataContext.Users.Add(user);
            int changes = await _dataContext.SaveChangesAsync();
             if (changes>0){
                return new UpsertedUser(true);
            } else {
                return Error.Failure("General.Failure");
            }
        }
    }
}