using Core.DataAccess;
using Entities.Concrete.DbEntities.Users;

namespace DataAccess.Abstract;

public interface IUserSurveyQuestionAnswerRepository : IEntityRepository<UserSurveyQuestionAnswer>
{
}
