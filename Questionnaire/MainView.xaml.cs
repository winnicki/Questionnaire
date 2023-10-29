using Questionnaire.ViewModels;
using Questionnaire.Views;

namespace Questionnaire;

public partial class MainView : ContentPageBase
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}