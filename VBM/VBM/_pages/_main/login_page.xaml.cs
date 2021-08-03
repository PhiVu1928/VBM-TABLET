using System;
using Acr.UserDialogs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login_page : ContentPage
    {
        VBM._app_objs._vms._login.vmlogin vmlogin;
        public login_page()
        {
            InitializeComponent();
        }

        public async Task Render()
        {
            vmlogin = new _app_objs._vms._login.vmlogin();
            this.BindingContext = vmlogin;
        }
        async void login_Tapped(object sender, EventArgs e)
        {
            await btnlogin.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var outline_page = new _pages._info.outline_page();
                    Navigation.PushAsync(outline_page);
                    outline_page.start_app();
                });
                await btnlogin.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch(Exception)
            {
                await btnlogin.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            
            
        }
    }
}