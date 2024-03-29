﻿using GQLDEMOTUT.Entities;

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

    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [Serial]
    public async Task<GQLUser?> GetUser([ScopedService] AppDbContext _ctox , Guid userId)
    {
        var found = await _ctox.GQLUsers.FindAsync(userId);
        return found;
    }

}
