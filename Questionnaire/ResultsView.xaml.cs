using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.ViewModels;
using Questionnaire.Views;

namespace Questionnaire;

public partial class ResultsView : ContentPageBase
{
    public ResultsView(ResultsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}