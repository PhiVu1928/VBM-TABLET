using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBM._app_objs._general;
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
        public ObservableCollection<vbm.objs.main_menu_class_obj> Main_Menu_Class_Objs { get; set; }
        public List<vbm.objs.sub_menu_class_obj> Sub_Menu_Class_Objs { get; set; }
        public vmmenu()
        {
            E_Menu_Objs = new List<vbm.objs.e_menu_obj>();
            createmenu();
            createEmes();
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems);
        }
        List<vbm.objs.e_menu_obj> e_Menu_Objs_;
        public List<vbm.objs.e_menu_obj> E_Menu_Objs
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

        void createmenu()
        {

            Main_Menu_Class_Objs = new ObservableCollection<vbm.objs.main_menu_class_obj>();
            var mg = localdb._manager;
            foreach(var item in mg._cached.menu)
            {
                Main_Menu_Class_Objs.Add(item);
            }    
        }
        
        

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
        void createEmes()
        {
            emenus = new ObservableCollection<emenu>();
            for(int i = 0; i < 9; i++)
            {
                emenus.Add(new emenu());
            }
        }

        public Command LoadMoreItemsCommand { get; set; }
        public async void LoadMoreItems(object obj)
        {
            isbusy = true;
            await Task.Delay(2500);
            var index = 3;
            if (index + 3 < E_Menu_Objs.Count)
            {
                for (int i = 0; i < 3; i++)
                {
                    //rowsRender.Add(new rowEmesRender(i));
                }
            }
            else
            {
                for (int i = 0; i < E_Menu_Objs.Count() - index; i++)
                {
                    //rowsRender.Add(new rowEmesRender(i));
                }
            }
            isbusy = false;
        }

    }


}
