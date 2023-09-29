using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.DbEntities;

namespace DataAccess.Concrete.EntityFramework;

public class SurveyQuestionRepository : EfEntityRepositoryBase<SurveyQuestion, ProjectDbContext>, ISurveyQuestionRepository
{
    public SurveyQuestionRepository(ProjectDbContext context) : base(context)
    {
    }
}
