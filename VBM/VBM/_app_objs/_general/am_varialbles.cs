using System;
using System.Collections.Generic;
using System.Text;

namespace VBM._app_objs._general
{
    public class am_varialbles
    {
        public am_varialbles()
        {
            //tranh null. neu co data cached thi cai do convert sang gtri nay
            _cart_pros = new List<cart_pros>();
        }

        #region for system data

        public List<vbm.objs.promo_obj> _promos { get; set; }
        public List<vbm.objs.banner_obj> _banners { get; set; }
        public List<vbm.objs.culture_obj> _cultures { get; set; }
        public List<vbm.objs.main_menu_class_obj> _menus { get; set; }
        public vbm.objs.emenu_info_return _exts_spis { get; set; }
        public List<vbm.objs.vbm_store> _stores { get; set; }

        #endregion

        #region for user data

        /// <summary>
        /// lay ngay khi khoi dong app va thuc hien update neu co doi voi _user_info
        /// </summary>
        public vbm.objs.full_user_info _user_info { get; set; }
        public List<vbm.objs.user_noti_obj> _user_notis { get; set; }
        public vbm.objs.get_gifts_bmls _user_gifts_bmls { get; set; }
        public vbm.objs.bill_client _user_rating_bill { get; set; }
        public List<vbm.objs.user_address> _user_address { get; set; }

        /// <summary>
        /// lay khi render menu page neu null va thuc hien update neu co (boi vi menu da la 1 page, ko phai view)
        /// </summary>
        public List<long> _user_favs { get; set; }

        #endregion

        #region process
        public List<_app_objs._general.cart_pros> _cart_pros { get; set; }
        public am_address _selected_address { get; set; }

        #endregion

    }
}
