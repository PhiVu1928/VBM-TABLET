using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._vbm_objs._vms._promo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._promo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class khuyen_mai_page : ContentPage
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
        }

        private void ff_backicon_tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
        async void ff_khachicon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await menuicon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
               
                var homepage = new _pages._home.home_page();
                await Navigation.PushAsync(homepage);
                this.IsEnabled = true;

                await menuicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch
            {
                //error show here
                await menuicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void ff_menuicon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await menuicon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {

                var menupage = new _pages._menu.menu_page();
                await Navigation.PushAsync(menupage);
                menupage.Render();
                this.IsEnabled = true;
                await menuicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);


            }
            catch
            {
                //error show here
                await menuicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
        async void ff_cart_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await carticon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {

                var cartpage = new _pages._thanhtoan.thanh_toan_page();
                await Navigation.PushAsync(cartpage, true);
                cartpage.Render();
                this.IsEnabled = true;

                await menuicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);

            }
            catch
            {
                this.IsEnabled = false;
                //error show here
                await menuicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }


    }
}