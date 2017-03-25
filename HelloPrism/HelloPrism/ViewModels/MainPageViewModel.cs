using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloPrism.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public DelegateCommand GotoP2Command { get; set; }
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private EntryCheckViewModel _name;
        public EntryCheckViewModel Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private EntryCheckViewModel _id;
        public EntryCheckViewModel ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private EntryCheckViewModel _email;
        public EntryCheckViewModel Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }


        public MainPageViewModel()
        {
            Name = new EntryCheckViewModel();
            Name.UpdatePlaceHolder("Name");

            ID = new EntryCheckViewModel();
            ID.UpdatePlaceHolder("ID");

            Email = new EntryCheckViewModel();
            Email.UpdatePlaceHolder("Email");
        }
        
    }
}
