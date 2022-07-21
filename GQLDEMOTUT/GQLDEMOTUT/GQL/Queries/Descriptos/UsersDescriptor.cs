using GQLDEMOTUT.Entities;


namespace GQLDEMOTUT.GQL.Queries.Descriptos
{
    public class UsersDescriptor: ObjectType<GQLUser>
    {
        protected override void Configure(IObjectTypeDescriptor<GQLUser> descriptor)
        {
            descriptor.Description("Represents Users In The Application And There Profiles , Posts , Reactions ... ");
            descriptor
                .Field(x => x.UserProfileIMGPath)
                .Description("The User Profile Image Path");

            descriptor.Field(x => x.UsersToNetworks).Ignore();
            descriptor.Field(x => x.UserNationality).ResolveWith<UsersNationalityResolver>(x=>x.GetUserNationality(default));
            descriptor.Field(x => x.UserPosts)
                .ResolveWith<UserDataResolver>(x=>x.GetUserPosts(default,default))
                 .UseDbContext<AppDbContext>()
                       .Description("Represents A user Posts ");

 

        }
    }

    public class PostsDescriptor : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Description("Represents Users Posts The Application Comments , Reactions ... ");
            descriptor
                .Field(x => x.PostContent)
                .Description("Post inner content");
            descriptor.Field(x => x.PostReactions).ResolveWith<PostDataResolver>(x => x.GetPostReactions(default,default));
            descriptor.Field(x => x.PostComments)
                .ResolveWith<PostDataResolver>(x => x.GetPostComments(default, default))
                 .UseDbContext<AppDbContext>()
                       .Description("Represents A user Posts ");



        }
    }
    public class UsersNationalityResolver 
    {
        public string GetUserNationality([Parent] GQLUser user)
        {
            var countries = new List<string>() { "Egypt", "USA" , "CANADA"};
            var r = new Random().Next(0,countries.Count);
            return countries[r];
        }

        
    }
    public class UserDataResolver
    {
        public IQueryable<Post> GetUserPosts([Parent] GQLUser user, [ScopedService] AppDbContext _ctox)
        {
            return _ctox.Posts.Where(post => post.PostedBy == user.Id);
        }
    }

    public class PostDataResolver
    {
        public IQueryable<CommentToPostOrComment> GetPostComments([Parent] Post post, [ScopedService] AppDbContext _ctox)
        {
            return _ctox.Comments.Where(post => post.CommentOnPostID== post.Id);
        }

        public IQueryable<ReactToPost> GetPostReactions([Parent] Post post, [ScopedService] AppDbContext _ctox)
        {
            return _ctox.Reactions.Where(react => react.ReactedTOPost == post.Id);
        }
    }
}
