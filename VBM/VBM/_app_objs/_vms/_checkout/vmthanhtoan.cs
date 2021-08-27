using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace VBM._app_objs._vms._checkout
{
    public class vmthanhtoan : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public vmthanhtoan()
        {
            createPttt();
            Rendergiohang();
        }
        void createpayments()
        {
            payments = new ObservableCollection<Payment>();
            for (int i = 0; i <= 5; i++)
            {
                payments.Add(new Payment(i));
            }
        }
        void createDiscount()
        {
            discounts = new ObservableCollection<Discount>();
            for (int i = 0; i <= 4; i++)
            {
                discounts.Add(new Discount(i));
            }
        }
        void createPttt()
        {
            pTTTs = new ObservableCollection<PTTT>();
            for (int i = 0; i <= 2; i++)
            {
                pTTTs.Add(new PTTT(i));
            }
        }
        public void rendertotal()
        {
            cartTotal = 0;
            foreach(var items in cart_Temps)
            {
                cartTotal += items.total;
            }
        }
        public void Rendergiohang()
        {
            var carts = localdb._manager._varialbles._cart_temp;
            cart_Temps = new ObservableRangeCollection<cart_temp>();
            foreach (var item in carts)
            {
                cart_Temps.Add(new cart_temp(item));
                cartTotal += item.total;
            }
       }
        public void carttotal()
        {
            foreach (var items in cart_Temps)
            {
                cartTotal += items.total;
            }
        }
        public async Task deleteitemcart(cart_temp cart_Temp)
        {
            var carts = localdb._manager._varialbles._cart_temp;
            cart_Temps.Remove(cart_Temp);
            foreach(var item in carts.Where(x => x.index == cart_Temp.index))
            {
                carts.Remove(item);
            }
        }
        public void IncreaseItem(int cart_Temp)
        {
            foreach(var item in cart_Temps)
            {
                if(cart_Temp == item.index)
                {
                    item.item_sl++;
                    item.size_price = item.size_price * item.item_sl;
                }
            }
            Rendergiohang();
        }
        #region bien
        public ObservableCollection<Payment> payments { get; set; }
        public ObservableCollection<Discount> discounts { get; set; }
        public ObservableCollection<PTTT> pTTTs { get; set; }
        ObservableRangeCollection<cart_temp> cart_Temps_;
        public ObservableRangeCollection<cart_temp> cart_Temps
        {
            get
            {
                return cart_Temps_;
            }
            set
            {
                cart_Temps_ = value;
                OnPropertyChanged("cart_Temps");
            }
        }
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
    #region modeltemp
    public class cart_temp : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public cart_temp(VBM._app_objs._general.cart_temp cart)
        {
            index = cart.index;
            name_vn = cart.name_vn;
            name_en = cart.name_en;
            item_sl = cart.item_sl;
            size_name_vn = cart.size_name_vn;
            size_name_en = cart.size_name_en;
            size_price = cart.size_price;
            nguyengia = cart.nguyengia;
            name_drink_en = cart.name_drink_en;
            name_drink_vn = cart.name_drink_vn;
            extras_price_total = cart.extras_price_total;
            total = cart.total;
            order_type = cart.order_type;
            order_node = cart.order_node;
            order_name_vn = cart.order_name_vn;
            order_name_en = cart.order_name_en;
            spice_Sizes = new List<cart_spices>();
            Extras = new List<cart_extra>();
            cart_Nuocs = new List<cart_nuoc>();
            foreach (var item in cart.Extras)
            {
                Extras.Add(new cart_extra(item));
            }
            foreach (var item in cart.spice_Sizes)
            {
                spice_Sizes.Add(new cart_spices(item));
            }
            foreach (var item in cart.cart_Nuocs)
            {
                cart_Nuocs.Add(new cart_nuoc(item));
            }
        }
        public int index { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        int item_sl_;
        public int item_sl
        {
            get
            {
                return item_sl_;
            }
            set
            {
                item_sl_ = value;
                OnPropertyChanged("item_sl");
            }
        }
        public string size_name_vn { get; set; }
        public string size_name_en { get; set; }
        public double nguyengia { get; set; }

        double size_price_;
        public double size_price
        {
            get
            {
                return size_price_;
            }
            set
            {
                size_price_ = value;
                OnPropertyChanged("size_price");
            }
        }
        public double extras_price_total { get; set; }
        public string name_drink_vn { get; set; }
        public string name_drink_en { get; set; }
        public double nuoc_price { get; set; }
        public int nuoc_sl { get; set; }
        double total_;
        public double total
        {
            get
            {
                return total_;
            }
            set
            {
                total_ = value;
                OnPropertyChanged("total");
            }
        }
        public string order_node { get; set; }
        public int order_type { get; set; }
        public string order_name_vn { get; set; }
        public string order_name_en { get; set; }

        public List<cart_nuoc> cart_Nuocs { get; set; }
        public List<cart_spices> spice_Sizes { get; set; }
        public List<cart_extra> Extras { get; set; }
    }
    public class cart_nuoc
    {
        public cart_nuoc(VBM._app_objs._general.cart_nuoc drink)
        {
            name_vn = drink.name_vn;
            name_en = drink.name_en;
            price = drink.price;
            sl = 1;
        }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public double price { get; set; }
        public int sl { get; set; }
    }
    public class cart_extra
    {
        public cart_extra(VBM._app_objs._general.cart_extra extras)
        {
            id = extras.id;
            name_vn = extras.name_vn;
            name_en = extras.name_en;
            alias = extras.alias;
            price = extras.price;
            sl = extras.sl;
        }
        public long id { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public string alias { get; set; }
        public double price { get; set; }
        public int sl { get; set; }
    }
    public class cart_spices
    {
        public cart_spices(VBM._app_objs._general.cart_spices spice_Size)
        {
            ref_id = spice_Size.ref_id;
            id = spice_Size.id;
            size = spice_Size.size;
            name_vn = spice_Size.name_vn;
            name_eng = spice_Size.name_eng;
            alias = spice_Size.alias;
            price = spice_Size.price;
        }
        public long ref_id { get; set; }
        public long id { get; set; }
        public int size { get; set; }
        public string name_vn { get; set; }
        public string name_eng { get; set; }
        public string alias { get; set; }
        public double price { get; set; }
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
    #endregion
}
