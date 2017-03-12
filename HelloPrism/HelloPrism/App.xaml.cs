using Prism.Unity;
using HelloPrism.Views;
using Xamarin.Forms;

namespace HelloPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<P2Page>();
        }
    }
}
