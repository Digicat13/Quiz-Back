using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.MapperProfiles;

namespace QuizApp.ServiceExtensions
{
    public static class MapperExtension
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TestProfile());
                mc.AddProfile(new TestQuestionProfile());
                mc.AddProfile(new TestAnswerProfile());
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new TestingProfile());
                mc.AddProfile(new TestingResultAnswerProfile());
                mc.AddProfile(new TestingResultProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
