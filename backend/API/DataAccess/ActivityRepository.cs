using API.Domain;
using API.Utils.Optional;
using API.Utils.Result;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess;

public class ActivityRepository : IActivityRepository
{
    private readonly DataContext _dataContext;

    public ActivityRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Result<Activity>> AddActivity(Activity activity)
    {
        try
        {
            await _dataContext.AddAsync(activity);
            await _dataContext.SaveChangesAsync();
            return Result<Activity>.Success(activity, "The activity was added successfully.", Status.Created);
        }
        catch (DbUpdateException e)
        {
            return Result<Activity>.Error(e.Message, Status.Forbidden);
        }
    }

    public async Task<Optional<Activity>> GetActivityById(int activityId)
    {
        Activity? activity = await _dataContext.Activities.FirstOrDefaultAsync(a => a.Id == activityId);

        return activity == null ? Optional<Activity>.Empty() : Optional<Activity>.Of(activity);
    }

    public async Task<IEnumerable<Activity>> GetActivityByProjectId(int projectId) =>
        _dataContext.Activities.Where(a => a.Id == projectId);
}