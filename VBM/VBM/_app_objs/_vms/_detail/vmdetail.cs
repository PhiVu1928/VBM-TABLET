using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace VBM._app_objs._vms._detail
{
    public class vmdetail : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public vmdetail()
        {
            createRows();
            createSizeRows();
            createExtrasrow();
            createTopping();
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
        public ObservableCollection<rowSizeRender> rowSizeRenders { get; set; }
        public ObservableCollection<rowExtrasRender> rowExtrasRenders { get; set; }
        public ObservableCollection<Topping> toppings { get; set; }
        void createTopping()
        {
            toppings = new ObservableCollection<Topping>();
            for(int i = 0; i < 6; i++ )
            {
                toppings.Add(new Topping());
            }
        }
        void createExtrasrow()
        {
            rowExtrasRenders = new ObservableCollection<rowExtrasRender>();
            for(int i = 0; i < 4; i++ )
            {
                rowExtrasRenders.Add(new rowExtrasRender());
            }
        }
        void createRows()
        {
            rowsRender = new ObservableCollection<rowEmesRender>();
            for (int i = 0; i < 2; i++)
            {
                rowsRender.Add(new rowEmesRender(i));
            }
        }
        void createSizeRows()
        {
            rowSizeRenders = new ObservableCollection<rowSizeRender>();
            rowSizeRenders.Add(new rowSizeRender());
        }

    }


    public class rowEmesRender
    {

        public rowEmesRender() { }

        public rowEmesRender(int index)
        {
            this.index = index;
            if(index == 0)
            {
                createEmes();
            }
            if(index == 1)
            {
                createEmess();
            }
        }

        public int index { get; set; }
        public ObservableCollection<drink> emes { get; set; }

        void createEmes()
        {
            emes = new ObservableCollection<drink>();
            for (int i = 0; i < 3; i++)
            {
                emes.Add(new drink(i));
            }
        }       
        void createEmess()
        {
            emes = new ObservableCollection<drink>();
            for (int i = 3; i < 5; i++)
            {
                emes.Add(new drink(i));
            }
        }       

    }

    public class rowSizeRender
    {
        public rowSizeRender()
        {
            createSizes();
        }
        public ObservableCollection<Sizes> Sizes { get; set; }
        public void createSizes()
        {
            Sizes = new ObservableCollection<Sizes>();
            for (int i = 0; i < 3; i++)
            {
                Sizes.Add(new Sizes(i));
            }
        }
    }
    
    public class rowExtrasRender
    {
        public rowExtrasRender()
        {
            createExtras();
        }
        public ObservableCollection<extras> extras { get; set; }
        void createExtras()
        {
            extras = new ObservableCollection<extras>();
            for(int i = 0; i < 4; i++)
            {
                extras.Add(new extras(i));
            }
        }
    }
    public class extras : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public extras(int id)
        {
            this.index = id;
            if(id == 0)
            {
                Name = "Không đồ chua";
                Selected = true;
            }
            if(id == 1)
            {
                Name = "Ít đồ chua";
            }    
            if(id == 2)
            {
                Name = "Đồ chua bình thường";
            }
            if(id == 3)
            {
                Name = "Nhiều đồ chua";
            }    
        }
        Color _Textcolor;
        Color _Bordercolor;
        bool _Selected;

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;
                if (value)
                {
                    TextColor = (Color)Application.Current.Resources["vbmwhite"];
                    BorderColor = (Color)Application.Current.Resources["vbmgray"];
                }
                else
                {
                    TextColor = (Color)Application.Current.Resources["vbmdeepgray"];
                    BorderColor = (Color)Application.Current.Resources["vbmwhite"];
                }
            }
        }
        public Color BorderColor
        {
            get
            {
                return _Bordercolor;
            }
            set
            {
                _Bordercolor = value;
                OnPropertyChanged("BorderColor");
            }
        }
        public Color TextColor
        {
            get
            {
                return _Textcolor;
            }
            set
            {
                _Textcolor = value;
                OnPropertyChanged("TextColor");
            }
        }
        public string Name { get; set; }
        public int index { get; set; }
    }
    public class drink : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public drink(int id)
        {
            this.index = id;
            if(id == 0)
            {
                Name = "Cà Phê Đen";
                Selected = true;
            }
            if (id == 1)
            {
                Name = "Cà Phê Sữa";
            }
            if (id == 2)
            {
                Name = "Sâm TM";
            }
            if (id == 3)
            {
                Name = "Trà Chanh Sả";
            }
            if(id == 4)
            {
                Name = "Trà Gừng Sả";
            }    
                
        }
        Color _Textcolor;
        Color _Bordercolor;
        bool _Selected;        
        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;
                if (value)
                {
                    TextColor = (Color)Application.Current.Resources["vbmlightyellow"];
                    BorderColor = (Color)Application.Current.Resources["vbmgreen"];
                }
                else
                {
                    TextColor = (Color)Application.Current.Resources["vbmgray"];
                    BorderColor = (Color)Application.Current.Resources["vbmlightgray"];
                }
            }
        }
        public Color BorderColor
        {
            get
            {
                return _Bordercolor;
            }
            set
            {
                _Bordercolor = value;
                OnPropertyChanged("BorderColor");
            }
        }
        public Color TextColor
        {
            get
            {
                return _Textcolor;
            }
            set
            {
                _Textcolor = value;
                OnPropertyChanged("TextColor");
            }
        }
        public string Name { get; set; }
        public int index { get; set; }
    }
    public class Sizes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Sizes(int id)
        {
            this.index = id;
            if (id == 0)
            {
                Name = "S";
                Selected = true;
            }
            if (id == 1)
            {
                Name = "M";
            }
            if (id == 2)
            {
                Name = "L";
            }
        }
        Color _Textcolor;
        Color _Bordercolor;
        bool _Selected;

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                _Selected = value;
                if (value)
                {
                    TextColor = (Color)Application.Current.Resources["vbmpinttext"];
                    BorderColor = (Color)Application.Current.Resources["vbmlightgray"];
                }
                else
                {
                    TextColor = (Color)Application.Current.Resources["vbmgray"];
                    BorderColor = (Color)Application.Current.Resources["vbmwhite"];
                }
            }
        }
        public Color BorderColor
        {
            get
            {
                return _Bordercolor;
            }
            set
            {
                _Bordercolor = value;
                OnPropertyChanged("BorderColor");
            }
        }
        public Color TextColor
        {
            get
            {
                return _Textcolor;
            }
            set
            {
                _Textcolor = value;
                OnPropertyChanged("TextColor");
            }
        }

        public int index { get; set; }
        public string Name { get; set; }
    }
    public class Topping
    {
        public Topping()
        {
            Name = "Thêm chả";
        }
        public string Name { get; set; }
    }

}
