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
        private bool _isText1=true;
        public bool RenderText1
        {
            get { return _isText1; }
            set { SetProperty(ref _isText1, value); }
        }

        private double _text1Opacity = 1.0;
        public double HideText1
        {
            get { return _text1Opacity; }
            set { SetProperty(ref _text1Opacity, value); }
        }

        private double _text2Opacity = 1.0;
        public double HideText2
        {
            get { return _text2Opacity; }
            set { SetProperty(ref _text2Opacity, value); }
        }

        private bool _isText2 = true;
        public bool RenderText2
        {
            get { return _isText2; }
            set { SetProperty(ref _isText2, value); }
        }

        public DelegateCommand ToggleText1Command { get; set; }
        public DelegateCommand ToggleText2Command { get; set; }

        public DelegateCommand HideText1Command { get; set; }
        public DelegateCommand HideText2Command { get; set; }


        public MainPageViewModel()
        {
            ToggleText1Command = new DelegateCommand(() => { RenderText1 = !RenderText1; });
            ToggleText2Command = new DelegateCommand(() => { RenderText2 = !RenderText2; });
            HideText1Command = new DelegateCommand(() => {
                if(HideText1 > 0.0 )
                {
                    HideText1 = 0.0;
                }
                else
                {
                    HideText1 = 1.0;
                }
            });
            HideText2Command = new DelegateCommand(() => {
                if (HideText2 > 0.0)
                {
                    HideText2 = 0.0;
                }
                else
                {
                    HideText2 = 1.0;
                }
            });
        }
    }
}
