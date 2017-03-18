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
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DateTime _date;
        public DateTime TheDate
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private TimeSpan _time;
        public TimeSpan TheTime
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        public MainPageViewModel()
        {
            TheDate = DateTime.Now;
            TheTime = TheDate.TimeOfDay;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
            {
                Title = (string)parameters["title"] + " and Prism";
            }
        }
    }
}
