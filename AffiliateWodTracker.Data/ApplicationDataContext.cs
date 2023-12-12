using AffiliateWODTracker.Data.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDataContext : IdentityDbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
        : base(options)
    {
    }

    //Admin Entities
    public DbSet<AffiliateEntity> Affiliates { get; set; }
    public DbSet<MemberEntity> Members { get; set; }


    //Mobile App Entities
    public DbSet<WODEntity> WODs { get; set; }
    public DbSet<ScoreEntity> Scores { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

    public DbSet<StatusEntity> Status { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        #region Admin

        // Configure Members - Affiliate relationship
        modelBuilder.Entity<MemberEntity>()
            .HasOne(w => w.Affiliate)
            .WithMany(a => a.Members)
            .HasForeignKey(w => w.AffiliateId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete on WODs when an Affiliate is deleted

        #endregion


        #region Mobile

        // Configure Score - User relationship
        //modelBuilder.Entity<ScoreEntity>()
        //    .HasOne(s => s.User)
        //    .WithMany(u => u.Scores)
        //    .HasForeignKey(s => s.UserId)
        //    .OnDelete(DeleteBehavior.Restrict); 

        // Configure Score - WOD relationship
        modelBuilder.Entity<ScoreEntity>()
            .HasOne(s => s.WOD)
            .WithMany(w => w.Scores)
            .HasForeignKey(s => s.WODId)
            .OnDelete(DeleteBehavior.Restrict); 


        // Configure Comment - WOD relationship
        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.WOD)
            .WithMany(w => w.Comments)
            .HasForeignKey(c => c.WODId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Member - Status relationship

        modelBuilder.Entity<MemberEntity>()
         .HasOne(m => m.Status)
         .WithMany()
         .HasForeignKey(m => m.StatusId)
         .OnDelete(DeleteBehavior.Restrict);

        // Configure Member - dentityUser relationship

        modelBuilder.Entity<MemberEntity>()
         .HasOne(m => m.User)
         .WithMany()
         .HasForeignKey(m => m.UserId)
         .OnDelete(DeleteBehavior.Restrict);

        #endregion


        //modelBuilder.Entity<StatusEntity>().HasData(
        //new StatusEntity { StatusId = (int)MemberStatus.Accepted, Name = "Accepted" },
        //new StatusEntity { StatusId = (int)MemberStatus.Rejected, Name = "Rejected" },
        //new StatusEntity { StatusId = (int)MemberStatus.Pending, Name = "Pending" }
        //);
    }

}