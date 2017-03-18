using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace HelloPrism.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand GotoP2Command { get; set; }
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _userInput;

        public string UserInput
        {
            get { return _userInput; }
            set {
                SetProperty(ref _userInput, value);
                if(value.Length < 5)
                {
                    InputColor = Color.Red;
                }
                else
                {
                    InputColor = Color.Black;
                }
            }
        }

        private Color _inputColor;
        public Color InputColor
        {
            get { return _inputColor; }
            set { SetProperty(ref _inputColor, value); }
        }


        public MainPageViewModel(INavigationService navigationService)
        {
            InputColor = Color.Red;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
