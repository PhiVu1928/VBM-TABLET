using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;

namespace VBM._app_objs._vms._promo
{
    public class vmpromomenu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public vmpromomenu(vbm.objs.promo_obj promo_Obj)
        {
            Selected_promo = promo_Obj;
            getpromomenu();
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems);
            render_menu(0,9);
        }
        public async void getpromomenu()
        {
            var mg = localdb._manager;
            var val = mg._varialbles;
            var com = mg._communicate;
            promosteps = new List<vbm.objs.promostep>();
            promo_size = new List<vbm.objs.promo_eme_size>();
            try
            {
                var system_task = new List<Task>();
                system_task.Add(Task.Run(() => { val._promosteps = com.get_promo_detail(val._store_selected.ShopID, Selected_promo.id); }));
                Task.WaitAll(system_task.ToArray());

            }
            catch(Exception ex)
            {
                //error log
                App.Current.MainPage.DisplayAlert("loi", ex.ToString(), "ok");
            }
        }
        public async void LoadMoreItems(object obj)
        {
            isbusy = true;
            var mg = localdb._manager._varialbles;
            await Task.Delay(2500);
            var index = promo_menus.Count();
            foreach(var item in mg._promosteps)
            {
                if(index < item.lst_emes.Count())
                {
                    promo_menus.Add(item.lst_emes.Skip(index).Take(6));
                }
                else
                {
                    break;
                }
            }
            isbusy = false;
        }
        void render_menu(int items,int itemsize)
        {
            var mg = localdb._manager;
            var val = mg._varialbles;
            promo_menus = new ObservableRangeCollection<vbm.objs.promo_emenus>();
            foreach (var item in val._promosteps)
            {
                promo_menus.Add(item.lst_emes.Skip(items).Take(itemsize));
            }
        }
        #region bien
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
        public Command LoadMoreItemsCommand { get; set; }
        vbm.objs.promo_obj Selected_promo_;

        public vbm.objs.promo_obj Selected_promo
        {
            get
            {
                return Selected_promo_;
            }
            set
            {
                Selected_promo_ = value;
                OnPropertyChanged("Selected_promo");
            }
        }
        public List<vbm.objs.promostep> promosteps { get; set; }
        ObservableRangeCollection<vbm.objs.promo_emenus> promo_menus_;
        public ObservableRangeCollection<vbm.objs.promo_emenus> promo_menus
        {
            get
            {
                return promo_menus_;
            }
            set
            {
                promo_menus_ = value;
                OnPropertyChanged("promo_menus");
            }
        }
        public List<vbm.objs.promo_eme_size> promo_size { get; set; }
        #endregion
    }
}
