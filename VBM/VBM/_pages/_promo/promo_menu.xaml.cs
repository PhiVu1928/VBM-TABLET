using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._promo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._promo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class promo_menu : ContentPage
    {
        vmpromomenu vmpromomenu;
        public promo_menu()
        {
            InitializeComponent();
        }
        public async Task Render(vbm.objs.promo_obj promo_Obj)
        {
            vmpromomenu = new vmpromomenu(promo_Obj);
            this.BindingContext = vmpromomenu;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
        async void GrPromoItemTapped(object sender, EventArgs e)
        {
            var ctr = sender as Grid;
            await ctr.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                using (var progress = UserDialogs.Instance.Loading("Loading...", null, null, true, MaskType.Black))
                {
                    var cv = (vbm.objs.promo_emenus)ctr.BindingContext;
                    var PromoDetail = new VBM._pages._menu.detail_page();
                    await Navigation.PushAsync(PromoDetail);
                    PromoDetail.RenderPromo(cv);
                }                   
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
            catch
            {
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
    }
}