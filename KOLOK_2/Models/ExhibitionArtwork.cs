using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLOK_2.Models;
[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
[Table("Exhibition_Artwork")]
public class ExhibitionArtwork
{
    [ForeignKey(nameof(Exhibition))]
    public int ExhibitionId { get; set; }
    
    [ForeignKey(nameof(Artwork))]
    public int ArtworkId { get; set; }
    
    [Column(TypeName = "numeric")]
    [Precision(10,2)]
    public double InsuranceValue  { get; set; }
    
    public Artwork Artwork { get; set; }
    public Exhibition Exhibition { get; set; }
}