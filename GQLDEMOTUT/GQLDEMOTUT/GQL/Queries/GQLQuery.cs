﻿using GQLDEMOTUT.Entities;

namespace GQLDEMOTUT.GQL.Queries;
public partial class GQLQuery
{
    // service ATTR is coming from chocolate to inject // here supports method injections
    // this attr also for the pooled db context multi threading / concurrent queries
    [UseDbContext(typeof(AppDbContext))]
    // allow to query a child object
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<GQLUser> GetUsers([ScopedService] AppDbContext _ctox)
    {
        return _ctox.GQLUsers;
    }

}