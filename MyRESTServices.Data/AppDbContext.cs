using Microsoft.EntityFrameworkCore;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.Property(e => e.PublishDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Username).HasDefaultValue("ekurniawan");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articles_Categories");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Articles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articles_Users");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cities_Countries");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasMany(d => d.Usernames).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersRole",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersRoles_Users"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersRoles_Roles"),
                    j =>
                    {
                        j.HasKey("RoleId", "Username");
                        j.ToTable("UsersRoles");
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                        j.IndexerProperty<string>("Username").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.LastLogin).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MaxAttempt).HasDefaultValue((byte)5);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
