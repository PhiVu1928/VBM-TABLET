using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._thanhtoan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cart_item_page : ContentView
    {
        VBM._app_objs._vms._checkout.vmthanhtoan vmthanhtoan;
        public cart_item_page()
        {
            InitializeComponent();
        }
    }
}