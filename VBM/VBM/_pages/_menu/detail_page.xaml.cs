using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Border;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._detail;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detail_page : ContentPage
    {
        vmdetail vm;
        public detail_page()
        {
            InitializeComponent();
        }

        public async Task Render()
        {
            vm = new vmdetail();
            this.BindingContext = vm;
        }

        private void ff_backicon_tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.RemovePage(this);
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
                await promoicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
                this.IsEnabled = true;
            }
            catch (Exception)
            {
                //error show here
                await promoicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
                this.IsEnabled = false;
            }
        }

        async void ff_extras_tapped(object sender, EventArgs e)
        {
            var border = sender as SfBorder;
            var select = (extras)border.BindingContext;
            var cv = select.index;
            foreach (var items in vm.rowExtrasRenders)
            {
                foreach (var itemss in items.extras)
                {
                    if (itemss.index == cv)
                    {
                        itemss.Selected = true;
                    }
                    else
                    {
                        itemss.Selected = false;
                    }
                }
            }
        
            
        }

        async void ff_drink_tapped(object sender, EventArgs e)
        {
            var border = sender as SfBorder;
            var select = (drink)border.BindingContext;
            var cv = select.index;
            foreach (var items in vm.rowsRender)
            {
                foreach (var itemss in items.emes)
                {
                    if (itemss.index == cv)
                    {
                        itemss.Selected = true;
                    }
                    else
                    {
                        itemss.Selected = false;
                    }
                }
            }
        }
        async void ff_size_tapped(object sender, EventArgs e)
        {
            var border = sender as SfBorder;
            var select = (Sizes)border.BindingContext;
            var cv = select.index;
            foreach (var items in vm.rowSizeRenders)
            {
                foreach (var itemss in items.Sizes)
                {
                    if (itemss.index == cv)
                    {
                        itemss.Selected = true;
                    }
                    else
                    {
                        itemss.Selected = false;
                    }
                }
            }


        }


    }
}