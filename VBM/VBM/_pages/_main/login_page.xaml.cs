using System;
using Acr.UserDialogs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login_page : ContentPage
    {
        public login_page()
        {
            InitializeComponent();
        }

        async void login_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new _pages._info.outline_page());            
        }
    }
}