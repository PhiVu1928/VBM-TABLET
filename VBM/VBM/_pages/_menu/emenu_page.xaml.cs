using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._vms._menu;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class emenu_page : ContentView
    {
        vmmenu vmmenu;
        public emenu_page()
        {
            InitializeComponent();            
        }
        public async Task Rendermenu(List<vbm.objs.e_menu_obj> e_Menu_Obj)
        {
            vmmenu = new vmmenu();
            this.BindingContext = vmmenu;
            foreach (var item in e_Menu_Obj.Where(x => x.img != ""))
            {
                vmmenu.E_Menu_Objs.Add(item);
            }
        }            
            

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var ctr = sender as Grid;
            await ctr.ScaleTo(0.8, 1);
            this.FadeTo(0.8, 1);
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var cv = (vbm.objs.e_menu_obj)ctr.BindingContext;
                    var detail = new _pages._menu.detail_page();
                    Navigation.PushAsync(detail);
                    detail.Render(cv);
                });                
                await ctr.ScaleTo(1, 100);
                this.FadeTo(1, 100);
            }
            catch(Exception)
            {
                await ctr.ScaleTo(1, 100);
                this.FadeTo(1, 100);
            }
            
        }
    }
}