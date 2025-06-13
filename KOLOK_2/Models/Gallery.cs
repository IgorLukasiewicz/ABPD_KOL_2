using System.ComponentModel.DataAnnotations;

namespace KOLOK_2.Models;

public class Gallery
{
    [Key]
    public int GalleryId { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    public DateTime EstablishedDate { get; set; }
    
    
    public  ICollection<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();

}