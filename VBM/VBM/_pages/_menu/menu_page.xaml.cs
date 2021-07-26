using Acr.UserDialogs;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._menu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menu_page : ContentPage
    {
        VisualContainer visualContainer;
        vmmenu vm { get; set; }
        public menu_page()
        {
            InitializeComponent();
        }
        public async Task Render()
        {
            vm = new vmmenu();
            this.BindingContext = vm;
            busyindicator.IsVisible = false;
            busyindicator.IsBusy = false;
            await CreateMainEmes();
        }

        
        public async Task CreateMainEmes()    
        {
            foreach(var items in vm.Main_Menu_Class_Objs)
            {
                foreach(var sub in items.lst_sub_menu)
                {
                    if(items.lst_sub_menu.Count == 1)
                    {
                        SfTabItem tabitem = new SfTabItem();
                        tabitem.Title = items.name_vn;
                        emenu lstemenu = new emenu(sub.lst_emes);
                        tabitem.Content = lstemenu;
                        tabview.Items.Add(tabitem);
                    }
                    else
                    {
                        SfTabItem tabitem = new SfTabItem();
                        tabitem.Title = sub.name_vn;
                        emenu lstemenu = new emenu(sub.lst_emes);
                        tabitem.Content = lstemenu;
                        tabview.Items.Add(tabitem);
                    }
                }    
            }    
        }

        private void ff_backicon_tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        async void ff_khachicon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await khachicon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {

                var khachpage = new _pages._home.home_page();
                await Navigation.PushAsync(khachpage);
                khachpage.render();
                this.IsEnabled = true;

                await khachicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch (Exception)
            {
                //error show here
                this.IsEnabled = false;

                await khachicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void ff_promo_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await promoicon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                
                var promopage = new _pages._promo.khuyen_mai_page();
                await Navigation.PushAsync(promopage);
                promopage.Render();
                this.IsEnabled = true;

                await promoicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch(Exception)
            {
                //error show here
                this.IsEnabled = false;

                await promoicon.ScaleTo(1, 100);
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