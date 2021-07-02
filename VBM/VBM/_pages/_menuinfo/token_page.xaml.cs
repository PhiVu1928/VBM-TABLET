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
    public partial class token_page : ContentPage
    {
        public token_page()
        {
            InitializeComponent();
        }
        private void ff_backicon_tapped (object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
    }
}