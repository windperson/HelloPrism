using HelloPrism.Models;
using Newtonsoft.Json;
using PCLStorage;
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
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private LoginModel _loginModel;
        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set { SetProperty(ref _loginModel, value); }
        }

        public DelegateCommand SaveCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginModel = new LoginModel();

            SaveCommand = new DelegateCommand( async () => {
                try
                {
                    IFolder sourceFolder = await FileSystem.Current.LocalStorage.CreateFolderAsync("MyDatas", CreationCollisionOption.ReplaceExisting);
                    IFile sourceFile = await sourceFolder.CreateFileAsync("user_login.dat", CreationCollisionOption.ReplaceExisting);

                    var toSave = LoginModel.ShallowCopy();
                    if (!LoginModel.SaveLogin)
                    {
                        LoginModel.Password = "";
                    }

                    var saveData = JsonConvert.SerializeObject(toSave);

                    await sourceFile.WriteAllTextAsync(saveData);

                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            try
            {
                if(await FileSystem.Current.LocalStorage.CheckExistsAsync("MyDatas") == ExistenceCheckResult.NotFound) {
                    return;
                }

                IFolder sourceFolder = await FileSystem.Current.LocalStorage.GetFolderAsync("MyDatas");
                if(await sourceFolder.CheckExistsAsync("user_login.dat") == ExistenceCheckResult.FileExists)
                {
                    IFile sourceFile = await sourceFolder.GetFileAsync("user_login.dat");
                    var raw = await sourceFile.ReadAllTextAsync();
                    var savedLoginModel = JsonConvert.DeserializeObject<LoginModel>(raw);

                    LoginModel.Name = savedLoginModel.Name;
                    LoginModel.Account = savedLoginModel.Account;
                    LoginModel.Password = savedLoginModel.Password;
                    LoginModel.SaveLogin = savedLoginModel.SaveLogin;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
