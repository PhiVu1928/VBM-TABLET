using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VBM._app_objs._vms._promo
{
    public class vmpromo
    {
        public List<vbm.objs.promo_obj> promos { get; set; }
        public vmpromo()
        {
            createPromo();
        }
        public void createPromo()
        {
            var mg = localdb._manager;
            var val = mg._varialbles;
            promos = new List<vbm.objs.promo_obj>();
            foreach(var items in val._promos)
            {
                promos.Add(items);
            }
        }
    }
    public class promo
    {
        public promo()
        {
            Name = "NÂNG SIZE MIỄN PHÍ";
            Time = "13:00 - 17:00";
        }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
