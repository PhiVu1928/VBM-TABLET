using System;
using Acr.UserDialogs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._vbm_objs._vms._bills;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menuinfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class danh_sach_don_hang_page : ContentPage
    {
        vmbills vm;
        public danh_sach_don_hang_page()
        {
            InitializeComponent();
        }
        public async Task Render()
        {
            vm = new vmbills();
            BindingContext = vm;
        }
        private void FF_left_Tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        async void ff_donebill_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await btnBill.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                using (var progess = UserDialogs.Instance.Loading("Waiting...", null, null, true, MaskType.Black))
                {
                    await Task.Delay(1000);
                    btnBill.BackgroundColor = (Color)App.Current.Resources["vbmgreen"];
                    lblbilltiem.TextColor = (Color)App.Current.Resources["vbmwhite"];
                    btnbillwaiting.BackgroundColor = (Color)App.Current.Resources["vbmdeeplightgray"];
                    lblbillwaiting.TextColor = (Color)App.Current.Resources["vbmwhite"];
                    var bill = vm.bills.Where(x => x.Selected == true);
                    sfbill.ItemsSource = bill.ToList();
                    this.IsEnabled = true;
                    await btnBill.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }
            }
            catch
            {
                //error show here
                this.IsEnabled = true;
                await btnBill.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
        async void ff_billwaiting_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await btnbillwaiting.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                using (var progess = UserDialogs.Instance.Loading("Waiting...", null, null, true, MaskType.Black))
                {
                    await Task.Delay(1000);
                    btnBill.BackgroundColor = (Color)App.Current.Resources["vbmdeeplightgray"];
                    lblbilltiem.TextColor = (Color)App.Current.Resources["vbmwhite"];
                    btnbillwaiting.BackgroundColor = (Color)App.Current.Resources["vbmgreen"];
                    lblbillwaiting.TextColor = (Color)App.Current.Resources["vbmwhite"];
                    var bill = vm.bills.Where(x => x.Selected == false);
                    sfbill.ItemsSource = bill.ToList();
                    this.IsEnabled = true;
                    await btnbillwaiting.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }
            }
            catch
            {
                //error show here
                this.IsEnabled = true;
                await btnbillwaiting.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

    }
}