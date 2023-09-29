using Entities.Concrete.DbEntities;
using Entities.Concrete.DbEntities.Users;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public static class ProjectDbSeedExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            FirstName = "Super",
            LastName = "Admin",
            UserName = "SuperAdmin",
            NormalizedUserName = "SUPERADMIN2023",
            Email = "super_admin@survey.com.tr",
            EmailConfirmed = true,
            IsDeleted = false
        });
        #region SurveyQuestion
        modelBuilder.Entity<SurveyQuestion>().HasData(
           new SurveyQuestion
           {
               Id = 1,
               SurveyId = 1,
               IsDeleted = false,
               CreatedDate = DateTime.Now,
               QuestionName = "En sevdiği yemek?",
           },
           new SurveyQuestion
           {
               Id = 2,
               SurveyId = 1,
               IsDeleted = false,
               CreatedDate = DateTime.Now,
               QuestionName = "En sevdiği müzik türü?"
           },
           new SurveyQuestion
           {
               Id = 3,
               SurveyId = 1,
               IsDeleted = false,
               CreatedDate = DateTime.Now,
               QuestionName = "Zamanını nasıl geçirir?"
           },
           new SurveyQuestion
           {
               Id = 4,
               SurveyId = 1,
               IsDeleted = false,
               CreatedDate = DateTime.Now,
               QuestionName = "Onu en çok ne sevindirir?"
           }
           );
        #endregion

        #region SurveyChoice
        modelBuilder.Entity<SurveyChoice>().HasData(
            new SurveyChoice
            {
                Id = 1,
                SurveyQuestionId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Patates Kızartması",

            },
            new SurveyChoice
            {
                Id = 2,
                SurveyQuestionId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Burger",

            },
            new SurveyChoice
            {
                Id = 3,
                SurveyQuestionId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Döner",

            },
             new SurveyChoice
             {
                 Id = 4,
                 SurveyQuestionId = 1,
                 IsDeleted = false,
                 CreatedDate = DateTime.Now,
                 ChoiceName = "Kuru Fasulye",

             },
            new SurveyChoice
            {
                Id = 5,
                SurveyQuestionId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Makarna",

            },



            new SurveyChoice
            {
                Id = 6,
                SurveyQuestionId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Pop",

            },
            new SurveyChoice
            {
                Id = 7,
                SurveyQuestionId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Rap",

            },
            new SurveyChoice
            {
                Id = 8,
                SurveyQuestionId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Rock",

            },
             new SurveyChoice
             {
                 SurveyQuestionId = 2,
                 Id = 9,
                 IsDeleted = false,
                 CreatedDate = DateTime.Now,
                 ChoiceName = "Türk Halk Müziği",

             },
            new SurveyChoice
            {
                Id = 10,
                SurveyQuestionId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Arabesk",

            },



            new SurveyChoice
            {
                Id = 11,
                SurveyQuestionId = 3,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Uyuyarak",

            },
            new SurveyChoice
            {
                Id = 12,
                SurveyQuestionId = 3,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Bilgisayar başında",

            },
            new SurveyChoice
            {
                Id = 13,
                SurveyQuestionId = 3,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Yürüyüş yaparak",

            },
             new SurveyChoice
             {
                 Id = 14,
                 SurveyQuestionId = 3,
                 IsDeleted = false,
                 CreatedDate = DateTime.Now,
                 ChoiceName = "Kitap okuyarak",

             },
            new SurveyChoice
            {
                Id = 15,
                SurveyQuestionId = 3,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Arkadaşlarıyla buluşarak",

            },



            new SurveyChoice
            {
                Id = 16,
                SurveyQuestionId = 4,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Kayıp parayı bulmak",

            },
            new SurveyChoice
            {
                Id = 17,
                SurveyQuestionId = 4,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Tuttuğu takımın galibiyeti",

            },
            new SurveyChoice
            {
                Id = 18,
                SurveyQuestionId = 4,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Süpriz hediye almak",

            },
             new SurveyChoice
             {
                 Id = 19,
                 SurveyQuestionId = 4,
                 IsDeleted = false,
                 CreatedDate = DateTime.Now,
                 ChoiceName = "Alışveriş mağazasındaki indirimler",

             },
            new SurveyChoice
            {
                Id = 20,
                SurveyQuestionId = 4,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ChoiceName = "Çekilişle telefon kazanmak",

            }
            );

        #endregion

        #region Survey
        modelBuilder.Entity<Survey>().HasData(
            new Survey
            {
                Id = 1,
                UserId = 1,
                SurveyName = "Hazır Anket",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            }
        );
        #endregion


        #region UserSurveyQuestionAnswer
        modelBuilder.Entity<UserSurveyQuestionAnswer>().HasData(
            new UserSurveyQuestionAnswer
            {
                Id = 1,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 1,
                SurveyChoiceId = 1,
                IsPollster = false,
                IsDeleted = false,
                CreatedDate= DateTime.Now
            },
            new UserSurveyQuestionAnswer
            {
                Id = 2,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 2,
                SurveyChoiceId = 8,
                IsPollster = false,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new UserSurveyQuestionAnswer
            {
                Id = 3,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 3,
                SurveyChoiceId = 12,
                IsPollster = false,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new UserSurveyQuestionAnswer
            {
                Id = 4,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 4,
                SurveyChoiceId = 16,
                IsPollster = false,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
        #endregion


        #region UserSurveyQuestionCorrectAnswer
        modelBuilder.Entity<UserSurveyQuestionAnswer>().HasData(
            new UserSurveyQuestionAnswer
            {
                Id = 5,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 1,
                SurveyChoiceId = 2,
                IsPollster = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new UserSurveyQuestionAnswer
            {
                Id = 6,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 2,
                SurveyChoiceId = 9,
                IsPollster = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new UserSurveyQuestionAnswer
            {
                Id = 7,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 3,
                SurveyChoiceId = 12,
                IsPollster = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new UserSurveyQuestionAnswer
            {
                Id = 8,
                AnswerUserId = 1,
                SurveyId = 1,
                SurveyQuestionId = 4,
                SurveyChoiceId = 16,
                IsPollster = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
        #endregion
    }
}