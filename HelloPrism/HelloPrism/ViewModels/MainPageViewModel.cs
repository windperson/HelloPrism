using HelloPrism.DataEntities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HelloPrism.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Student> _students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { SetProperty(ref _students, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
            for(int i = 1; i <= 50; i++)
            {
                _students.Add(new Student {
                    Name = "st" + i,
                    ID = "ID00" + i,
                    Age = (uint)(10 + i)
                });
            }
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
