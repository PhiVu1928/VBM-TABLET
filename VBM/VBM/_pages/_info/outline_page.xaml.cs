using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._info
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class outline_page : FlyoutPage
    {
        public outline_page()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            localdb._manager = new _app_objs._general.app_manager();
            localdb._manager._contents._outline_page = this;
            Task.Run(() =>
            {
                localdb._manager._cached.get_cached_values();
                localdb._manager._tools.start_prepare_data();
            });
        }
        public async void start_app()
        {
            await Task.Delay(1000);
            var hpage = new VBM._pages._info.info_page();
            flypage.Detail = hpage;
            var fpage = new VBM._pages._info.menu_info_page();
            flypage.Flyout = fpage;
            flypage.Title = "vbm";
        }

        public void open_flyout()
        {
            flypage.IsPresented = true;
        }

    }
}