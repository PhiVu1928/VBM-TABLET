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
        public async Task Render()
        {
            vmthanhtoan = new _app_objs._vms._checkout.vmthanhtoan();
            this.BindingContext = vmthanhtoan;
        }
        async void lbldeletecart_tapped(object sender, EventArgs e)
        {
            var ctr = sender as Label;
            await ctr.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                var cv = (VBM._app_objs._general.cart_temp)ctr.BindingContext;
                localdb._manager._varialbles._cart_temp.Remove(cv);
                vmthanhtoan.Rendergiohang();
            }
            catch(Exception)
            {
                //log error
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void lbldecreasecartitem_tapped(object sender, EventArgs e)
        {
            var ctr = sender as Label;
            await ctr.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                var cv = (VBM._app_objs._general.cart_temp)ctr.BindingContext;
                var index = cv.index;
                foreach (var item in vmthanhtoan.cart_Temps)
                {
                    if (index == item.index)
                    {
                        item.item_sl--;
                    }
                    else { }
                }
            }
            catch (Exception)
            {
                //log error
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }

        async void lblincreasecartitem_tapped(object sender, EventArgs e)
        {
            var ctr = sender as Label;
            await ctr.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                var cv = (VBM._app_objs._general.cart_temp)ctr.BindingContext;
                var index = cv.index;
                foreach (var item in vmthanhtoan.cart_Temps)
                {
                    if (index == item.index)
                    {
                        item.item_sl--;
                    }
                    else { }
                }
            }
            catch (Exception)
            {
                //log error
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
        async void lblincreasedrinkcartitem_tapped(object sender, EventArgs e)
        {
            var ctr = sender as Label;
            await ctr.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                var cv = (VBM._app_objs._general.cart_nuoc)ctr.BindingContext;
                var index = cv.name_vn;
                foreach (var items in vmthanhtoan.cart_Temps)
                {
                    foreach(var item in items.cart_Nuocs)
                    {
                        if (index == item.name_vn && items.order_name_vn == "Dòng combo")
                        {
                            App.Current.MainPage.DisplayAlert("Lỗi", "Đối với giỏ hàng thuôc dòng combo, số lượng nước phải bằng số lượng bánh!", "OK");
                        }
                        else
                        {
                            item.sl++;
                        }
                    }                       
                }
            }
            catch (Exception)
            {
                //log error
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
        async void lbldecreasedrinkcartitem_tapped(object sender, EventArgs e)
        {
            var ctr = sender as Label;
            await ctr.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                var cv = (VBM._app_objs._general.cart_nuoc)ctr.BindingContext;
                var index = cv.name_vn;
                foreach (var items in vmthanhtoan.cart_Temps)
                {
                    foreach (var item in items.cart_Nuocs)
                    {
                        if (index == item.name_vn && items.order_name_vn == "Dòng combo")
                        {
                            App.Current.MainPage.DisplayAlert("Lỗi", "Đối với giỏ hàng thuôc dòng combo, số lượng nước phải bằng số lượng bánh!", "OK");
                        }
                        else
                        {
                            item.sl--;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //log error
                await ctr.ScaleTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }


    }
}