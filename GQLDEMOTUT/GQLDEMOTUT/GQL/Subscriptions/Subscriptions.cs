using GQLDEMOTUT.Entities;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GQLDEMOTUT.GQL.Subscriptions;
public partial class Subscription
{
    [Subscribe]
    [Topic(nameof(Subscription.OnPostAddedNotifyAll))]
    public Post OnPostAddedNotifyAll([EventMessage] Post Post) => Post;

    [SubscribeAndResolve]
    public ValueTask<ISourceStream<Post>> OnPostAddedNotifyMyNetwork(Guid notifyUserID,[Service] ITopicEventReceiver receiver)
    {
        var topic = $"{notifyUserID}FollowPosts";

        return receiver.SubscribeAsync<string, Post>(topic);
    }
}