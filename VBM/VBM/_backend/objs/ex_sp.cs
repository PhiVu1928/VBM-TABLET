using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vbm.objs
{
    public class extra_obj
    {
        public long id { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public string alias { get; set; }
        public double price { get; set; }
        public List<long> mons { get; set; }
    }

    public class spice_obj
    {
        public long ref_id { get; set; }
        public long id_default { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public List<long> mons { get; set; }
        public List<spice_size_obj> lst_items { get; set; }

    }

    public class spice_size_obj
    {
        public long ref_id { get; set; }
        public long id { get; set; }
        public int size { get; set; }
        public string name_vn { get; set; }
        public string name_eng { get; set; }
        public string alias { get; set; }
        public double price { get; set; }
    }

    public class emenu_info_return
    {
        public List<extra_obj> extras { get; set; }
        public List<spice_obj> spices { get; set; }
    }

}
