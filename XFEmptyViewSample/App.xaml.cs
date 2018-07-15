using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFEmptyViewSample.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFEmptyViewSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListViewPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
