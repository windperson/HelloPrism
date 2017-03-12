using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

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
            set { SetProperty(ref _userInput, value); }
        }

        ISayHello _sayHello;
        public MainPageViewModel(INavigationService navigationService, ISayHello sayHello)
        {
            _sayHello = sayHello;
            _navigationService = navigationService;
            GotoP2Command = new DelegateCommand(async () =>
            {
                Title = _sayHello.Hello();
                await _navigationService.NavigateAsync($"P2Page?UserInput={UserInput}");
            });
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
