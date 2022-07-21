using GQLDEMOTUT.Entities;
using GQLDEMOTUT.GQL.Subscriptions;
using HotChocolate.Subscriptions;

namespace GQLDEMOTUT.GQL.Mutations;
public partial class Mutations
{
    public record AddUserPostInput(Guid posterUser , string postContent);
    // adding platform
    [UseDbContext(typeof(AppDbContext))]
    public async Task<Post> AddUserPostAsync(
        AddUserPostInput input, [ScopedService] AppDbContext _ctx,
        // TODO For the subscribe and publish 
         [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken
        )
    {
        var user = await _ctx.GQLUsers.FindAsync(input.posterUser);
        Post newPost = new() { Id = Guid.NewGuid() ,
            PostContent =  input.postContent ,PostedBy = input.posterUser ,
            PostedOn = DateTime.Now ,
            PostOwner = user
        };
       var added = ( await _ctx.Posts.AddAsync(newPost, cancellationToken) ) .Entity;
        await _ctx.SaveChangesAsync(cancellationToken);
        // TODO  notify the subscribers 
        // Send notifications to all of user frinds 
        foreach (var friend in user.UsersToNetworks)
        {
            await eventSender.SendAsync($"{friend.Id}FollowPosts", newPost, cancellationToken);

        }
        return added;
    }
}