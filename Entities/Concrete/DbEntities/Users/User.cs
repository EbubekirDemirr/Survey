
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete.DbEntities.Users;

public class User : IdentityUser<long>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? TokenCreatedDate { get; set; }
    public DateTime? TokenExpires { get; set; }

    public bool IsDeleted { get; set; }
    public ICollection<UserSurveyQuestionAnswer>? UserSurveyQuestionAnswers { get; set; }
    public ICollection<Survey> Surveys { get; set; }
}
