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
    public partial class makeline_page : ContentPage
    {
        public makeline_page()
        {
            InitializeComponent();
        }

        private void ffimg_right_tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
        private void ffimg_left_tapped(object sender, EventArgs e)
        {
            localdb._manager._contents._outline_page.open_flyout();
        }
    }
}