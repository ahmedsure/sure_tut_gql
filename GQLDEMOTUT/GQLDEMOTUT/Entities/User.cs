
using System.ComponentModel.DataAnnotations.Schema;


namespace GQLDEMOTUT.Entities;
public partial class GQLUser : BaseEntity<Guid>
{
   public string UserName { get; set; }
   public string? UserProfilePath { get; set; }
   public string? UserProfileIMGPath { get; set; }

    [NotMapped]
    public string UserNationality { get; set; }

    public virtual ICollection<Post>? UserPosts { get; set; }

    public virtual ICollection<ReactToPost>? UserReactions { get; set; }
    public virtual ICollection<CommentToPostOrComment>? UserComments { get; set; }
    public virtual ICollection<GQLUsersNetwork>? UserFromNetworks { get; set; }
    public virtual ICollection<GQLUsersNetwork>? UsersToNetworks { get; set; }

}
public enum FrindshipDescription
{
    FRIND , FATHER , MOTHER , SON , COSINE , GFATHER , GMOTHER  
}
public partial class GQLUsersNetwork : BaseEntity<Guid>
{
    public Guid RelationFromUserID { get; set; }
    public Guid RelationToUserID { get; set; }
    public FrindshipDescription FrindshipDescription { get; set; } = FrindshipDescription.FRIND;

    public virtual GQLUser RelationFromUser { get; set; }
    public virtual GQLUser RelationToUser { get; set; }
}