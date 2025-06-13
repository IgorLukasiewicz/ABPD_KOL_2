using KOLOK_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLOK_2.DAL;

public class NewDbContext : DbContext
{

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    
    
    protected NewDbContext()
    {
    }

    public NewDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new List<Artist>()
        {
            new Artist(){ArtistId = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1981, 1, 1)},
            new Artist(){ArtistId = 2, FirstName = "James", LastName = "Doe", BirthDate = new DateTime(1982, 1, 1)},
            new Artist(){ArtistId = 3, FirstName = "Jane", LastName = "Doe", BirthDate = new DateTime(1983, 1, 1)}
        });

        modelBuilder.Entity<Artwork>().HasData(new List<Artwork>()
        {
            new Artwork() { ArtworkId = 1, ArtistId = 1, Title = "Title 1", YearCreated = 2021 },
            new Artwork() { ArtworkId = 2, ArtistId = 2, Title = "Title 2", YearCreated = 2022 },
            new Artwork() { ArtworkId = 3, ArtistId = 3, Title = "Title 3", YearCreated = 2023 },
        });

        modelBuilder.Entity<Exhibition>().HasData(new List<Exhibition>()
        {
            new Exhibition(){ExhibitionId = 1, GalleryId = 1, Title = "Title 1", StartDate = new DateTime(1999, 1, 1), EndDate = new DateTime(1999,1,2),NumberOfArtworks = 2},
            new Exhibition(){ExhibitionId = 2, GalleryId = 2, Title = "Title 2", StartDate = new DateTime(1999, 1, 2), EndDate = new DateTime(1999,1,3),NumberOfArtworks = 2},
            new Exhibition(){ExhibitionId = 3, GalleryId = 3, Title = "Title 3", StartDate = new DateTime(1999, 1, 3), EndDate = new DateTime(1999,1,4),NumberOfArtworks = 2}
            
        });

        modelBuilder.Entity<ExhibitionArtwork>().HasData(new List<ExhibitionArtwork>()
        {
            new ExhibitionArtwork() { ExhibitionId = 1, ArtworkId = 2, InsuranceValue = 15 },
            new ExhibitionArtwork() { ExhibitionId = 2, ArtworkId = 2, InsuranceValue = 16 },
            new ExhibitionArtwork() { ExhibitionId = 3, ArtworkId = 3, InsuranceValue = 17 },

        });

        modelBuilder.Entity<Gallery>().HasData(new List<Gallery>()
        {
            new Gallery() { GalleryId = 1, Name = "Gallery 1", EstablishedDate = new DateTime(1999, 1, 1) },
            new Gallery() { GalleryId = 2, Name = "Gallery 2", EstablishedDate = new DateTime(1999, 1, 2) },
            new Gallery() { GalleryId = 3, Name = "Gallery 3", EstablishedDate = new DateTime(1999, 1, 3) }
        });
        
    }

}