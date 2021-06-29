using Acr.UserDialogs;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._vbm_objs._vms._menu;

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
            visualContainer = lstemes.GetVisualContainer();
            lstemes.ScrollStateChanged += ListView_ScrollStateChanged;
        }

        private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
        {
            var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
            var index = (int)lastIndex / 6 + 1;
            changeTitle(index);
        }

        private void ListView_ScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {
            if (e.ScrollState == ScrollState.Dragging)
            {
                var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
                var index = (int)lastIndex / 6 + 1;
                changeTitle(index);
            }
        }
        void changeTitle(int index)
        {
            foreach (var item in vm.titleGroups)
            {
                if (item.index == index)
                {
                    item.Selected = true;
                    lstTitle.ScrollTo((index - 1) * 107, true);
                }
                else
                {
                    item.Selected = false;
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

        async void stlTitle_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            var ctr = sender as StackLayout;
            await ctr.ScaleTo(0.8, 1);
            var cv = (titleGroup)ctr.BindingContext;

            var startIndex = vm.rowsRender.Count;
            var index = cv.index;

            foreach (var item in vm.titleGroups)
            {
                if (item.index == index)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }

            if (vm.rowsRender.Count < index * 6)
            {
                busyindicator.IsVisible = true;
                for (int i = startIndex; i < index * 6; i++)
                {
                    vm.rowsRender.Add(new rowEmesRender(i));
                }
            }
            busyindicator.IsVisible = false;
            lstTitle.ScrollTo((index - 1) * 107, true);
            lstemes.ScrollTo((index - 1) * 220, true);

            await ctr.ScaleTo(1, 250);
            this.IsEnabled = true;
        }
    }
}