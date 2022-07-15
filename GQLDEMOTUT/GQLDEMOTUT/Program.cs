using GQLDEMOTUT.Entities;
using GQLDEMOTUT.GQL.Mutations;
using GQLDEMOTUT.GQL.Queries;
using GQLDEMOTUT.GQL.Subscriptions;
using GQLDEMOTUT.Entities;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("sqllite");
string path = Directory.GetCurrentDirectory();
// instead of AddDbContext for the multi threading / concurrent GraphQL recuests
builder.Services.AddPooledDbContextFactory<AppDbContext>((serviceProvider, optBuilder) =>
{
    optBuilder.UseSqlite(connectionString.Replace("|DataDirectory|", path));
    optBuilder.EnableSensitiveDataLogging(true);
    //optBuilder.UseInternalServiceProvider(serviceProvider);
});
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString.Replace("|DataDirectory|", path)));
builder.Services
   .AddGraphQLServer()
   .AddQueryType<GQLQuery>()
   //.AddMutationType<Mutations>()
   //.AddSubscriptionType<Subscriptions>()
   //.AddType<PlatformType>()
   .AddFiltering()
   .AddSorting()
   // allow to query a child object
   .AddProjections()
   .AddInMemorySubscriptions();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseApplicationDBMigration();
// for GQL Subscriptions 
app.UseWebSockets();

app.UseHttpsRedirection();


app.MapControllers();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
    // Add GQL End Points 
    endpoints.MapGraphQL();
});
// Adding GraphQLVoyager tool to preview schema visually if needed 
app.UseGraphQLVoyager(new VoyagerOptions
{
    GraphQLEndPoint = "/graphql"
}, "/gql/voyager");

app.Run();
