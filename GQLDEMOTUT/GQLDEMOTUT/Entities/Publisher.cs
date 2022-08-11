namespace GQLDEMOTUT.Entities;

public partial class Publisher : BaseEntity<int>
{
    public string PublisherName { get; set; }
    public ICollection<Book> PublishedBooks { get; set; }
}

