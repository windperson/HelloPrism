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
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _param;

        public string Param
        {
            get { return _param; }
            set { SetProperty(ref _param, value); }
        }


        public P2PageViewModel()
        {
            Title = "This is P2";
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("UserInput"))
            {
                Param = parameters["UserInput"] as string;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
