using System;
using System.Collections.Generic;
using System.Text;

namespace vbm.objs
{
    public class mapbox_obj
    {
        public List<mapbox_route> routes { get; set; }
    }

    public class mapbox_route
    {
        public double distance { get; set; }
    }
}
