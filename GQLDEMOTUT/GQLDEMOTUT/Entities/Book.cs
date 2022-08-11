
using System.ComponentModel.DataAnnotations.Schema;

namespace GQLDEMOTUT.Entities;

public partial class Book : BaseEntity<int>
{
    public int AutherId { get; set; }
    public int PublisherId { get; set; }
    public string BookName { get; set; }
    public string BookDescription { get; set; }
    public DateTime? DateOfRelease { get; set; }
    public byte? Edetion { get; set; } = 1;
    public string? Language { get; set; }
    public string? GeneresTags { get; set; }
    public string? Characters { get; set; }
    public int? NumberOfPages { get; set; }
    [GraphQLName("ISBN")]
    public string? ISBN { get; set; }
    [NotMapped]
    public int BookInventory { get; set; }
    [NotMapped]
    public int BookPriceInUSD { get; set; }
    [NotMapped]
    public string? BookCoverImage { get; set; }
    public virtual Author BookAuthor { get; set; }
    public virtual Publisher BookPublisher { get; set; }
    public virtual ICollection<BookReview> BookReviews { get; set; }
}

