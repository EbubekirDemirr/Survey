using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication;

namespace WebApi;

public static class AllDependencyInjection
{
    public static IServiceCollection AddInjections(this IServiceCollection services)
    {
        #region ServiceInjections
        services.AddScoped<ISurveyService, SurveyManager>();
        services.AddScoped<ISurveyQuestionService, SurveyQuestionManager>();
        services.AddScoped<ISurveyChoiceService, SurveyChoiceManager>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSurveyQuestionAnswerService, UserSurveyQuestionAnswerManager>();
        services.AddScoped<Business.Abstract.IAuthenticationService, Business.Concrete.AuthenticationService>();
        //services.AddScoped<IUserSurveyQuestionCorrectAnswerService, UserSurveyQuestionCorrectAnswerManager>();
        #endregion


        #region RepositoryInjections
        services.AddScoped<ISurveyQuestionRepository, SurveyQuestionRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ISurveyChoiceRepository, SurveyChoiceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserSurveyQuestionAnswerRepository, UserSurveyQuestionAnswerRepository>();
        services.AddScoped<IAuthenticationServiceRepository, AuthenticationRepository>();
        //services.AddScoped<IUserSurveyQuestionCorrectAnswerRepository, UserSurveyQuestionCorrectAnswerRepository>();
        #endregion

        return services;
    }
}
