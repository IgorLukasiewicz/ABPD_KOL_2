namespace KOLOK_2.DTOs;

public class AddNewExhibitionDTO
{
    public string Title { get; set; }
    public string Gallery { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<ArtworkInAddNewExhibitionDTO> Artworks { get; set; }


}

public class ArtworkInAddNewExhibitionDTO
{
    public int ArtworkId { get; set; }
    public double InsuranceValue { get; set; }
}