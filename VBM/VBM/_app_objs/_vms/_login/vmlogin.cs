using System;
using System.Collections.Generic;
using System.Text;

namespace VBM._app_objs._vms._login
{
    public class vmlogin
    {
        public vmlogin()
        {
            RenderStore();
        }
        #region process

        void RenderStore()
        {
            var mg = localdb._manager;
            var val = mg._varialbles;
            vbm_Stores = new List<vbm.objs.vbm_store>();
            name = new List<string>();
            foreach(var items in val._stores)
            {
                name.Add(items.ShopName);
            }
        }

        #endregion



        #region bien
        public List<string> name { get; set; }
        public List<vbm.objs.vbm_store> vbm_Stores { get; set; }
        #endregion
    }
}
