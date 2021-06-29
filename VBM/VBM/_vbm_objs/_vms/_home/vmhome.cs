using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;

namespace VBM._vbm_objs._vms._home
{
    public class vmhome
    {
        public ObservableCollection<title> titles { get; set; }
        
        public vmhome()
        {
            titlerender();
        }
        
        public void titlerender()
        {
            titles = new ObservableCollection<title>();
            for(int i = 0; i <= 2; i++)
            {
                titles.Add(new title(i));
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
}
