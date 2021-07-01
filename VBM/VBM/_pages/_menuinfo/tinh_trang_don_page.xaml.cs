using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menuinfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class tinh_trang_don_page : ContentPage
    {
        public tinh_trang_don_page()
        {
            InitializeComponent();
        }

        private void FF_left_Tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        async void sf_bill_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await btnBill.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                var page = new _pages._menuinfo.danh_sach_don_hang_page();
                await Navigation.PushAsync(page);
                this.IsEnabled = true;
                await btnBill.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch
            {
                //error show here
                this.IsEnabled = true;
                await btnBill.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void sf_billdeli_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await btnbilldeli.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                var page = new _pages._menuinfo.danh_sach_don_hang_page();
                await Navigation.PushAsync(page);
                this.IsEnabled = true;
                await btnbilldeli.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch
            {
                //error show here
                this.IsEnabled = true;
                await btnbilldeli.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

    }
}