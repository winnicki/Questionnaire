using Questionnaire.ViewModels;

namespace Questionnaire.Views;

public abstract class ContentPageBase : ContentPage
{
    public ContentPageBase()
    {
        NavigationPage.SetBackButtonTitle(this, string.Empty);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        if (BindingContext is not IViewModelBase viewModel)
        {
            return;
        }

        viewModel.InitializeAsyncCommand.Execute(null);
    }
}