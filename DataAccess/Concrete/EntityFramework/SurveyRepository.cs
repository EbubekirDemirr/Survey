using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.DbEntities;

namespace DataAccess.Concrete.EntityFramework;

public class SurveyRepository : EfEntityRepositoryBase<Survey, ProjectDbContext>, ISurveyRepository
{
    public SurveyRepository(ProjectDbContext context) : base(context)
    {
    }
}
