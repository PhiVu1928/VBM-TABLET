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
    public partial class chuan_bi_nguyen_lieu_page : ContentPage
    {
        public chuan_bi_nguyen_lieu_page()
        {
            InitializeComponent();
        }

        private void ff_backicon_tapped(object sender, EventArgs e)
        {
             Navigation.RemovePage(this);
        }
    }
}