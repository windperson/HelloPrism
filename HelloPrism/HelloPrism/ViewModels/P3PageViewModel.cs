using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPrism.ViewModels
{
    public class P3PageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public P3PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await ViewModelInit();
        }

        private async Task ViewModelInit()
        {
            await Task.Delay(1000);
        }
    }
}
