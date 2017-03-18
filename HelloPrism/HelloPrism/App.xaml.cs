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

            NavigationService.NavigateAsync("PrismMasterDetailPageDemo/PrismNavPage/ContentPage1");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<PrismMasterDetailPageDemo>();
            Container.RegisterTypeForNavigation<ContentPage1>();
            Container.RegisterTypeForNavigation<PrismNavPage>();
        }
    }
}
