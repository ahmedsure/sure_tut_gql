using GQLDEMOTUT.Entities;

namespace GQLDEMOTUT.GQL.Queries;
public partial class GQLQuery
{

    [UseDbContext(typeof(AppDbContext))]
    // allow to query a child object
    [UsePaging(MaxPageSize = 1000, IncludeTotalCount = true, DefaultPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Post> GetPosts([ScopedService] AppDbContext _ctox)
    {
        return _ctox.Posts;
    }

}