using System;
using System.Collections.Generic;
using System.Text;
using vbm.objs;
using VBM._app_utils;

namespace VBM
{
    public class localdb
    {
       
        /// <summary>
        /// ngon ngu
        /// </summary>
        static int lange_ = 1;
        public static int lange
        {
            get { return lange_; }
            set
            {
                lange_ = value;
                //change
            }
        }

        public static _app_objs._general.app_manager _manager { get; set; }

    }
}
