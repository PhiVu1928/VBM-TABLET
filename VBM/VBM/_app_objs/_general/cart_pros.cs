using System;
using System.Collections.Generic;
using System.Text;

namespace VBM._app_objs._general
{
    /// <summary>
    /// order_note: "regular": thuong, "upale", "cc", va ten cac loai khuyen mai code va qua code. Chu yeu se dung cai nay de group lai san pham
    /// order_type: 0: thuong, 55555: "upale", -1301: "cc", id cac loai khuyen mai va qua. Chu yeu se dung cai nay de group lai san pham
    /// order_name: thuong: de trong, upsale: San pham giam gia, cc: san pham lay sau, ten cac loai km va qua
    /// </summary>
    public class cart_pros : ICloneable
    {
        public long id { get; set; }
        public int sl { get; set; }
        public double nguyengia { get; set; }
        public double dongia { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public string alias { get; set; }
        public string order_node { get; set; }
        public int order_type { get; set; }
        public string order_name_vn { get; set; }
        public string order_name_en { get; set; }
        public string note { get; set; }
        public string discount_code { get; set; }
        public List<cart_ex> extras { get; set; }
        public List<cart_spice> spices { get; set; }
        public cart_pros()
        {

        }
        public cart_pros(cart_pros other)
        {
            id = other.id;
            sl = other.sl;
            nguyengia = other.nguyengia;
            dongia = other.dongia;
            name_vn = other.name_vn;
            name_en = other.name_en;
            alias = other.alias;
            order_node = other.order_node;
            order_type = other.order_type;
            order_name_vn = other.order_name_vn;
            order_name_en = other.order_name_en;
            note = other.note;
            discount_code = other.discount_code;
            extras = new List<cart_ex>();
            spices = new List<cart_spice>();
            foreach (var t1 in other.extras)
            {
                extras.Add(new cart_ex(t1));
            }
            foreach (var t1 in other.spices)
            {
                spices.Add(new cart_spice(t1));
            }
        }
        public Object Clone()
        {
            return new cart_pros(this);
        }
    }

    public class cart_ex : ICloneable
    {
        public long id { get; set; }
        public double price { get; set; }
        public string name_vn { get; set; }
        public double name_en { get; set; }
        public int sl { get; set; }
        public string note { get; set; }
        public string discount { get; set; }
        public cart_ex()
        {

        }
        public cart_ex(cart_ex other)
        {
            id = other.id;
            price = other.price;
            name_vn = other.name_vn;
            name_en = other.name_en;
            sl = other.sl;
            note = other.note;
            discount = other.discount;
        }
        public Object Clone()
        {
            return new cart_ex(this);
        }
    }

    public class cart_spice : ICloneable
    {
        public long id { get; set; }
        public int ref_revamp { get; set; }
        public int size { get; set; }
        public string name_vn { get; set; }
        public double name_en { get; set; }
        public int sl { get; set; }
        public string note { get; set; }
        public string discount { get; set; }
        public cart_spice()
        {

        }
        public cart_spice(cart_spice t)
        {
            id = t.id;
            ref_revamp = t.ref_revamp;
            size = t.size;
            name_vn = t.name_vn;
            name_en = t.name_en;
            sl = t.sl;
            note = t.note;
            discount = t.discount;
        }
        public Object Clone()
        {
            return new cart_spice(this);
        }
    }

}
