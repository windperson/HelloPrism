using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPrism.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        public DelegateCommand SwitchPageCommand { get; set; }
        public DelegateCommand DeepNaviCommand { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SwitchPageCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("P1Page");
            });
            DeepNaviCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync(new Uri("P1Page/P2Page/P3Page", UriKind.Relative),
                    useModalNavigation: true, animated: true);
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
