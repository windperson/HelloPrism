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

            NavigationService.NavigateAsync("PrismTabbedPageDemo");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<PrismTabbedPageDemo>();
            Container.RegisterTypeForNavigation<PrismContentPage1>();
            Container.RegisterTypeForNavigation<PrismContentPage2>();
        }
    }
}
