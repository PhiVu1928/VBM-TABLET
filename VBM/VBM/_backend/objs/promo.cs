using System;
using System.Collections.Generic;
using System.Text;

namespace vbm.objs
{
    public class promo_obj
    {
        public int id { get; set; }
        public string img_vn { get; set; }
        public string img_en { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public string url_vn { get; set; }
        public string url_en { get; set; }
    }

    public class promostep
    {
        public int order { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public List<promo_emenus> lst_emes { get; set; }
    }

    public class promo_emenus
    {
        public int promo_id { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public string img { get; set; }
        public int default_size { get; set; }
        public List<promo_eme_size> lstsizes { get; set; }
    }

    public class promo_eme_size
    {
        public int size { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public long id { get; set; }
        public double nguyengia { get; set; }
        public double dongia { get; set; }
    }

}
