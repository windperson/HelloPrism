using Prism.Unity;
using HelloPrism.Views;

namespace HelloPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPrismNaviPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<P1Page>();
            Container.RegisterTypeForNavigation<P2Page>();
            Container.RegisterTypeForNavigation<P3Page>();
            Container.RegisterTypeForNavigation<MainPrismNaviPage>();
        }
    }
}
