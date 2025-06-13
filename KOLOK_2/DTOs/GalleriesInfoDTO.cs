using KOLOK_2.Models;

namespace KOLOK_2.DTOs;

public class GalleriesInfoDTO
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public List<ExhibitionsInGalleriesInfoDTO> Exhibitions { get; set; }
}

public class ExhibitionsInGalleriesInfoDTO
{
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public List<ArtworkInGalleriesInfoDTO> Artworks { get; set; }
}

public class ArtworkInGalleriesInfoDTO
{
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public double InsuranceValue {get; set;}
    public ArtistInGalleriesInfoDTO Artist { get; set; }
}

public class ArtistInGalleriesInfoDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}