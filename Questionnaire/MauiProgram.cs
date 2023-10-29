using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Questionnaire.Services.Answers;
using Questionnaire.Services.Navigation;
using Questionnaire.Services.Questions;
using Questionnaire.ViewModels;

namespace Questionnaire;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        mauiAppBuilder.Services.AddSingleton<IQuestionService, QuestionService>();
        mauiAppBuilder.Services.AddSingleton<IQuestionDatabase, QuestionDatabase>();
        mauiAppBuilder.Services.AddSingleton<IAnswerService, AnswerService>();
        mauiAppBuilder.Services.AddSingleton<IAnswerDatabase, AnswerDatabase>();

        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainViewModel>();
        mauiAppBuilder.Services.AddTransient<QuestionViewModel>();

        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<MainView>();
        mauiAppBuilder.Services.AddTransient<QuestionView>();

        return mauiAppBuilder;
    }
}