using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            foreach(var items in val._promos.Where(x => x.id == 101))
            {
                promos.Add(items);
            }
        }
    }
}
