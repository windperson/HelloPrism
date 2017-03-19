using HelloPrism.DataEntities;
using Prism.Commands;
using Prism.Events;
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
        private readonly IEventAggregator _eventAggregator;

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

        private Student _selectedItem;
        public Student SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public DelegateCommand ListItemTapCommand { get; private set; }
        public DelegateCommand<Student> DeleteCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggrgator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggrgator;

            ListItemTapCommand = new DelegateCommand(async () =>
            {
                var param = new NavigationParameters();
                param.Add("Stub", SelectedItem);
                await _navigationService.NavigateAsync("EditItemPage", param);
            });

            DeleteCommand = new DelegateCommand<Student>((student) => {
                Students.Remove(student);
            });

            _eventAggregator.GetEvent<UpdateDataEvent>().Subscribe((student) =>
            {
                if(SelectedItem != null)
                {
                    var index = _students.IndexOf(SelectedItem);
                    _students[index] = student;
                }
            });

            for (int i = 1; i <= 50; i++)
            {
                _students.Add(new Student
                {
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
