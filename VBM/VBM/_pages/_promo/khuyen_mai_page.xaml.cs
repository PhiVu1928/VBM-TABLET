using Acr.UserDialogs;
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
            await Task.Delay(2000);
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
  


    }
}