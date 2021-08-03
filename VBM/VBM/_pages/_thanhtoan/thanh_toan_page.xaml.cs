using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using VBM._app_objs._vms._checkout;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Border;

namespace VBM._pages._thanhtoan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class thanh_toan_page : ContentView
    {
        vmthanhtoan vm;
        public thanh_toan_page()
        {
            InitializeComponent();
        }
        
        public async Task Render()
        {
            await Task.Delay(2000);
            vm = new vmthanhtoan();
            BindingContext = vm;
            Giohang();
            busyindicator.IsBusy = false;
            busyindicator.IsVisible = false;
        }
        public async Task Giohang()
        {
            Lstgiohang.ItemsSource = vm.cart_Temps;
        }
        async void ff_thanhtoan_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await borderwallet.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                borderwallet.BackgroundColor = (Color)Application.Current.Resources["vbmgreen"];
                walleticon.Source = "walleticonvang";
                labelwallet.TextColor = (Color)Application.Current.Resources["vbmwhite"];
                var page = new _pages._thanhtoan.hinh_thuc_thanh_toan_page();
                await Navigation.PushPopupAsync(page);
                page.Render();
                this.IsEnabled = true;

                await borderwallet.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch
            {
                //erros show here
                await borderwallet.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
        async void ff_discount_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await vouchericon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                voucherborder.BackgroundColor = (Color)Application.Current.Resources["vbmgreen"];
                vouchericon.Source = "vouchericonvang";
                voucherlable.TextColor = (Color)Application.Current.Resources["vbmwhite"];
                var page = new _pages._thanhtoan.discount_page();
                await Navigation.PushPopupAsync(page);
                page.Render();
                this.IsEnabled = true;

                await vouchericon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch
            {
                //erros show here
                await vouchericon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void ff_hoadon_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await brhoadon.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                brhoadon.BackgroundColor = (Color)Application.Current.Resources["vbmlightyellow"];
                lblhoadon.TextColor = (Color)Application.Current.Resources["vbmgreen"];
                var popuphoadon = new _pages._thanhtoan.hoa_don_page();
                await Navigation.PushPopupAsync(popuphoadon);
                this.IsEnabled = true;                

                brcombo.BackgroundColor = (Color)Application.Current.Resources["vbmlightgray"];
                lblcombo.TextColor = (Color)Application.Current.Resources["vbmgray"];
            }
            catch(Exception)
            {
                //error show here
                this.IsEnabled = false;
                await brhoadon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            
        }
        public void ff_combo_tapped(object sender, EventArgs e)
        {
            brcombo.BackgroundColor = (Color)Application.Current.Resources["vbmlightyellow"];
            lblcombo.TextColor = (Color)Application.Current.Resources["vbmgreen"];

            brhoadon.BackgroundColor = (Color)Application.Current.Resources["vbmlightgray"];
            lblhoadon.TextColor = (Color)Application.Current.Resources["vbmgray"];
        }

        

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var itemss = sender as SfBorder;
            var selected = (PTTT)itemss.BindingContext;
            foreach (var items in vm.pTTTs)
            {
                if (items.Index == selected.Index)
                {
                    items.Selected = true;
                }
                else
                {
                    items.Selected = false;
                }
            }
        }
    }
}