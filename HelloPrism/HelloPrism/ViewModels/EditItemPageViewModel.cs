using HelloPrism.DataEntities;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloPrism.ViewModels
{
    public class EditItemPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Student _student;
        public Student Student
        {
            get { return _student; }
            set { SetProperty(ref _student, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public EditItemPageViewModel(INavigationService navigationService,IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            UpdateCommand = new DelegateCommand(async () => {
                _eventAggregator.GetEvent<UpdateDataEvent>().Publish(Student);
                await _navigationService.GoBackAsync();
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Stub"))
            {
                Student = parameters["Stub"] as Student;
                Title = $"Student {Student.Name}'s data";
            }

        }
    }
}
