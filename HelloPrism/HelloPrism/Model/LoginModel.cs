using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPrism.Models
{
    public class LoginModel : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _account;
        public string Account
        {
            get { return _account; }
            set { SetProperty(ref _account, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private bool _isSaveLogin;
        public bool SaveLogin
        {
            get { return _isSaveLogin; }
            set { SetProperty(ref _isSaveLogin, value); }
        }


        public LoginModel ShallowCopy()
        {
            return (LoginModel) this.MemberwiseClone();
        }
    }
}
