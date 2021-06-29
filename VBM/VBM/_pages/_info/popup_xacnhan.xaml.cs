using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Rg.Plugins.Popup.Extensions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._info
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popup_xacnhan : Rg.Plugins.Popup.Pages.PopupPage
    {
        public popup_xacnhan()
        {
            InitializeComponent();
        }

        async void ff_ok_tapped(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            await xacnhan.ScaleTo(0.9, 1);
            await xacnhan.FadeTo(0.9, 1);
            try
            {
                using (var process = UserDialogs.Instance.Loading("Loading...", null, null, true, MaskType.Black))
                {
                    var xacnhanpage = new _pages._home.home_page();
                    await Navigation.PushAsync(xacnhanpage);
                    xacnhanpage.render();
                    await Navigation.RemovePopupPageAsync(this);
                    this.IsEnabled = true;
                    await xacnhan.ScaleTo(1, 100);
                    await this.FadeTo(1, 100);
                }
            }
            catch (Exception)
            {
                this.IsEnabled = true;
                await xacnhan.ScaleTo(1, 100);
                await xacnhan.FadeTo(1, 100);
            }
        }
        async void ff_close_tapped(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}