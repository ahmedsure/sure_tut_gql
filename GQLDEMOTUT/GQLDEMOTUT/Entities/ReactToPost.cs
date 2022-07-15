
namespace GQLDEMOTUT.Entities;

public partial class ReactToPost :BaseEntity<Guid>
{
    public Guid ReactionBy { get; set; }
    public Guid ReactedTOPost { get; set;  }
    public Reaction ReactionTaken { get; set; }
    public DateTime ReactToPostOn { get; set; }

    public virtual GQLUser Reactor { get; set; }
    public virtual Post ReactedPost { get; set; }
}
