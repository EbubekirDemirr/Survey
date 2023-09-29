using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.DbEntities;

namespace DataAccess.Concrete.EntityFramework;

public class SurveyChoiceRepository : EfEntityRepositoryBase<SurveyChoice, ProjectDbContext>, ISurveyChoiceRepository
{
    public SurveyChoiceRepository(ProjectDbContext context) : base(context)
    {
    }
}
