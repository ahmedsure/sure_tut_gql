namespace GQLDEMOTUT.Entities;

public partial class Author : BaseEntity<int>
{
    public string AuthorName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public ICollection<Book> AutherBooks { get; set; }
}

