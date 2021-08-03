using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VBM._app_objs._vms._checkout
{
    public class vmthanhtoan :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public vmthanhtoan()
        {
            createpayments();
            createDiscount();
            createPttt();
            Rendergiohang();
        }
        void createpayments()
        {
            payments = new ObservableCollection<Payment>();
            for(int i = 0; i <= 5; i++)
            {
                payments.Add(new Payment(i));
            }
        }
        void createDiscount()
        {
            discounts = new ObservableCollection<Discount>();
            for(int i = 0; i <= 4 ; i++)
            {
                discounts.Add(new Discount(i));
            }
        }
        void createPttt()
        {
            pTTTs = new ObservableCollection<PTTT>();
            for(int i = 0; i <= 2; i++)
            {
                pTTTs.Add(new PTTT(i));
            }
        }
        void Rendergiohang()
        {            
            var carts = localdb._manager._varialbles._cart_temp;
            cart_Temps = new List<_general.cart_temp>();
            foreach (var item in carts)
            {
                cart_Temps.Add(item);
                cartTotal += item.total;  
            }
        }
        #region bien
        public ObservableCollection<Payment> payments { get; set; }
        public ObservableCollection<Discount> discounts { get; set; }
        public ObservableCollection<PTTT> pTTTs { get; set; }
        public List<_general.cart_temp> cart_Temps { get; set; }
        double cartTotal_;
        public double cartTotal
        {
            get
            {
                return cartTotal_;
            }
            set
            {
                cartTotal_ = value;
                OnPropertyChanged("cartTotal");
            }
        }
       
        #endregion
    }
    public class Discount : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Discount(int id)
        {
            this.Index = id;
            Name = "Khuyến mãi cho sản phẩm salad mới";
        }
        Color _textcolor;
        Color _bordercolor;
        bool _selected;
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
        public Color BorderColor
        {
            get
            {
                return _bordercolor;
            }
            set
            {
                _bordercolor = value;
                OnPropertyChanged("BorderColor");
            }
        }
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
                    BorderColor = (Color)Application.Current.Resources["vbmlightyellow"];
                }
                else
                {
                    TextColor = (Color)Application.Current.Resources["vbmdeepgray"];
                    BorderColor = (Color)Application.Current.Resources["vbmlightmiddlegray"];
                }
            }
        }
        public int Index { get; set; }
        public string Name { get; set; }
    }
    public class Payment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Payment(int id)
        {
            this.Index = id;
            if(id == 0)
            {
                Name = "Tiền mặt";
                Image = "tienmaticon";
                SelectImage = "Stroke2";
                Selected = true;
            }
            if (id == 1)
            {
                Name = "ATM CARD";
                Image = "atmicon";
                SelectImage = "Stroke2";
            }
            if (id == 2)
            {
                Name = "VISA / MASTER";
                Image = "visaicon";
                SelectImage = "Stroke2";
            }
            if (id == 3)
            {
                Name = "MOMO";
                Image = "logomomo";
                SelectImage = "Stroke2";
            }
            if (id == 4)
            {
                Name = "ZALO PAY";
                Image = "zalopay";
                SelectImage = "Stroke2";
            }
            if (id == 5)
            {
                Name = "VINID";
                Image = "vinidlogo";
                SelectImage = "Stroke2";
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
                OnPropertyChanged("Selected");
            }
        }
        public string SelectImage { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class PTTT : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public PTTT(int id)
        {
            this.Index = id;
            if(id == 0)
            {
                Name = "ĐẶT TẠI CHỖ";
            }
            if (id == 1)
            {
                Name = "ĐẶT ĐẾN LẤY";
            }
            if (id == 2)
            {
                Name = "GIAO TẬN NƠI";
            }
        }
        Color _textcolor;
        Color _bordercolor;
        bool _selected;
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
        public Color BorderColor
        {
            get
            {
                return _bordercolor;
            }
            set
            {
                _bordercolor = value;
                OnPropertyChanged("BorderColor");
            }
        }
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                if (value)
                {
                    TextColor = (Color)Application.Current.Resources["vbmgreen"];
                    BorderColor = (Color)Application.Current.Resources["vbmlightyellow"];
                }
                else
                {
                    TextColor = (Color)Application.Current.Resources["vbmdeepgray"];
                    BorderColor = (Color)Application.Current.Resources["vbmlightmiddlegray"];
                }
            }
        }
        public int Index { get; set; }
        public string Name { get; set; }
    }

}
