using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloPrism.ViewModels
{
    public class P2PageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand SwitchPageCommand { get; set; }

        public P2PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SwitchPageCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("P3Page");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
               }
    }
}
