using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace GQLDEMOTUT.Entities;

public static class MigrationHelper
{
    public static void UseApplicationDBMigration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
        .CreateScope();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        serviceScope.ServiceProvider.GetService<AppDbContext>().Database
            .Migrate();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
public class AppDbContext : DbContext
{
    public DbSet<GQLUser> GQLUsers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<CommentToPostOrComment> Comments { get; set; }
    public DbSet<ReactToPost> Reactions { get; set; }
    public DbSet<GQLUsersNetwork> UsersNetworks { get; set; }

    public AppDbContext(DbContextOptions opt) : base(opt)
    {
        //this.Database.EnsureCreated();
        //Console.WriteLine("****" +this.Database.GetConnectionString()+ "****");
    }


    protected override void OnModelCreating(ModelBuilder modBuild)
    {
        modBuild.Entity<GQLUser>()
            .ToTable("Users")
                .HasMany(x => x.UserPosts)
                .WithOne(x => x.PostOwner)
                .HasForeignKey(f => f.PostedBy);

        modBuild.Entity<GQLUser>()
               .HasMany(x => x.UserReactions)
               .WithOne(x => x.Reactor)
               .HasForeignKey(f => f.ReactionBy);

        modBuild.Entity<GQLUser>()
              .HasMany(x => x.UserComments)
              .WithOne(x => x.Commentor)
              .HasForeignKey(f => f.CommentBy);

        modBuild.Entity<ReactToPost>()
            .ToTable("ReactToPosts");


        modBuild.Entity<Post>()
            .ToTable("Posts")
            .HasMany(c => c.PostComments)
            .WithOne(p => p.MainPost)
            .HasForeignKey(fk => fk.CommentOnPostID);

        modBuild.Entity<Post>()
           .HasMany(c => c.PostReactions)
           .WithOne(p => p.ReactedPost)
           .HasForeignKey(fk => fk.ReactedTOPost);


        modBuild.Entity<CommentToPostOrComment>()
            .ToTable("CommentToPostOrComments")
           .HasOne(c => c.MainPost)
           .WithMany(p => p.PostComments)
           .HasForeignKey(fk => fk.CommentOnPostID);

        modBuild.Entity<CommentToPostOrComment>()
          .HasMany(c => c.CommentComments)
          .WithOne(p => p.CommentParent)
          .HasForeignKey(fk => fk.CommentOnPostID);

        modBuild.Entity<GQLUsersNetwork>()
            .ToTable("GQLUsersNetworks")
         .HasOne(c => c.RelationFromUser)
         .WithMany(p => p.UserFromNetworks)
         .HasForeignKey(fk => fk.RelationFromUserID);

        modBuild.Entity<GQLUsersNetwork>()
       .HasOne(c => c.RelationToUser)
       .WithMany(p => p.UsersToNetworks)
       .HasForeignKey(fk => fk.RelationToUserID);

        // generate some demo seeding data 
        GetInitDemoSeedingData(modBuild);
    }

    private static void GetInitDemoSeedingData(ModelBuilder modBuild)
    {

        var fPostComment = new CommentToPostOrComment
        {
            Id = Guid.Parse("F1B72222-9BBB-45A8-B6FE-EFCE8162A7DB"),
            CommentContent = "Hi , Welcome ",
            CommentBy = Guid.Parse("01B55555-955B-45A8-B6FE-EFCE8162A755"),
            CommentedOn = new DateTime(11, 11, 11, 12, 30, 30),
            CommentOnPostID = Guid.Parse("F1B72222-9BBB-45A8-B6FE-EFCE8162A7DB")
        };
        var fPost = new Post
        {
            Id = Guid.Parse("F1B72222-9BBB-45A8-B6FE-EFCE8162A7DB"),
            PostContent = "Hi , This Is My First Post Here ",
            PostedBy = Guid.Parse("01B72B5B-955B-45A8-B6FE-EFCE8162A7DB"),
            PostedOn = new DateTime(11, 11, 11, 12, 30, 30),
        };
        var fUser = new GQLUser
        {
            Id = Guid.Parse("01B72B5B-955B-45A8-B6FE-EFCE8162A7DB"),
            UserName = "First User Of APP",

        };
        var secUser = new GQLUser
        {
            Id = Guid.Parse("01B55555-955B-45A8-B6FE-EFCE8162A755"),
            UserName = "Sec User ",
        };
        modBuild.Entity<GQLUser>().HasData(new List<GQLUser> { fUser, secUser });
        modBuild.Entity<Post>().HasData(new List<Post> { fPost });
        modBuild.Entity<CommentToPostOrComment>().HasData(new List<CommentToPostOrComment> { fPostComment });
        modBuild.Entity<GQLUsersNetwork>().HasData(new List<GQLUsersNetwork> {
            new GQLUsersNetwork{
              Id =  Guid.Parse("01B72B5B-955B-45A8-B6FE-EFCE8162A7DB"),
              RelationFromUserID = Guid.Parse("01B72B5B-955B-45A8-B6FE-EFCE8162A7DB"),
              RelationToUserID = Guid.Parse("01B55555-955B-45A8-B6FE-EFCE8162A755"),
        }
        }
        );

    }
}