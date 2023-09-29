using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.DbEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Concrete.EntityFramework.Contexts;


public class ProjectDbContext : IdentityDbContext<User, AppRole, long>
{

    protected IConfiguration Configuration { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=SurveyDb; Trusted_Connection=True"));
    }

    public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

    public DbSet<SurveyChoice> SurveyChoices { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<IdentityUserToken<long>> AspNetUserTokens { get; set; }

    public DbSet<AppRole> AppRoles { get; set; }

    public DbSet<UserSurveyQuestionAnswer> UserSurveyQuestionAnswers { get; set; }

    //public DbSet<UserSurveyQuestionCorrectAnswer> UserSurveyQuestionCorrectAnswers { get; set; }

    public DbSet<Survey> Surveys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    //    modelBuilder.Entity<UserSurveyQuestionAnswer>()
    //.HasOne(usqa => usqa.AnswerUser)
    //.WithMany(u => u.UserSurveyQuestionAnswers)
    //.HasForeignKey(usqa => usqa.AnswerUserId);


        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();

        //modelBuilder.Entity<UserSurveyQuestionAnswer>()
        //    .HasOne(u => u.SurveyQuestion)
        //    .WithMany(u => u.UserSurveyQuestionAnswers)
        //    .HasForeignKey(u => u.SurveyQuestionId)
        //    .OnDelete(DeleteBehavior.ClientSetNull);

    }
}