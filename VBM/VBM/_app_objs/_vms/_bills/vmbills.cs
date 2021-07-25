using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace VBM._app_objs._vms._bills
{
    public class vmbills
    {
        public ObservableCollection<bills> bills { get; set; }
        public vmbills()
        {
            CreateBills();
        }
        void CreateBills()
        {
            bills = new ObservableCollection<bills>();
            for(int i = 0; i < 10; i++)
            {
                bills.Add(new bills(i));
            }
        }
    }
    public class bills : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); 
        }
        public bills(int id)
        {
            this.index = id;
            if(id < 5)
            {
                Selected = true;
            }
            else
            {
                Selected = false;
            }
        }
        Color _textColor;
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
                OnPropertyChanged("TextColor");
            }
        }
        bool _selected;
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
                    Status = "Đơn đã xong";
                    TextColor = (Color)App.Current.Resources["vbmdeepgreen"];
                }
                else
                {
                    Status = "Đơn đang xử lý";
                    TextColor = (Color)App.Current.Resources["vbmpinttext"];
                }
            }
        }
        public int index { get; set; }
        public string Status { get; set; }
    }
}
