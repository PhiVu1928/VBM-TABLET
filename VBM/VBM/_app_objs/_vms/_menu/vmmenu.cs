using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._general;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace VBM._app_objs._vms._menu
{
    public class vmmenu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public vmmenu()
        {
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems);
            Task.Run(() => { createmenu(); });
        }
        #region bien
        public ObservableCollection<vbm.objs.main_menu_class_obj> Main_Menu_Class_Objs { get; set; }

        public Command LoadMoreItemsCommand { get; set; }


        TabItemCollection sfTabItems_;

        public TabItemCollection sfTabItems
        {
            get
            {
                return sfTabItems_;
            }
            set
            {
                sfTabItems_ = value;
                OnPropertyChanged("sfTabItems");
            }
        }

        ObservableRangeCollection<vbm.objs.e_menu_obj> e_Menu_Objs_;
        public ObservableRangeCollection<vbm.objs.e_menu_obj> E_Menu_Objs
        {
            get
            {
                return e_Menu_Objs_;
            }
            set
            {
                e_Menu_Objs_ = value;
                OnPropertyChanged("E_Menu_Objs");
            }
        }

        public ObservableRangeCollection<vbm.objs.e_menu_obj> emenu_temp { get; set; }
        bool isbusy_;
        public bool isbusy
        {
            get
            {
                return isbusy_;
            }
            set
            {
                isbusy_ = value;
                OnPropertyChanged("isbusy");
            }
        }
        ObservableCollection<emenu> emenus_;
        public ObservableCollection<emenu> emenus
        {
            get
            {
                return emenus_;
            }
            set
            {
                emenus_ = value;
                OnPropertyChanged("emenus");
            }
        }
        #endregion

        #region process
        async void createmenu()
        {

            Main_Menu_Class_Objs = new ObservableCollection<vbm.objs.main_menu_class_obj>();
            var mg = localdb._manager;
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in mg._cached.menu)
                {
                    Main_Menu_Class_Objs.Add(item);
                }
            });
            await Task.Run(() => { createtabiem(); }); 
        }
        async Task createtabiem()
        {
            sfTabItems = new TabItemCollection();
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in Main_Menu_Class_Objs)
                {
                    foreach (var sub in item.lst_sub_menu)
                    {
                        if (item.lst_sub_menu.Count == 1)
                        {
                            SfTabItem tabItem = new SfTabItem();
                            tabItem.Title = item.name_vn;
                            sfTabItems.Add(tabItem);
                        }
                        else
                        {
                            SfTabItem tabItem = new SfTabItem();
                            tabItem.Title = sub.name_vn;
                            sfTabItems.Add(tabItem);
                        }
                    }
                }
            });
        }

        async Task render_emenu(int item, int itemsize)
        {
            E_Menu_Objs = new ObservableRangeCollection<vbm.objs.e_menu_obj>();
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (var items in emenu_temp.Skip(item).Take(itemsize))
                {
                    E_Menu_Objs.Add(items);
                }
            });            
        }
        public async Task create_emenu(List<vbm.objs.e_menu_obj> e_Menu_Objs)
        {
            emenu_temp = new ObservableRangeCollection<vbm.objs.e_menu_obj>();
            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in e_Menu_Objs.Where(x => x.img != ""))
                {
                    emenu_temp.Add(item);
                }
            });
            await Task.Run(() => { render_emenu(0, 9); });
        }
        public async void LoadMoreItems(object obj)
        {
            isbusy = true;
            await Task.Delay(2500);
            var index = E_Menu_Objs.Count();
            if (index < emenu_temp.Count())
            {
                foreach (var items in emenu_temp.Skip(index).Take(6))
                {
                    E_Menu_Objs.Add(items);
                }
            }
            else
            {
                //log errors
            }
            isbusy = false;
        }
        #endregion


    }


}
