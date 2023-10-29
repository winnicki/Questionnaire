using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.ViewModels;
using Questionnaire.Views;

namespace Questionnaire;

public partial class QuestionView : ContentPageBase
{
    public QuestionView(QuestionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}