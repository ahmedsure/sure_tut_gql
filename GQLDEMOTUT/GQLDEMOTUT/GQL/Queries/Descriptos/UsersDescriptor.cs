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
}
