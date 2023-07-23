using HomieCore.Models;
using ErrorOr;
using HomieCore.ServiceErrors;
namespace HomieCore.Services.Groups;

public class GroupService : IGroupService
{
    private readonly HomieCore.Data.DataContext _dataContext;
    public GroupService(HomieCore.Data.DataContext dataContext){
        _dataContext = dataContext;
    }
  public async Task<ErrorOr<Created>> CreateGroup(HomieCore.Data.Group group)
    {
        _dataContext.Groups.Add(group);
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Created;
        } else {
            return Error.Failure("General.Failure");
        }
    }
   public ErrorOr<HomieCore.Data.Group> GetGroup(int id)
    {
        HomieCore.Data.Group? groupData = _dataContext.Groups.Where(x => x.Id == id).FirstOrDefault();
        return groupData ?? (ErrorOr<Data.Group>)Errors.Group.NotFound;
    }
     public List<HomieCore.Data.Group> GetAllGroup()
    {
        var groupData = _dataContext.Groups.ToList();
        return groupData;
    }
      public async Task<ErrorOr<Deleted>> DeleteGroup(int id){
        //TODO: remove task from group that they are in.
        _dataContext.Remove(_dataContext.Groups.Single(t=> t.Id ==id));
        int changes = await _dataContext.SaveChangesAsync();
        if (changes>0){
            return Result.Deleted;
        } else {
            return Error.Failure("General.Failure");
        }
    }
   public async Task<ErrorOr<UpsertedGroup>> UpsertGroup(HomieCore.Data.Group group)
    {
        HomieCore.Data.Group? groupExists = await _dataContext.Groups.FindAsync(group.Id);
        if (groupExists!=null){
            groupExists.GroupDescription= group.GroupDescription;
            groupExists.GroupName = group.GroupName;
            groupExists.LastModifiedTime= DateTime.UtcNow;
            int changes = await _dataContext.SaveChangesAsync();
            if (changes>0){
                return new UpsertedGroup(false);
            } else {
                return Error.Failure("General.Failure");
            }
        } else {
            _dataContext.Groups.Add(group);
            int changes = await _dataContext.SaveChangesAsync();
             if (changes>0){
                return new UpsertedGroup(true);
            } else {
                return Error.Failure("General.Failure");
            }
        }
    }
}