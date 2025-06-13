using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOLOK_2.Models;

[Table("Exhibition")]
public class Exhibition
{
    [Key]
    public int ExhibitionId { get; set; }
    
    [ForeignKey(nameof(Gallery))]
    public int GalleryId { get; set; }
    
    [MaxLength(100)]
    public string Title { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int? NumberOfArtworks { get; set; }
    
    public Gallery Gallery { get; set; }
    
    public  ICollection<ExhibitionArtwork> ExhibitionArtwork { get; set; } = new List<ExhibitionArtwork>();

}