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

        async void stl_title_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var title = sender as StackLayout;
            await title.ScaleTo(0.8, 1);
            var selected = (MenuTab)title.BindingContext;
            foreach(var items in vm.menuTabs)
            {
                if (items.Index == selected.Index)
                {
                    if (selected.Index == 0)
                    {
                        stlHomeMenu.Children.Clear();
                        items.Selected = true;
                        stlHomeMenu.Children.Add(new _pages._home.customer_page());
                    }
                    if (selected.Index == 1)
                    {
                        stlHomeMenu.Children.Clear();
                        items.Selected = true;
                        stlHomeMenu.Children.Add(new _pages._home.script_page());
                    }
                    if (selected.Index == 2)
                    {
                        stlHomeMenu.Children.Clear();
                        items.Selected = true;
                        stlHomeMenu.Children.Add(new _pages._home.gift_page());
                    }                    
                    if (selected.Index == 3)
                    {
                        stlHomeMenu.Children.Clear();
                        items.Selected = true;
                        stlHomeMenu.Children.Add(new _pages._home.historypage());
                    }                   
                }
                else
                {
                    items.Selected = false;
                }
            }
            await title.ScaleTo(1, 250);
            this.IsEnabled = true;
        }
    }
}