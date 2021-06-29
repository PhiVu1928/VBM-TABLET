using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cover_page : ContentPage
    {
        public cover_page()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            start_app();
        }
        async void start_app()
        {
            await Task.Delay(1000);
            await Navigation.PushAsync(new _main.login_page());
        }
    }
}