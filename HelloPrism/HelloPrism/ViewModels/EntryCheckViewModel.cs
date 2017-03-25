using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace HelloPrism.ViewModels
{
    public class EntryCheckViewModel : BindableBase
    {
        private string _myPlaceholderType;
        public string MyPlaceholderType
        {
            get { return _myPlaceholderType; }
            set { SetProperty(ref _myPlaceholderType, value); }
        }

        private string _myPlaceholder;
        public string MyPlaceholder
        {
            get { return _myPlaceholder; }
            set { SetProperty(ref _myPlaceholder, value); }
        }

        private bool _ValueCorrect;
        public bool ValueCorrect
        {
            get { return _ValueCorrect; }
            set { SetProperty(ref _ValueCorrect, value); }
        }

        private string _ValueCorrectSymbol;
        public string ValueCorrectSymbol
        {
            get { return _ValueCorrectSymbol; }
            set { SetProperty(ref _ValueCorrectSymbol, value); }
        }

        private string _myEntryText;
        public string MyEntryText
        {
            get { return _myEntryText; }
            set {
                SetProperty(ref _myEntryText, value);
                if(MyPlaceholderType == "Name")
                {
                    if(MyEntryText.Length < 6)
                    {
                        ValueCorrect = false;
                    }
                    else
                    {
                        ValueCorrect = true;
                    }
                    RefreshSymbolAndBG();
                }
                else if (MyPlaceholderType == "ID")
                    {
                    ValueCorrect = VeirfyID(MyEntryText);
                    RefreshSymbolAndBG();
                }
                else if (MyPlaceholderType == "Email")
                {
                    ValueCorrect = VeirfyEmail(MyEntryText);
                    RefreshSymbolAndBG();
                }
            }
        }

        private Color _valueCorrectBoxBG;
        public Color ValueCorrectBoxBG
        {
            get { return _valueCorrectBoxBG; }
            set { SetProperty(ref _valueCorrectBoxBG, value); }
        }

        private bool VeirfyEmail(string myEntryText)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(myEntryText,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        private bool VeirfyID(string myEntryText)
        {
            var d = false;
            if (myEntryText.Length == 10)
            {
                myEntryText = myEntryText.ToUpper();
                if (myEntryText[0] >= 0x41 && myEntryText[0] <= 0x5A)
                {
                    var a = new[] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                    var b = new int[11];
                    b[1] = a[(myEntryText[0]) - 65] % 10;
                    var c = b[0] = a[(myEntryText[0]) - 65] / 10;
                    for (var i = 1; i <= 9; i++)
                    {
                        b[i + 1] = myEntryText[i] - 48;
                        c += b[i] * (10 - i);
                    }
                    if (((c % 10) + b[10]) % 10 == 0)
                    {
                        d = true;
                    }
                }
            }
            return d;
        }

        public void UpdatePlaceHolder(string pMyPlaceholderType)
        {
            MyPlaceholderType = pMyPlaceholderType;
            if (MyPlaceholderType == "Name")
            {
                MyPlaceholder = "請輸入姓名";
            }
            else if (MyPlaceholderType == "ID")
            {
                MyPlaceholder = "請輸入身分證字號";
            }
            else if (MyPlaceholderType == "Email")
            {
                MyPlaceholder = "請輸入電子郵件信箱";
            }
            else
            {
                MyPlaceholder = "";
            }
        }

        private void RefreshSymbolAndBG()
        {
            if (ValueCorrect == false)
            {
                ValueCorrectSymbol = "X";
                ValueCorrectBoxBG = Color.Red;
            }
            else
            {
                ValueCorrectSymbol = "V";
                ValueCorrectBoxBG = Color.Green;
            }
        }

        public EntryCheckViewModel()
        {
            ValueCorrect = false;
            ValueCorrectSymbol = "X";
            MyPlaceholderType = "";
            MyEntryText = "";
            ValueCorrectBoxBG = Color.Red;
        }
    }
}
