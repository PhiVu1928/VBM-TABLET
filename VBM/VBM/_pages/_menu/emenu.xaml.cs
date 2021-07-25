using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class emenu : ContentView
    {
        public emenu(List<vbm.objs.e_menu_obj> e_Menu_Obj)
        {
            InitializeComponent();
            lstemes.ItemsSource = e_Menu_Obj;
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var detail = new _pages._menu.detail_page();
            await Navigation.PushAsync(detail);
            detail.Render();
        }
    }
}