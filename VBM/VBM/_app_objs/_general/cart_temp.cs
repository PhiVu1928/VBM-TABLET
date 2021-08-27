using System;
using System.Collections.Generic;
using System.Text;

namespace VBM._app_objs._general
{
    public class cart_temp
    {
        public cart_temp(_vms._detail.cart cart)
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
            foreach(var item in cart.Extras)
            {
                Extras.Add(new cart_extra(item));
            }
            foreach(var item in cart.spice_Sizes)
            {
                spice_Sizes.Add(new cart_spices(item));
            }    
            foreach(var item in cart.drinks)
            {
                cart_Nuocs.Add(new cart_nuoc(item));
            }
        }
        public int index { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public int item_sl { get; set; }
        public string size_name_vn { get; set; }
        public string size_name_en { get; set; }
        public double size_price { get; set; }
        public double nguyengia { get; set; }
        public double extras_price_total { get; set; }
        public string name_drink_vn { get; set; }
        public string name_drink_en { get; set; }
        public double total { get; set; }
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
        public cart_nuoc(_vms._detail.drink drink)
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
        public cart_extra(_vms._detail.extras extras)
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
        public cart_spices(_vms._detail.Spice_Size spice_Size)
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
}
