
namespace GQLDEMOTUT.Entities;

public partial class CommentToPostOrComment : BaseEntity<Guid>
{
    public Guid CommentBy { get; set; }
    public Guid CommentOnPostID { get; set; }
    public Guid? CommentOnCommentID { get; set; }
    public string CommentContent{ get; set; }

    public DateTime CommentedOn { get; set; }
    public virtual GQLUser Commentor { get; set; }
    public virtual Post MainPost { get; set; }
    public virtual CommentToPostOrComment? CommentParent { get; set; }
    public virtual ICollection<CommentToPostOrComment>? CommentComments { get; set; }
}