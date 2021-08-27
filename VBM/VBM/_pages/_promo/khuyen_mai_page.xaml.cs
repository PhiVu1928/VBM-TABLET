using Acr.UserDialogs;
using Syncfusion.XForms.Border;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._promo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._promo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class khuyen_mai_page : ContentView
    {
        vmpromo vm;
        public khuyen_mai_page()
        {
            InitializeComponent();
        }
        public async Task Render()
        {
            vm = new vmpromo();
            this.BindingContext = vm;
            Device.BeginInvokeOnMainThread(() =>
            {
                RenderPromo();
                busyindicator.IsBusy = false;
                busyindicator.IsVisible = false;
            });            
        }
       
        public async Task RenderPromo()
        {
            lstpromo.ItemsSource = vm.promos;
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var ctr = sender as SfBorder;
            var cv = (vbm.objs.promo_obj)ctr.BindingContext;
            await ctr.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Task.Delay(500);
                    var promo_detail = new VBM._pages._promo.promo_menu();
                    Navigation.PushAsync(promo_detail);
                    promo_detail.Render(cv);
                });
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch
            {
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            
        }
    }
}