using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models.Book;
using WebApplication4.Models.Category;
using WebApplication4.Models.User;
using WebApplication4.Models.Renting;

namespace WebApplication4.Models.Data;

public class LibDbContext : IdentityDbContext<AppUser>
{
    public LibDbContext(DbContextOptions<LibDbContext> options)
        : base(options)
    {
    }


    public DbSet<BookEntity> Books { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<RentEntity> Rents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var hasher = new PasswordHasher<AppUser>();

        builder.Entity<AppUser>().HasData(new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Damian",
            LastName = "Maksimowicz",
            Email = "damian@wp.pl", // login
            UserName = "damian@wp.pl",
            NormalizedEmail = "DAMIAN@WP.PL",
            NormalizedUserName = "DAMIAN@WP.PL",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Projektmvc123!"), // haslo
            Role = Role.Admin,
            Status = User.Status.Verified
        });

        builder.Entity<AppUser>().HasData(new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Gosc",
            LastName = "Gosc",
            Email = "gosc@wp.pl", // login
            UserName = "gosc@wp.pl",
            NormalizedEmail = "GOSC@WP.PL",
            NormalizedUserName = "GOSC@WP.PL",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "test123"), // haslo
            Role = Role.Client,
            Status = User.Status.Verified
        });
        builder.Entity<AppUser>().HasData(new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Pracownik",
            LastName = "Pracownik",
            Email = "pracownik@wp.pl", // login
            UserName = "pracownik@wp.pl",
            NormalizedEmail = "PRACOWNIK@WP.PL",
            NormalizedUserName = "PRACOWNIK@WP.PL",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "test1234"), // haslo
            Role = Role.Employee,
            Status = User.Status.Verified
        });

        builder.Entity<CategoryEntity>().HasData(new CategoryEntity
        {
            CategoryId = Guid.NewGuid(),
            Name = "Kryminalna"
        });

        builder.Entity<CategoryEntity>().HasData(new CategoryEntity
        {
            CategoryId = Guid.NewGuid(),
            Name = "Horror"
        });

        builder.Entity<CategoryEntity>().HasData(new CategoryEntity
        {
            CategoryId = Guid.NewGuid(),
            Name = "Science-Fiction"
        });

        builder.Entity<CategoryEntity>().HasData(new CategoryEntity
        {
            CategoryId = Guid.NewGuid(),
            Name = "Romans"
        });
        builder.Entity<CategoryEntity>().HasData(new CategoryEntity
        {
            CategoryId = Guid.NewGuid(),
            Name = "Thriller"
        });
        builder.Entity<BookEntity>().HasData(new BookEntity
        {
            CategoryId = Guid.Parse("2b64b94c-ab89-49cb-8a6c-2fd7f577b510"),
            BookId = Guid.NewGuid(),
            Isbn = "7685948576945",
            Title = "Drakoola",
            BookCount = 5,
            PageCount = 300,
            AuthorFullname = "Dr. Akula",
            PublishDate = DateTime.Parse("07/01/2007"),
            CreatedOn = DateTime.Now
        });
        builder.Entity<BookEntity>().HasData(new BookEntity
        {
            CategoryId = Guid.Parse("ee8d72c8-13b0-4d49-8a97-4d9e62920fa4"),
            BookId = Guid.NewGuid(),
            Isbn = "7685948556945",
            Title = "Im The Best",
            BookCount = 0,
            PageCount = 200,
            AuthorFullname = "Król Edward",
            PublishDate = DateTime.Parse("09/09/2009 01:01:01"),
            CreatedOn = DateTime.Now
        });
        builder.Entity<BookEntity>().HasData(new BookEntity
        {
            CategoryId = Guid.Parse("88c25e8f-70b6-46fc-9f94-7bfbcb671bd3"),
            BookId = Guid.NewGuid(),
            Isbn = "7615948576945",
            Title = "Dog vs Human",
            BookCount = 7,
            PageCount = 235,
            AuthorFullname = "Dog",
            PublishDate = DateTime.Parse("02/07/2015"),
            CreatedOn = DateTime.Now
        });
        builder.Entity<BookEntity>().HasData(new BookEntity
        {
            CategoryId = Guid.Parse("2b64b94c-ab89-49cb-8a6c-2fd7f577b510"),
            BookId = Guid.NewGuid(),
            Isbn = "4685948576945",
            Title = "Aliens",
            BookCount = 5,
            PageCount = 300,
            AuthorFullname = "Iaman Alien",
            PublishDate = DateTime.Parse("01/11/2022"),
            CreatedOn = DateTime.Now
        });
        builder.Entity<BookEntity>().HasData(new BookEntity
        {
            CategoryId = Guid.Parse("dde93c20-6ff3-448c-ba62-90ee8c235cfd"),
            BookId = Guid.NewGuid(),
            Isbn = "7685948576945",
            Title = "A Very Argentine Mustachy Artist",
            BookCount = 2,
            PageCount = 1200,
            AuthorFullname = "Adolfo Hilter",
            PublishDate = DateTime.Parse("12/02/1949"),
            CreatedOn = DateTime.Now
        });
        builder.Entity<BookEntity>().HasData(new BookEntity
        {
            CategoryId = Guid.Parse("a9e344f0-9275-43c9-a2d2-06c30c47e318"),
            BookId = Guid.NewGuid(),
            Isbn = "7777777777777",
            Title = "Quack Quack",
            BookCount = 1,
            PageCount = 50000,
            AuthorFullname = "Nota Duck, PH.D.",
            PublishDate = DateTime.Parse("06/06/2007"),
            CreatedOn = DateTime.Now
        });

    }
}
