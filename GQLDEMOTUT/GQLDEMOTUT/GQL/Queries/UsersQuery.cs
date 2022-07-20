using GQLDEMOTUT.Entities;

namespace GQLDEMOTUT.GQL.Queries;

[ExtendObjectType(typeof(GQLQuery))]
public partial class UsersQuery
{
    [UseDbContext(typeof(AppDbContext))]
    // allow to query a child object
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [Serial]
    public IQueryable<GQLUser> GetUsers([ScopedService] AppDbContext _ctox )
    {
         return (_ctox.GQLUsers);
    }

}
