using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VBM._vbm_objs._vms._promo
{
    public class vmpromo
    {
        public ObservableCollection<promo> promos { get; set; }
        public vmpromo()
        {
            createPromo();
        }
        public void createPromo()
        {
            promos = new ObservableCollection<promo>();
            for(int i = 0; i < 5; i++)
            {
                promos.Add(new promo());
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
