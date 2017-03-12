using Xamarin.Forms;

namespace HelloPrism.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GotoBtn.Clicked += (s, e) => {
                Navigation.PushAsync(new P2Page(),false);
            };
        }
    }
}
