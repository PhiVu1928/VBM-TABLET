using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using VBM._vbm_objs._vms._checkout;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Border;

namespace VBM._pages._thanhtoan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class thanh_toan_page : ContentPage
    {
        vmthanhtoan vm;
        public thanh_toan_page()
        {
            InitializeComponent();
            SizeChanged += MainPageSizeChanged;
        }
        void MainPageSizeChanged(object sender, EventArgs e)
        {
            scroll.WidthRequest = this.Width;
            scroll.HeightRequest = this.Height / 3;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
        }
        public async Task Render()
        {
            vm = new vmthanhtoan();
            BindingContext = vm;
            this.IsEnabled = false;
            var popupThanhToan = new _pages._thanhtoan.hinh_thuc_thanh_toan_page();
            await Navigation.PushPopupAsync(popupThanhToan);
            
            popupThanhToan.Render();
            
            this.IsEnabled = true;
        }
        async void ff_backicon_tapped(object sender, EventArgs e)
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
                    await Navigation.PushAsync(menupage);
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
            catch (Exception)
            {
                //error show here
                await promoicon.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
                this.IsEnabled = false;
            }
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