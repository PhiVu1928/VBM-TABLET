using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cover_page : ContentPage
    {
        public cover_page()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            localdb._manager = new _app_objs._general.app_manager();
            localdb._manager._contents._cover_page = this;
            Task.Run(() =>
            {
                localdb._manager._cached.get_cached_values();
                localdb._manager._tools.start_prepare_data();
            });
        }
        public async void start_app()
        {
            await Task.Delay(1000);
            var login_page = new _main.login_page();
            await Navigation.PushAsync(login_page);
            login_page.Render();
        }
    }
}