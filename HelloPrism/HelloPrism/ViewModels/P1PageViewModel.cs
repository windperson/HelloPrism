using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPrism.ViewModels
{
    public class P1PageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand SwitchPageCommand { get; set; }

        public P1PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SwitchPageCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("P2Page");
            });
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
