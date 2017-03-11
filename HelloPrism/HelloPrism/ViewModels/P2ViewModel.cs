using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloPrism.ViewModels.Views
{
    public class P2ViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public String Title {
            get {
                return _title;
            }
            set {
                SetProperty(ref _title, value);
            }
        }

        public P2ViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
