using KOLOK_2.DAL;
using KOLOK_2.DTOs;
using KOLOK_2.Exceptions;
using KOLOK_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLOK_2.Services;

public class DbService : IDbService
{
    private readonly NewDbContext _context;

    public DbService(NewDbContext context)
    {
        _context = context;
    }

    public async Task<GalleriesInfoDTO> GetGalleriesInfo(int galleryId)
    {
        var gallery = await _context.Galleries
            .Select(g => new GalleriesInfoDTO
            {
                GalleryId = g.GalleryId,
                Name = g.Name,
                EstablishedDate = g.EstablishedDate,
                Exhibitions = g.Exhibitions.Select(ex => new ExhibitionsInGalleriesInfoDTO()
                {
                    Title = ex.Title,
                    StartDate = ex.StartDate,
                    EndDate = ex.EndDate,
                    NumberOfArtworks = ex.NumberOfArtworks ?? 0,
                    Artworks = ex.ExhibitionArtwork.Select(ea => new ArtworkInGalleriesInfoDTO()
                    {
                        Title = ea.Artwork.Title,
                        YearCreated = ea.Artwork.YearCreated,
                        InsuranceValue = ea.InsuranceValue,
                        Artist = new ArtistInGalleriesInfoDTO()
                        {
                            FirstName = ea.Artwork.Artist.FirstName,
                            LastName = ea.Artwork.Artist.LastName,
                            BirthDate = ea.Artwork.Artist.BirthDate,
                        }

                    }).ToList()

                }).ToList()
            }).FirstOrDefaultAsync(g => g.GalleryId == galleryId);

        if (gallery is null)
            throw new NotFoundException();
        
        
        return  gallery;

    }


    public async Task AddNewExhibition(AddNewExhibitionDTO dto)
    {
        
        if (!await _context.Galleries.AnyAsync(g => g.Name == dto.Gallery))
            throw new NotFoundException("Taka Galeria nie istnieje");
       
        
        var requestedArtworks = dto.Artworks.Select(a => a.ArtworkId).ToList();
        var existingArtworks = await _context.Artworks
            .Where(a => requestedArtworks.Contains(a.ArtworkId))
            .ToListAsync();

        if (existingArtworks.Count != requestedArtworks.Count)
            throw new NotFoundException("Niektóre z podanych obrazów nie istnieja :<");
        
        
        var exhibition = new Exhibition
        {
            Title = dto.Title,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
        };
        
        _context.Exhibitions.Add(exhibition);
        await _context.SaveChangesAsync();
        
        
        foreach (var artworksDto in dto.Artworks)
        {
            var program = existingArtworks.First(a => a.ArtworkId == artworksDto.ArtworkId);

            var availaArtwork = new ExhibitionArtwork
            {
               ArtworkId = artworksDto.ArtworkId,
               InsuranceValue = artworksDto.InsuranceValue,
            };

            _context.ExhibitionArtworks.Add(availaArtwork);
        }

        await _context.SaveChangesAsync();
    }

}