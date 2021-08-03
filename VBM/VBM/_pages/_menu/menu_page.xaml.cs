using Syncfusion.XForms.TabView;
using System.Linq;
using System.Threading.Tasks;
using VBM._app_objs._vms._menu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VBM._pages._menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menu_page : ContentView
    {
        vmmenu vm { get; set; }
        public menu_page()
        {
            InitializeComponent();
        }
        public async Task Render()
        {
            vm = new vmmenu();
            this.BindingContext = vm;
            CreateMainEmes();
            await Task.Delay(2000);
            busyindicator.IsBusy = false;
            busyindicator.IsVisible = false;
        }

        //nesu thuc hien render o day thi se mat time de push new page
        //va su kien onappearing nen se invoke moi khi trang appear
        //nghia la khi push new cung invoke ma khi tro ve cung invoke (vì đều tính là appear)

        public async Task CreateMainEmes()    
        {            
            if(tabview.Items.Count() == 0)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var items in vm.Main_Menu_Class_Objs)
                    {
                        foreach (var sub in items.lst_sub_menu)
                        {
                            if (items.lst_sub_menu.Count == 1)
                            {
                                SfTabItem tabitem = new SfTabItem();
                                tabitem.Title = items.name_vn;
                                emenu_page lstemenu = new emenu_page();
                                lstemenu.Rendermenu(sub.lst_emes);
                                tabitem.Content = lstemenu;
                                tabview.Items.Add(tabitem);
                            }
                            else
                            {
                                SfTabItem tabitem = new SfTabItem();
                                tabitem.Title = sub.name_vn;
                                emenu_page lstemenu = new emenu_page();
                                lstemenu.Rendermenu(sub.lst_emes);
                                tabitem.Content = lstemenu;
                                tabview.Items.Add(tabitem);
                            }
                        }
                    }

                });
            }
            else
            {
                // 
            }    
        }



    }
}