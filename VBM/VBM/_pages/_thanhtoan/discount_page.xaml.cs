﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using VBM._app_objs._vms._checkout;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._thanhtoan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class discount_page : Rg.Plugins.Popup.Pages.PopupPage
    {
        vmthanhtoan vm;
        public discount_page()
        {
            InitializeComponent();
        }
        public async Task Render()
        {
            vm = new vmthanhtoan();
            BindingContext = vm;
        }
        async void ff_close_tapped(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var items = sender as StackLayout;
            var selected = (Discount)items.BindingContext;
            foreach(var item in vm.discounts)
            {
                if(item.Index == selected.Index)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
    }
}