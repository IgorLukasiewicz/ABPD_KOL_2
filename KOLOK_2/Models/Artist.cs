using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOLOK_2.Models;


[Table("Artist")]
public class Artist
{
    [Key]
    public int ArtistId { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public  ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}