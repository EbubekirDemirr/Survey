using AutoMapper;
using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.DbEntities;
using Entities.Concrete.Models.SurveyChoiceModels;
using Entities.Concrete.Models.SurveyModels;
using Entities.Concrete.Models.SurveyQuestionModels;
using Entities.Concrete.Models.UsersModels;

namespace Business.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        #region Survey
        CreateMap<Survey, SurveyViewModel>().ReverseMap();
        CreateMap<Survey, CreateSurveyModel>().ReverseMap();
        CreateMap<Survey, UpdateSurveyModel>().ReverseMap();
        CreateMap<Survey, DeleteSurveyModel>().ReverseMap();
        CreateMap<SurveyViewModel, CreateSurveyModel>().ReverseMap();
        CreateMap<SurveyQuestionViewModel, CreateSurveyQuestionModel>().ReverseMap();
        #endregion

        #region SurveyQuestion
        CreateMap<SurveyQuestion, SurveyQuestionViewModel>().ReverseMap();
        CreateMap<SurveyQuestion, CreateSurveyQuestionModel>().ReverseMap();
        CreateMap<SurveyQuestion, UpdateSurveyQuestionModel>().ReverseMap();
        CreateMap<SurveyQuestion, DeleteSurveyQuestionModel>().ReverseMap();
        #endregion

        #region SurveyChoice
        CreateMap<SurveyChoice, SurveyChoiceViewModel>().ReverseMap();
        CreateMap<CreateSurveyChoiceModel, SurveyChoice>().ForMember(dest => dest.SurveyQuestionId, opt => opt.MapFrom(src => src.QuestionId));
        CreateMap<SurveyChoiceViewModel, CreateSurveyChoiceModel>().ReverseMap();
        CreateMap<SurveyChoice, UpdateSurveyChoiceModel>().ReverseMap();
        CreateMap<SurveyChoice, DeleteSurveyChoiceModel>().ReverseMap();
        CreateMap<SurveyChoice, DeleteSurveyChoiceModel>().ReverseMap();
        
        #endregion

        #region User
        CreateMap<User, CreateUserModel>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();
        #endregion

        #region UserSurveyQuestionAnswer
        CreateMap<UserSurveyQuestionAnswer, UserSurveyQuestionAnswerViewModel>().ReverseMap();
        CreateMap<UserSurveyQuestionAnswer, CreateUserSurveyQuestionAnswerModel>().ReverseMap();
        CreateMap<UserSurveyQuestionAnswer, UpdateUserSurveyQuestionAnswerModel>().ReverseMap();
        CreateMap<UserSurveyQuestionAnswer, DeleteUserSurveyQuestionAnswerModel>().ReverseMap();
        #endregion

        #region UserSurveyQuestionCorrectAnswer
 
        CreateMap<UserSurveyQuestionAnswerViewModel, CreateUserSurveyQuestionAnswerModel>().ReverseMap();
        #endregion
    }
}
