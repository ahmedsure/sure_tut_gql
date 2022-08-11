namespace GQLDEMOTUT.Entities;

public partial class Post : BaseEntity<Guid>
{
    public string PostContent { get; set; }
    public Guid PostedBy { get; set; }
    public DateTime PostedOn { get; set; }

    public virtual GQLUser PostOwner   { get; set; }

    public virtual ICollection<ReactToPost> PostReactions { get; set; }
    public virtual ICollection<CommentToPostOrComment> PostComments { get; set; }

}

