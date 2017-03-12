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
        public DelegateCommand LoginCommand { get; set; }
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _account = "";
        public string Account
        {
            get { return _account; }
            set {
                SetProperty(ref _account, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private string _enterAccount="please input account";
        public string EnterAccount
        {
            get { return _enterAccount; }
            set { SetProperty(ref _enterAccount, value); }
        }


        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync($"Page2?Account={Account}");
            },() => {
                return !String.IsNullOrEmpty(_account);
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
