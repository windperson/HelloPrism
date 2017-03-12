using Prism.Commands;
using Prism.Events;
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

        private readonly IEventAggregator _eventAggregator;
        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<GoBackEvent>().Subscribe((evt) => {
                Title = $"SubData={evt}";
            });

            GotoP2Command = new DelegateCommand(async () =>
            {
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
