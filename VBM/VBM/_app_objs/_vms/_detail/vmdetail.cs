using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            IncreaseQuantityCommand = new Command(() => ItemQuantity++);
            DecreaseQuantityCommand = new Command(() => ItemQuantity--);
        }

        #region process
        public async Task GetSelectedItem(vbm.objs.e_menu_obj e_Menu_Obj)
        {
            SelectedItem = e_Menu_Obj;
            createSize();
            await Task.Run(() => { createSpice(); });
            await Task.Run(() => { createExtra(); });
            await Task.Run(() => { createRows(); });         
            ItemQuantity = 1;

        }
        public async Task GetSelectedPromoItem(vbm.objs.promo_emenus promo_Emenus)
        {
            SelectedPromoItem = promo_Emenus;
            createSize();
            await Task.Run(() => { createSpice(); });
            await Task.Run(() => { createExtra(); });
            await Task.Run(() => { createRows(); });
            ItemQuantity = 1;
        }

        public void createSize()
        {
            Sizes = new List<Sizes>();
            if(SelectedItem != null)
            {
                foreach (var item in SelectedItem.lst_size.OrderBy(x => x.price))
                {
                    if (item.size_name_en == "Small")
                    {
                        Sizes.Add(new Sizes
                        {
                            id = item.id,
                            size_name_en = "S",
                            size_name_vn = "S",
                            size = item.size,
                            price = item.price,
                            Selected = true,
                        });
                    }
                    if (item.size_name_en == "Medium")
                    {
                        Sizes.Add(new Sizes
                        {
                            id = item.id,
                            size_name_en = "M",
                            size_name_vn = "M",
                            size = item.size,
                            price = item.price,
                        });
                    }
                    if (item.size_name_en == "Large")
                    {
                        Sizes.Add(new Sizes
                        {
                            id = item.id,
                            size_name_en = "L",
                            size_name_vn = "L",
                            size = item.size,
                            price = item.price,
                        });
                    }
                    if (item.size_name_vn == "")
                    {
                        Sizes.Add(new Sizes
                        {
                            id = item.id,
                            size_name_en = "",
                            size_name_vn = "",
                            size = item.size,
                            price = item.price,
                            Selected = true
                        });
                    }
                }

            }
            else
            {
                foreach (var item in SelectedPromoItem.lstsizes.OrderBy(x => x.dongia))
                {
                    if (item.name_en == "Small")
                    {
                        Sizes.Add(new Sizes
                        {
                            id = item.id,
                            size_name_en = "S",
                            size_name_vn = "S",
                            price = item.dongia,
                            size = item.size,
                        });
                    }
                    if (item.name_en == "Medium")
                    {
                        Sizes.Add(new Sizes
                        {
                            id = item.id,
                            size_name_en = "M",
                            size_name_vn = "M",
                            price = item.dongia,
                            size = item.size,
                            Selected = true
                        });
                    }
                    if (item.name_en == "Large")
                    {
                        Sizes.Add(new Sizes
                        {
                            id = item.id,
                            size_name_en = "L",
                            size_name_vn = "L",
                            price = item.dongia,
                            size = item.size,
                        });
                    }
                }

            }
        }

        public async Task createExtra()
        {
            var mg = localdb._manager;
            extras = new List<extras>();
            Device.BeginInvokeOnMainThread(() => 
            {
                foreach (var items in mg._cached.exts_spis.extras)
                {
                    foreach (var mons in items.mons)
                    {
                        extras.Add(new extras(items));
                    }
                }
            });
        }
        public async Task createSpice()
        {
            var mg = localdb._manager;
            Spice_Objs = new List<Spice_Obj>();
            if (SelectedItem != null)
            {
                foreach (var items in mg._cached.exts_spis.spices)
                {
                    foreach (var mons in items.mons)
                    {
                        if (mons == SelectedItem.class_id)
                        {
                            Spice_Objs.Add(new Spice_Obj(items));
                        }
                    }

                }
            }
            else
            {
                foreach (var items in mg._cached.exts_spis.spices)
                {
                    foreach (var mons in items.mons)
                    {
                        if (mons == SelectedPromoItem.promo_id)
                        {
                            Spice_Objs.Add(new Spice_Obj(items));
                        }
                    }

                }

            }

        }

        public async Task createRows()
        {
            rowsRender = new ObservableCollection<rowEmesRender>();
            Device.BeginInvokeOnMainThread(() =>
            {
                for (int i = 0; i < 2; i++)
                {
                    rowsRender.Add(new rowEmesRender(i));
                }
            });
        }
        void countcart()
        {
            var mg = localdb._manager._varialbles._cart_temp;
            if(mg != null)
            {
                cartcount = mg.Count();
            }
            else
            {
                cartcount = 0;
            }
        }
        public void getnuoc(drink drink)
        {
            chonnuoc = drink;
        }
        public void TinhTong()
        {
            double tongextras = 0;
            foreach(var item in extras.Where(x => x.sl > 0))
            {
                if(item != null)
                {
                    tongextras += item.sl * item.price;
                }
                else
                {
                    tongextras = 0;
                }
            }
            
            foreach (var item in Sizes.Where(x => x.Selected == true))
            {
                SizeGia = item.price;
                size_name_vn = item.size_name_vn;
                size_name_en = item.size_name_en;
            }
            if (SizeGia == null && chonnuoc == null)
            {
                Total = 0;
            }
            if(SizeGia != null && chonnuoc == null)
            {
                Total = (SizeGia * ItemQuantity) + tongextras;
            }
            if(SizeGia != null && chonnuoc != null)
            {
                chonnuoc.price = 9000;
                Total = (SizeGia * ItemQuantity) + (chonnuoc.price) + tongextras;
            }
        }
        public async Task DatHang()
        {
            List<extras> ts = new List<extras>();
            List<Spice_Size> tp = new List<Spice_Size>();
            List<drink> nuoc = new List<drink>();
            
            double extras_price_total = 0;
            var mg = localdb._manager;
            var val = mg._varialbles;
            try
            {
                
                foreach (var item in extras.Where(x => x.sl > 0))
                {
                    ts.Add(item);
                    extras_price_total += item.price * item.sl;
                }
                foreach (var item in Spice_Objs)
                {
                    foreach (var items in item.spice_Sizes.Where(x => x.Selected == true))
                    {
                        if(items.size != 2)
                        {
                            tp.Add(items);
                        }
                        else
                        {
                            //
                        }
                    }
                }    
                foreach(var item in rowsRender)
                {
                    foreach(var items in item.drinks.Where(x => x.Selected == true))
                    {
                        nuoc.Add(items);
                    }
                }
                carts = new List<cart>();
                if(SelectedItem != null)
                {
                    if (nuoc.Count != 0)
                    {
                        carts.Add(new cart
                        {
                            index = SelectedItem.index,
                            name_vn = SelectedItem.name_vn,
                            name_en = SelectedItem.name_en,
                            item_sl = ItemQuantity,
                            nguyengia = SizeGia,
                            size_price = SizeGia,
                            extras_price_total = extras_price_total,
                            size_name_en = size_name_en,
                            size_name_vn = size_name_vn,
                            order_name_vn = "Dòng combo",
                            total = Total,
                            drinks = nuoc,
                            Extras = ts,
                            spice_Sizes = tp
                        });
                    }
                    else
                    {
                        carts.Add(new cart
                        {
                            index = SelectedItem.index,
                            name_vn = SelectedItem.name_vn,
                            name_en = SelectedItem.name_en,
                            item_sl = ItemQuantity,
                            nguyengia = SizeGia,
                            size_price = SizeGia,
                            extras_price_total = extras_price_total,
                            size_name_en = size_name_en,
                            size_name_vn = size_name_vn,
                            order_name_vn = "",
                            total = Total,
                            drinks = nuoc,
                            Extras = ts,
                            spice_Sizes = tp
                        });
                    }
                }
                else
                {
                    carts.Add(new cart
                    {
                        index = SelectedPromoItem.promo_id,
                        name_vn = SelectedPromoItem.name_vn,
                        name_en = SelectedPromoItem.name_en,
                        item_sl = ItemQuantity,
                        nguyengia = SizeGia,
                        size_price = SizeGia,
                        extras_price_total = extras_price_total,
                        size_name_en = size_name_en,
                        size_name_vn = size_name_vn,
                        order_name_vn = "Nâng size miễn phí",
                        total = Total,
                        drinks = nuoc,
                        Extras = ts,
                        spice_Sizes = tp
                    });
                }
                

                foreach (var item in carts)
                {
                   val._cart_temp.Add(new _general.cart_temp(item));
                }
                if (val._cart_temp != null)
                {
                    mg._cached.update_added_carttemp(val._cart_temp);
                }
                countcart();
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", ex.ToString(), "OK");
            }
            
        }
        #endregion



        #region bien
        public Command IncreaseQuantityCommand { get; set; }

        public Command DecreaseQuantityCommand { get; set; }
        //lay item promo duoc chon
        vbm.objs.promo_emenus SelectedPromoItem_;
        public vbm.objs.promo_emenus SelectedPromoItem
        {
            get
            {
                return SelectedPromoItem_;
            }
            set
            {
                SelectedPromoItem_ = value;
                OnPropertyChanged("SelectedPromoItem");
            }
        }
        public double SizeGia = 0;
        public string size_name_vn = "";
        public string size_name_en = "";
        //gio hang
        int cartcount_;
        public int cartcount
        {
            get
            {
                return cartcount_;
            }
            set
            {
                cartcount_ = value;
                OnPropertyChanged("cartcount");
            }
        }
        public List<cart> carts { get; set; }
        //so luong san pham
        int ItemQuantity_;
        public int ItemQuantity 
        {
            get
            {
                return ItemQuantity_;
            }
            set
            {
                ItemQuantity_ = value;
                TinhTong(); 
                OnPropertyChanged("ItemQuantity");
            }
        }
        // chon size sp
        Sizes SelectedSize_;
        public Sizes SelectedSize
        {
            get
            {
                return SelectedSize_;
            }
            set
            {
                SelectedSize_ = value;
                foreach (var item in Sizes)
                {
                    if (item.id == SelectedSize.id)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
                TinhTong();
                OnPropertyChanged("SelectedSize");
            }
        }
        // tong tien
        double Total_;
        public double Total
        {
            get
            {
                return Total_;
            }
            set
            {
                Total_ = value;
                OnPropertyChanged("Total");
            }
        }
        // san pham duoc chon
        vbm.objs.e_menu_obj SelectedItem_;
        public vbm.objs.e_menu_obj SelectedItem
        {
            get
            {
                return SelectedItem_;
            }
            set
            {
                SelectedItem_ = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        // chon gia vi
        public Spice_Size SelectedSpiceSize
        {
            get
            {
                return SelectedSpiceSize_;
            }
            set
            {
                SelectedSpiceSize_ = value;
                foreach (var item in Spice_Objs)
                {
                    foreach (var items in item.spice_Sizes.Where(x => x.ref_id == SelectedSpiceSize.ref_id))
                    {
                        if (items.id == SelectedSpiceSize.id)
                        {
                            items.Selected = true;
                        }
                        else
                        {
                            items.Selected = false;
                        }
                    }
                }
            }
        }
        Spice_Size SelectedSpiceSize_;
        // chon nhan banh
        public List<extras> extras_;
        public List<extras> extras
        {
            get
            {
                return extras_;
            }
            set
            {
                extras_ = value;
                OnPropertyChanged("extras");
            }
        }
        // chon nuoc
        drink chonnuoc_;
        public drink chonnuoc
        {
            get
            {
                return chonnuoc_;
            }
            set
            {
                chonnuoc_ = value;
                TinhTong();
                OnPropertyChanged("chonnuoc");
            }
        }
        // render sizes san pham

        public List<Sizes> Sizes { get; set; }
        //render nuoc
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
        
        ObservableCollection<rowEmesRender> rowsRender_;
        // render gia vi va nhan banh
        public List<Spice_Obj> Spice_Objs { get; set; }

        #endregion


    }
    #region ModelTemp

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
        public List<drink> drinks { get; set; }
        void createEmes()
        {
            var mg = localdb._manager;
            drinks = new List<drink>();
            foreach (var item in mg._cached.menu.Where(x => x.id == 3))
            {
                foreach (var items in item.lst_sub_menu)
                {
                    foreach (var drink in items.lst_emes.Take(3))
                    {
                        drinks.Add(new drink(drink));
                    }
                }
            }
        }

        void createEmess()
        {
            var mg = localdb._manager;
            drinks = new List<drink>();
            foreach (var item in mg._cached.menu.Where(x => x.id == 3))
            {
                foreach (var items in item.lst_sub_menu)
                {
                    foreach (var drink in items.lst_emes.Skip(3).Take(2))
                    {
                        drinks.Add(new drink(drink));
                    }
                }
            }
        }       

    }
    public class Spice_Obj
    {        
        public Spice_Obj(vbm.objs.spice_obj spice_Obj)
        {
            this.ref_id = spice_Obj.ref_id;
            this.id_default = spice_Obj.id_default;
            this.name_vn = spice_Obj.name_vn;
            this.name_en = spice_Obj.name_en;
            this.mons = spice_Obj.mons;
            createSpiceSize(spice_Obj.lst_items);
        }
        public long ref_id { get; set; }
        public long id_default { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public List<long> mons { get; set; }
        public List<Spice_Size> spice_Sizes { get; set; }
        void createSpiceSize(List<vbm.objs.spice_size_obj> spice_Size)
        {
            spice_Sizes = new List<Spice_Size>();
            foreach(var item in spice_Size)
            {
                spice_Sizes.Add(new Spice_Size(item));
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

        public extras(vbm.objs.extra_obj extra_Obj)
        {
            this.id = extra_Obj.id;
            this.name_vn = extra_Obj.name_vn;
            this.name_en = extra_Obj.name_en;
            this.alias = extra_Obj.alias;
            this.price = extra_Obj.price;
            this.mons = extra_Obj.mons;
        }
        public long id { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public string alias { get; set; }
        public double price { get; set; }
        public List<long> mons { get; set; }

        int sl_;
        public int sl
        {
            get
            {
                return sl_;
            }
            set
            {
                sl_ = value;
                OnPropertyChanged("sl");
            }
        }
      

    }
    public class drink : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public drink(vbm.objs.e_menu_obj e_Menu_Obj)
        {
            this.index = e_Menu_Obj.index;
            this.name_vn = e_Menu_Obj.name_vn;
            this.name_en = e_Menu_Obj.name_en;
            this.class_id = e_Menu_Obj.class_id;
            foreach(var item in e_Menu_Obj.lst_size)
            {
                this.price = item.price;
            }
        }
        public int index { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public int class_id { get; set; }
        public double price { get; set; }
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
    }
    public class Sizes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public long id { get; set; }
        public int size { get; set; }
        public string size_name_vn { get; set; }
        public string size_name_en { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public double price { get; set; }
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
    }
    public class Spice_Size : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Spice_Size(vbm.objs.spice_size_obj spice_Size_Obj)
        {
            if(spice_Size_Obj.size == 0)
            {
                this.ref_id = spice_Size_Obj.ref_id;
                this.id = spice_Size_Obj.id;
                this.size = spice_Size_Obj.size;
                this.name_vn = spice_Size_Obj.name_vn;
                this.name_eng = spice_Size_Obj.name_eng;
                this.alias = spice_Size_Obj.alias;
                this.price = spice_Size_Obj.price;
            }
            if (spice_Size_Obj.size == 1)
            {
                this.ref_id = spice_Size_Obj.ref_id;
                this.id = spice_Size_Obj.id;
                this.size = spice_Size_Obj.size;
                this.name_vn = spice_Size_Obj.name_vn;
                this.name_eng = spice_Size_Obj.name_eng;
                this.alias = spice_Size_Obj.alias;
                this.price = spice_Size_Obj.price;
            }
            if (spice_Size_Obj.size == 2)
            {
                this.ref_id = spice_Size_Obj.ref_id;
                this.id = spice_Size_Obj.id;
                this.size = spice_Size_Obj.size;
                this.name_vn = spice_Size_Obj.name_vn;
                this.name_eng = spice_Size_Obj.name_eng;
                this.alias = spice_Size_Obj.alias;
                this.price = spice_Size_Obj.price;
                Selected = true;
            }
            if (spice_Size_Obj.size == 3)
            {
                this.ref_id = spice_Size_Obj.ref_id;
                this.id = spice_Size_Obj.id;
                this.size = spice_Size_Obj.size;
                this.name_vn = spice_Size_Obj.name_vn;
                this.name_eng = spice_Size_Obj.name_eng;
                this.alias = spice_Size_Obj.alias;
                this.price = spice_Size_Obj.price;
            }

        }
        public long ref_id { get; set; }
        public long id { get; set; }
        public int size { get; set; }
        public string name_vn { get; set; }
        public string name_eng { get; set; }
        public string alias { get; set; }
        public double price { get; set; }
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
    }
    public class cart
    {
        
        public int index { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public int item_sl { get; set; }
        public double nguyengia { get; set; }
        public double extras_price_total { get; set; }
        public string size_name_vn { get; set; }
        public string size_name_en { get; set; }
        public double size_price { get; set; }
        public string name_drink_vn { get; set; }
        public string name_drink_en { get; set; }
        public double nuoc_price { get; set; }
        public string order_node { get; set; }
        public int order_type { get; set; }
        public string order_name_vn { get; set; }
        public string order_name_en { get; set; }

        public int nuoc_sl { get; set; }
        public double total { get; set; }
        public List<drink> drinks { get; set; }
        public List<Spice_Size> spice_Sizes { get; set; }
        public List<extras> Extras { get; set; }
     }
    #endregion
}
