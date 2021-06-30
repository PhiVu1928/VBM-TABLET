using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using Xamarin.Forms;

namespace VBM._vbm_objs._vms._home
{
    public class vmhome
    {
        public ObservableCollection<title> titles { get; set; }
        public ObservableCollection<MenuTab> menuTabs { get; set; }
        
        public vmhome()
        {
            titlerender();
            CreateMenuTab();
        }
        
        public void titlerender()
        {
            titles = new ObservableCollection<title>();
            for(int i = 0; i <= 2; i++)
            {
                titles.Add(new title(i));
            }
        }
        void CreateMenuTab()
        {
            menuTabs = new ObservableCollection<MenuTab>();
            for(int i = 0; i <= 3; i++ )
            {
                menuTabs.Add(new MenuTab(i));
            }
        }
    }
    public class title : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public bool _selected;
        public title(int id)
        {
            this.Id = id;
            if(id == 1)
            {
                NameTitle = "history";
                Icon = "historyicon";
            }
            if(id == 2)
            {
                NameTitle = "gift";
                Icon = "gifticon";
            }
        }
        public int Id { get; set; }
        public string NameTitle { get; set; }
        public string Icon { get; set; }
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
                    Icon = Icon + "press";
                }
                else
                {
                    Icon = Icon;
                }
            }
        }
    }
    public class MenuTab : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MenuTab(int id)
        {
            this.Index = id;
            if(id == 0)
            {
                Name = "KHÁCH HÀNG";
                Selected = true;
            }
            if(id == 1 )
            {
                Name = "SCRIPT";
            }
            if(id == 2)
            {
                Name = "QUÀ TẶNG";
            }
            if(id == 3)
            {
                Name = "ĐƠN HÀNG";
            }
        }
        Color _TextColor;
        
        bool _Selected;
        public Color TextColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                _TextColor = value;
                OnPropertyChanged("TextColor");
            }
        }
        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;
                if(value)
                {
                    TextColor = (Color)Application.Current.Resources["vbmgreen"];
                }
                else
                {
                    TextColor = (Color)Application.Current.Resources["vbmdeeplightgray"];
                }
                OnPropertyChanged("Selected");
            }
        }
        public int Index { get; set; }
        public string Name { get; set; }
    }
}
