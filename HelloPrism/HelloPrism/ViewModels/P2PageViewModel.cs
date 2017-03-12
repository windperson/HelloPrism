using Prism.Commands;
using Prism.Events;
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

        private string _subData;
        public string SubData
        {
            get { return _subData; }
            set { SetProperty(ref _subData, value); }
        }

        public DelegateCommand GoBackCommand { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public P2PageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            Title = "This is P2";

            GoBackCommand = new DelegateCommand(() => {
                _eventAggregator.GetEvent<GoBackEvent>().Publish(SubData);
                _navigationService.GoBackAsync();
            });
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
    }
}
