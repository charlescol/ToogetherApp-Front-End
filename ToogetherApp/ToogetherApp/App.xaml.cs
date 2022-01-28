using BusinessLogicLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToogetherApp.Views;
using Xamarin.Forms;

namespace ToogetherApp
{
    public partial class App : Application
    {
 
        public App()
        {
            InitializeComponent();
            AppLogic.Initialize(DependencyService.Get<DataLayer.SQLLite.ISQLLite>());

            //Task.Run(() => Services.EventQuery.EventQuery.FromHttpToDatabaseAsync());

            //MainPage = new AppShell();
            MainPage = new CreateProfileContentPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
