using System;
using System.Collections.Generic;
using System.Text;

namespace vbm.objs
{
    public class api_trans
    {
        public bool success { get; set; }
        public object Data { get; set; }
        public object Datas { get; set; }
    }

    public class internal_contact
    {
        public bool success { get; set; }
        public object data { get; set; }
        public int err_type { get; set; } //0: ok, 1: server received but had burf, 2: try catch error
    }

}
