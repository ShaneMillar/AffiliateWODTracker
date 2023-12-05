using AffiliateWODTracker.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDataContext : IdentityDbContext<OwnerEntity>
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
        : base(options)
    {
    }

    public DbSet<AffiliateEntity> Affiliates { get; set; }
    public DbSet<WODEntity> WODs { get; set; }
    public DbSet<ScoreEntity> Scores { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

    public DbSet<MemberEntity> Members { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        //Configure Owner - Affiliate Relationship
        modelBuilder.Entity<OwnerEntity>()
           .HasOne(a => a.Affiliate)
           .WithMany()
           .HasForeignKey(u => u.AffiliateId)
           .IsRequired(false); // Mark it as optional


        // Configure Members - Affiliate relationship
        modelBuilder.Entity<MemberEntity>()
            .HasOne(w => w.Affiliate)
            .WithMany(a => a.Members)
            .HasForeignKey(w => w.AffiliateId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on WODs when an Affiliate is deleted

        // Configure Score - User relationship
        //modelBuilder.Entity<ScoreEntity>()
        //    .HasOne(s => s.User)
        //    .WithMany(u => u.Scores)
        //    .HasForeignKey(s => s.UserId)
        //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on Scores when a User is deleted

        // Configure Score - WOD relationship
        modelBuilder.Entity<ScoreEntity>()
            .HasOne(s => s.WOD)
            .WithMany(w => w.Scores)
            .HasForeignKey(s => s.WODId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on Scores when a WOD is deleted

        // Configure Comment - User relationship
        //modelBuilder.Entity<CommentEntity>()
        //    .HasOne(c => c.User)
        //    .WithMany(u => u.Comments)
        //    .HasForeignKey(c => c.UserId)
        //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on Comments when a User is deleted

        // Configure Comment - WOD relationship
        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.WOD)
            .WithMany(w => w.Comments)
            .HasForeignKey(c => c.WODId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on Comments when a WOD is deleted
    }

}