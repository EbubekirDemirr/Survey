using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.DbEntities.Users;

namespace DataAccess.Concrete.EntityFramework;

public class UserSurveyQuestionAnswerRepository : EfEntityRepositoryBase<UserSurveyQuestionAnswer, ProjectDbContext>, IUserSurveyQuestionAnswerRepository
{
    public UserSurveyQuestionAnswerRepository(ProjectDbContext context) : base(context)
    {
    }
}
