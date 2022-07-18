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
        }
    }
}
