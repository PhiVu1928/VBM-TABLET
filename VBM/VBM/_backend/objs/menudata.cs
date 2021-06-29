using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vbm.objs
{
    public class main_menu_class_obj
    {
        public int id { get; set; }
        public int index { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public List<sub_menu_class_obj> lst_sub_menu { get; set; }
    }

    public class sub_menu_class_obj
    {
        public int id { get; set; }
        public int index { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public List<e_menu_obj> lst_emes { get; set; }
    }

    public class e_menu_obj
    {
        public int index { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public int class_id { get; set; }
        public int type_eme { get; set; }
        public string img { get; set; }
        public bool is_has_combo { get; set; }
        public List<e_menu_size_obj> lst_size { get; set; }
        public List<cb_menu_obj> lst_combo { get; set; }
        public List<int> lst_unsell_store { get; set; }
    }

    public class e_menu_size_obj
    {
        public long id { get; set; }
        public int size { get; set; }
        public string size_name_vn { get; set; }
        public string size_name_en { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public double price { get; set; }
    }

    public class cb_menu_obj
    {
        public long id { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public double price { get; set; }
        public string combine_id { get; set; }
    }

    public class search_eme
    {
        public long id { get; set; }
        public int class_id { get; set; }
        public double price { get; set; }
        public string combine_id { get; set; }
        public string name_vn { get; set; }
        public string name_en { get; set; }
        public int size { get; set; }
        public string size_name_vn { get; set; }
        public string size_name_en { get; set; }
        public List<int> lst_unsell_store { get; set; }
    }

}
