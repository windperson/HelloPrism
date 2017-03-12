using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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

        public DelegateCommand SelectCommand { get; set; }
        public DelegateCommand WarningCommand { get; set; }

        public readonly IPageDialogService _dialogService;
        public P2PageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            Title = "This is P2";

            SelectCommand = new DelegateCommand(async() => {
                string fooResult = await _dialogService.DisplayActionSheetAsync("Information", "Cancel", null, new string[] { "Option1", "Option2", "Option3" });
                if (string.IsNullOrEmpty(fooResult) == false)
                {
                    Title = fooResult;
                }

            });

            WarningCommand = new DelegateCommand(() => {
                _dialogService.DisplayAlertAsync("Warning", "This is DisplayAlertAsync()", "OK", "Cancel");
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
