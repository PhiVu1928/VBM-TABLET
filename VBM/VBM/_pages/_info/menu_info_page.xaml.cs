using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._info
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menu_info_page : ContentPage
    {
        public menu_info_page()
        {
            InitializeComponent();
        }

        async void Tinhtrangdon_Tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await tinhtrang.ScaleTo(0.9, 1);
            await tinhtrang.FadeTo(0.9, 1);
            try
            {
                using(var process = UserDialogs.Instance.Loading("Loading...",null,null,true,MaskType.Black))
                {
                    var tinhtrangpage = new _pages._menuinfo.tinh_trang_don_page();
                    await Navigation.PushAsync(tinhtrangpage);
                    this.IsEnabled = true;
                    await tinhtrang.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }
            }
            catch(Exception)
            {
                this.IsEnabled = true;
                await tinhtrang.ScaleTo(1, 100);
                await tinhtrang.FadeTo(1, 100);
            }
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await ready.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                using (var progress = UserDialogs.Instance.Loading("Loading...", null, null, true, MaskType.Black))
                {
                    var chuanbi = new _pages._menuinfo.chuan_bi_nguyen_lieu_page();
                    await Navigation.PushAsync(chuanbi);
                    this.IsEnabled = true;
                    await ready.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }
            }
            catch
            {
                //alert
                //log error
                this.IsEnabled = true;
                await ready.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
    }
}
