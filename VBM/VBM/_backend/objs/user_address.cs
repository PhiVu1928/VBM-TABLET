using System;
using System.Collections.Generic;
using System.Text;

namespace vbm.objs
{
    public class user_address
    {
        public long UserAddressID { get; set; }
        public long UserID { get; set; }
        public string Adress { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Notes { get; set; }
        public bool IsSave { get; set; }
        public int ShopID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
