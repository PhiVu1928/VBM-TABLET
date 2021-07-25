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
        public ObservableCollection<titleGroup> titleGroups { get; set; }
        public vmmenu()
        {
            createmenu();
            titleRender();
            createEmes();
            createRows();
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems);
            LoadMoreEmenusCommand = new Command<object>(LoadMoreEmenus);
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
            Sub_Menu_Class_Objs = new List<vbm.objs.sub_menu_class_obj>();
            E_Menu_Objs = new List<vbm.objs.e_menu_obj>();

            var items = localdb._manager._varialbles._menus;
            foreach(var item in items)
            {
                Main_Menu_Class_Objs.Add(item);
                foreach(var itemss in item.lst_sub_menu)
                {
                    Sub_Menu_Class_Objs.Add(itemss);
                    foreach(var emenu in itemss.lst_emes)
                    {
                        E_Menu_Objs.Add(emenu);
                    }
                }                
            }    
        }
        
        ObservableCollection<rowEmesRender> rowsRender_;
        public ObservableCollection<rowEmesRender> rowsRender
        {
            get
            {
                return rowsRender_;
            }
            set
            {
                rowsRender_ = value;
                OnPropertyChanged("rowsRender");
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
        public Command LoadMoreEmenusCommand { get; set; }
        public async void LoadMoreEmenus(object obj)
        {
            isbusy = true;
            await Task.Delay(2500);
            var index = emenus.Count;
            if (index + 3 < 56)
            {
                for (int i = 0; i < 3; i++)
                {
                    emenus.Add(new emenu());
                }
            }
            else
            {
                for (int i = 0; i < 56 - index; i++)
                {
                    emenus.Add(new emenu());
                }
            }
            isbusy = false;
        }

        public Command LoadMoreItemsCommand { get; set; }
        public async void LoadMoreItems(object obj)
        {
            isbusy = true;
            await Task.Delay(2500);
            var index = emenus.Count;
            if (index + 3 < 24)
            {
                for (int i = 0; i < 3; i++)
                {
                    rowsRender.Add(new rowEmesRender(i));
                }
            }
            else
            {
                for (int i = 0; i < 24 - index; i++)
                {
                    rowsRender.Add(new rowEmesRender(i));
                }
            }
            isbusy = false;
        }

        void createRows()
        {
            rowsRender = new ObservableCollection<rowEmesRender>();
            for (int i = 0; i < 3; i++)
            {
                rowsRender.Add(new rowEmesRender(i));
            }
        }
        public void titleRender()
        {
            titleGroups = new ObservableCollection<titleGroup>();
            for(int i = 1; i <= 4; i++)
            {
                titleGroups.Add(new titleGroup(i));
            }
        }
    }
    public class titleGroup : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public titleGroup(int id)
        {
            this.index = id;
            if(index == 1)
            {
                name = "Bánh mì";
                Selected = true;
            }
            if(index == 2)
            {
                name = "Burger";
            }    
            if(index == 3)
            {
                name = "Mì ý";
            }    
            if(index == 4)
            {
                name = "Thuần thực vật";
            }    
        }
        bool _selected;
        Color _textcolor;
        Color _boxcolor;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                if(value)
                {
                    TextColor = (Color)Application.Current.Resources["vbmgreen"];
                    BoxColor = (Color)Application.Current.Resources["vbmlightyellow"];
                }
                else
                {
                    TextColor = (Color)Application.Current.Resources["vbmgray"];
                    BoxColor = (Color)Application.Current.Resources["vbmwhite"];
                }
            }
        }
        public Color BoxColor
        {
            get
            {
                return _boxcolor;
            }
            set
            {
                _boxcolor = value;
                OnPropertyChanged("BoxColor");
            }
        }
        public Color TextColor
        {
            get
            {
                return _textcolor;
            }
            set
            {
                _textcolor = value;
                OnPropertyChanged("TextColor");
            }
        }
        public string name { get; set; }
        public int index { get; set; }
    }

    public class rowEmesRender
    {

        public rowEmesRender() { }

        public rowEmesRender(int index)
        {
            this.index = index;
            createEmes();
            createEmesPhone();
        }

        public int index { get; set; }
        public ObservableCollection<emenu> emes { get; set; }
        public ObservableCollection<emenu> emes2 { get; set; }

        void createEmes()
        {
            emes = new ObservableCollection<emenu>();
            for (int i = 0; i < 3; i++)
            {
                emes.Add(new emenu());
            }
        }

        void createEmesPhone()
        {
            emes2 = new ObservableCollection<emenu>();
            for(int i = 0; i < 2; i++)
            {
                emes2.Add(new emenu());
            }
        }
    }

    public class emenu
    {
        public emenu()
        {

            Name = "Bánh mì thịt chả";
            Image = $"http://manage.vuabanhmi.com/SpImg/14102020195918.jpg";
            Price = "25,000đ";
           
        }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public emenu clone()
        {
            return new emenu
            {
                Name = this.Name,
                Image = this.Image,
                Price = this.Price,
            };
        }
    }
}
