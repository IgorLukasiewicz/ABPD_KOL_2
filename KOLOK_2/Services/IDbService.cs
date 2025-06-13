using KOLOK_2.DTOs;

namespace KOLOK_2.Services;

public interface IDbService
{
    public Task<GalleriesInfoDTO> GetGalleriesInfo(int galleryId);
    
    public Task AddNewExhibition(AddNewExhibitionDTO dto);
}