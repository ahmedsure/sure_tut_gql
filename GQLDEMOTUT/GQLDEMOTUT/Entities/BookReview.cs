namespace GQLDEMOTUT.Entities;

public partial class BookReview : BaseEntity<int>
{
    public int BookId { get; set; }
    public byte ReviewRate { get; set; }
    public DateTime DateOfReview { get; set; }
    public virtual Book RatedBook { get; set; }
}

