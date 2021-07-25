using System;
using System.Collections.Generic;
using System.Text;

namespace VBM._app_objs._general
{
    public class app_manager
    {
        public app_manager()
        {
            _varialbles = new am_varialbles();
            _viewmodels = new am_viewmodels();
            _contents = new am_contents();
            _tools = new am_tools();
            _communicate = new am_api_communicate();
            _cached = new am_cached_data();
        }

        public am_cached_data _cached { get; set; }
        public am_api_communicate _communicate { get; set; }
        public am_viewmodels _viewmodels { get; set; }
        public am_contents _contents { get; set; }
        public am_tools _tools { get; set; }
        public am_varialbles _varialbles { get; set; }

    }
}
