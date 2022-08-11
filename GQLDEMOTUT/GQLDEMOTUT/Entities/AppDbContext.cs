using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookReview> BookReviews { get; set; }

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

        modBuild.Entity<Book>()
            .ToTable("Books")
            .HasOne(o => o.BookAuthor)
            .WithMany(b => b.AutherBooks)
            .HasForeignKey(k => k.AutherId);

        modBuild.Entity<Book>()
            .HasOne(o => o.BookPublisher)
            .WithMany(b => b.PublishedBooks)
            .HasForeignKey(k => k.PublisherId);

        modBuild.Entity<BookReview>()
            .ToTable("BookReviews")
           .HasOne(o => o.RatedBook)
           .WithMany(b => b.BookReviews)
           .HasForeignKey(k => k.BookId);
        modBuild.Entity<Author>()
           .ToTable("Authors");
        modBuild.Entity<Publisher>()
          .ToTable("Publishers");
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
        GetListsOfBooksAndOuthorsAndPublishers(out List<Author> authoresList,
                                              out List<Publisher> publishersList,
                                              out List<Book> booksList);
        modBuild.Entity<Author>().HasData(authoresList);
        modBuild.Entity<Publisher>().HasData(publishersList);
        modBuild.Entity<Book>().HasData(booksList);
        Console.WriteLine("Seed Books Done ");
    }

    private static void GetListsOfBooksAndOuthorsAndPublishers(out List<Author> authoresList, 
                                                              out List<Publisher> publishersList, 
                                                              out List<Book> booksList)
    {
         authoresList = new();
        publishersList = new();
        booksList = new();
        #region Books Module Data 
        string path = Directory.GetCurrentDirectory();
        string filePath = "|DataDirectory|\\DB\\Book1.csv".Replace("|DataDirectory|", path);
        var allLines = File.ReadAllLines(filePath);
        Console.Write(filePath);
        // reading books data 
        List<string> titles = new();
        List<string> authors = new();
        List<string> rating = new();
        List<string> languages = new();
        List<string> isbns = new();
        List<string> genres = new();
        List<string> characters = new();
        List<string> editions = new();
        List<string> pages = new();
        List<string> publishers = new();

        List<int> pricesList = new();
        List<DateTime> publishDatesAsDate = new();
        int counLines = 0;
        var randomDate = DateTime.Now.AddDays(new Random().Next(20, 50900) * -1);
        foreach (var line in allLines)
        {
            var values = line.Split(',');
            try
            {
                if (counLines != 0)
                {

                    titles.Add(values[0] ?? "");
                    authors.Add(values[1] ?? "");
                    rating.Add(values[2] ?? "");
                    languages.Add(values[3] ?? "");
                    isbns.Add(values[4] ?? "");
                    genres.Add(values[5] ?? "");
                    characters.Add(values[6] ?? "");
                    editions.Add(values[8] ?? "");
                    var done = int.TryParse(values[9] ?? "0", out int pr);
                    pages.Add(done ? pr.ToString() : "0");
                    publishers.Add(values[10] ?? "");
                    try
                    {
                        publishDatesAsDate.Add(DateTime.Parse(values[11] ?? ""));
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Err Date On Counter :" + counLines);
                        publishDatesAsDate.Add(randomDate.AddDays(1));
                    }
                    try
                    {
                        pricesList.Add(int.Parse(values[18] ?? "0"));
                    }
                    catch
                    {
                        Console.WriteLine("Err Price On Counter :" + counLines);
                        pricesList.Add(0);
                    }

                }
            }
            catch
            {
                Console.WriteLine(line);
            }
            counLines++;
        }
        authoresList = new();
        publishersList = new();
        booksList = new();
        int counter = 0;
        foreach (var a in authors)
        {
            authoresList.Add(new Author
            {
                AuthorName = a,
                Id = ++counter,
                DateOfBirth = DateTime.Now.AddDays(new Random().Next(2000, 50900) * -1)
            });
        }
        counter = 0;
        authoresList = authoresList.DistinctBy(x => x.AuthorName).ToList();
        foreach (var pub in publishers)
        {
            publishersList.Add(new Publisher { PublisherName = string.IsNullOrEmpty(pub) ? "" : pub, Id = ++counter });
        }
        publishersList = publishersList.DistinctBy(x => x.PublisherName).ToList();

        counter = 0;
        foreach (var t in titles)
        {

            if (counter != 0 && counter != 3188)
            {
                Book bookItem = new();
                try
                {
                    var author = authoresList.FirstOrDefault(a => a.AuthorName == authors.ElementAt(counter));
                    var publisher = publishersList.FirstOrDefault(a => a.PublisherName == publishers.ElementAt(counter));
                    var price = pricesList.ElementAt(counter);
                    var chars = characters.ElementAt(counter).Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\'", "").Split("#");
                    var gens = genres.ElementAt(counter).Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\'", "").Split("#");

                    bookItem = new()
                    {
                        BookName = t,
                        BookDescription = t,
                        AutherId = author != null ? author.Id : authoresList.First().Id,
                        Characters = string.Join("#", chars),
                        Id = counter,
                        ISBN = @$"{isbns.ElementAt(counter)}",
                        DateOfRelease = publishDatesAsDate.ElementAt(counter),
                        Language = $@"{languages.ElementAt(counter)}",
                        GeneresTags = @$"{string.Join("#", gens)}",
                        NumberOfPages = int.Parse(pages.ElementAt(counter)),
                        PublisherId = publisher != null ? publisher.Id : publishersList.First().Id,
                        BookPriceInUSD = price,

                    };
                    booksList.Add(bookItem);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("adding book no  " + counter + " Failed ");
                    Console.WriteLine("\n--------\n" + JsonConvert.SerializeObject(bookItem) + "\n --------------");
                    Console.WriteLine("-------------- \n " + exp + "\n ----------");
                }
            }
            ++counter;
        }
       
        Console.WriteLine("booksList count  " + booksList.Count);
        #endregion Books
    }
}