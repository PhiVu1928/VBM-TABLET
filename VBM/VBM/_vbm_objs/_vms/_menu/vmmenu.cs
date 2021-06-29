using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VBM._vbm_objs._vms._menu
{
    public class vmmenu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<titleGroup> titleGroups { get; set; }
        public vmmenu()
        {
            titleRender();
            createRows();
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems);
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

        public Command LoadMoreItemsCommand { get; set; }
        public async void LoadMoreItems(object obj)
        {
            isbusy = true;
            await Task.Delay(2500);
            var index = rowsRender.Count;
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
        }

        public int index { get; set; }
        public ObservableCollection<emenu> emes { get; set; }

        void createEmes()
        {
            emes = new ObservableCollection<emenu>();
            for (int i = 0; i < 3; i++)
            {
                emes.Add(new emenu());
            }
        }

        public rowEmesRender clone()
        {
            ObservableCollection<emenu> cops = new ObservableCollection<emenu>();
            foreach (var item in emes)
            {
                cops.Add(item.clone());
            }
            return new rowEmesRender { emes = cops, index = this.index };
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
