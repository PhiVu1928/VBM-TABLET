using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._vbm_objs._vms._home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home_page : ContentPage
    {
        vmhome vm { get; set; }
        public home_page()
        {
            InitializeComponent();
        }
        public async Task render()
        {
            vm = new vmhome();
            this.BindingContext = vm;
        }

        private void ff_backicon_tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }      

        async void ff_hisicon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
           
            try
            {
                his.Source = "historyiconpress";
                var historypage = new _home.historypage();
                this.IsEnabled = true;
                stlhome.Children.Clear();
                stlhome.Children.Add(new historypage());
                gift.Source = "gifticon";             

            }
            catch
            {
                //error show here
                
            }
        }

        async void ff_gifticon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;            
            try
            {
                his.Source = "historyicon";
                gift.Source = "gifticonpress";
                var giftpage = new _home.gift_page();
                this.IsEnabled = true;
                stlhome.Children.Clear();
                stlhome.Children.Add(new gift_page());          
            }
            catch
            {
                //error show here
               
            }
        }
        async void ff_menuicon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await menuicon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                using (var progress = UserDialogs.Instance.Loading("Loading...", null, null, true, MaskType.Black))
                {
                    var menupage = new _pages._menu.menu_page();
                    await Navigation.PushAsync(menupage,true);
                    menupage.Render();
                    this.IsEnabled = true;

                    await menuicon.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }                  
            }
            catch
            {
                //error show here
                await menuicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
        async void ff_promoicon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await menuicon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {

                var promopage = new _pages._promo.khuyen_mai_page();
                await Navigation.PushAsync(promopage);
                promopage.Render();
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

        async void ff_cart_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await carticon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {

                var cartpage = new _pages._thanhtoan.thanh_toan_page();
                await Navigation.PushAsync(cartpage,true);
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