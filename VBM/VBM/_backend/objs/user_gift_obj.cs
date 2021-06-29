using System;
using System.Collections.Generic;
using System.Text;

namespace vbm.objs
{
    public class user_gift_obj
    {
        public int TypeID { get; set; }
        public List<int> use_channel { get; set; }
        public string Code { get; set; }
        public string nameVN { get; set; }
        public string nameEN { get; set; }
        public List<gift_item> lst_EmeIDs { get; set; }
        public int slg { get; set; }
        public string url_vn { get; set; }
        public string url_en { get; set; }
        public double mintt_deli { get; set; }
        public double mintht_deli { get; set; }
        public string img { get; set; }
    }

    public class gift_item
    {
        public long ID { get; set; }
        public int Size { get; set; }
        public string Img { get; set; }
        public double nguyengia { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public long size_refer { get; set; }
        public double dongia { get; set; }
    }

    public class bmls_obj
    {
        public long SpID { get; set; }

        public int SoLg { get; set; }
    }

    public class get_gifts_bmls
    {
        public List<user_gift_obj> lst_gifts { get; set; }
        public List<bmls_obj> lst_bmls { get; set; }
    }
}
