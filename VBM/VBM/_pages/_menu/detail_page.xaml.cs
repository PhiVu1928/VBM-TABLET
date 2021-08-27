using Rg.Plugins.Popup.Extensions;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Border;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vbm.objs;
using VBM._app_objs._vms._detail;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detail_page : ContentPage
    {
        public vmdetail vm;
        public detail_page()
        {
            InitializeComponent();
        }

        public async Task Render(vbm.objs.e_menu_obj e_Menu_Obj)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                vm = new vmdetail();
                vm.GetSelectedItem(e_Menu_Obj);
                this.BindingContext = vm;
                SelectItem.Text = vm.SelectedItem.name_vn;
            });
            lstextras.IsVisible = false;
            lstgiavi.IsVisible = false;
            boxgiavi.IsVisible = false;
            boxnhanbanh.IsVisible = false;
        }
        public async Task RenderPromo(vbm.objs.promo_emenus promo_Emenus)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                vm = new vmdetail();
                vm.GetSelectedPromoItem(promo_Emenus);
                this.BindingContext = vm;
                SelectItem.Text = vm.SelectedPromoItem.name_vn;
            });
            lstnuoc.IsVisible = false;
            lstextras.IsVisible = false;
            lstgiavi.IsVisible = false;
            boxgiavi.IsVisible = false;
            boxnhanbanh.IsVisible = false;
        }
        public void ff_backicon_tapped(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        async void ff_spice_tapped(object sender, EventArgs e)
        {
            var border = sender as SfBorder;
            var select = (Spice_Size)border.BindingContext;
            var cv = select.id;
            foreach (var items in vm.Spice_Objs)
            {
                foreach (var itemss in items.spice_Sizes.Where(x => x.ref_id == select.ref_id))
                {
                    if (itemss.id == cv)
                    {
                        itemss.Selected = true;
                    }
                    else
                    {
                        itemss.Selected = false;
                    }
                }
            }
        }
        async void ff_drink_tapped(object sender, EventArgs e)
        {
            var border = sender as SfBorder;
            var select = (drink)border.BindingContext;
            vm.getnuoc(select);
            var cv = select.name_vn;
            foreach (var items in vm.rowsRender)
            {
                foreach (var itemss in items.drinks)
                {
                    if (itemss.name_vn == cv && itemss.Selected == false)
                    {
                        itemss.Selected = true;
                    }   
                    else
                    {
                        itemss.Selected = false;
                    }
                }
            }
        }
        async void stl_nhanbanh_tapped(object sender, EventArgs e)
        {
            if(lstextras.ItemsSource == null)
            {
                lstextras.ItemsSource = vm.extras;
            }
            if (lstextras.IsVisible == true)
            {
                lstextras.IsVisible = false;
                boxnhanbanh.IsVisible = false;
            }
            else
            {
                lstextras.IsVisible = true;
                boxnhanbanh.IsVisible = true;
            }
        }
        async void stl_giavi_tapped(object sender, EventArgs e)
        {           
            if(lstgiavi.ItemsSource == null)
            {
                lstgiavi.ItemsSource = vm.Spice_Objs;
            }
            if (lstgiavi.IsVisible == true)
            {
                lstgiavi.IsVisible = false;
                boxgiavi.IsVisible = false;
            }
            else
            {
                lstgiavi.IsVisible = true;
                boxgiavi.IsVisible = true;
            }
        }

        private void decreaseSl_tapped(object sender, EventArgs e)
        {
            var lb = sender as Label;
            var Selected = (extras)lb.BindingContext;
            var cv = Selected.id;
            foreach(var item in vm.extras.Where(x => x.id == cv))
            {
                if(item.sl <= 0)
                {
                    item.sl = 0;
                }
                else
                {
                    item.sl--;
                }
            }
            vm.TinhTong();
        } 
        private void increaseSl_tapped(object sender, EventArgs e)
        {
            var lb = sender as Label;
            var Selected = (extras)lb.BindingContext;
            var cv = Selected.id;
            int tong = 0;
            foreach (var items in vm.extras)
            {
                tong += items.sl;
            }
            foreach (var item in vm.extras.Where(x => x.id == cv))
            {
                
                if (tong < 3)
                {
                    item.sl++;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Lỗi", "Xin lỗi bạn. Số lượng nhân bánh tối đa cho mỗi bánh mì mà Vua Bánh Mì quy định nên là 3", "OK");
                }
            }
            vm.TinhTong();
        }

        async void bd_dathang_tapped(object sender, EventArgs e)
        {
            await bddathang.ScaleTo(0.9, 1);
            await this.FadeTo(0.9, 1);
            try
            {
                await vm.DatHang();
                await Application.Current.MainPage.DisplayAlert("Success", "Đặt hàng thành công", "OK");
                Navigation.RemovePage(this);
            }
            catch(Exception)
            {
                await bddathang.FadeTo(1, 100);
                await this.FadeTo(1, 100);
            }
        }
    }
}