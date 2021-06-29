using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace VBM._app_objs._general
{
    public class am_api_communicate
    {
        public am_api_communicate()
        {
            channel = 1;
            tools = new vbm.tools();
        }

        #region bien
        public vbm.tools tools { get; set; }
        public int channel { get; set; }
        #endregion

        #region functions

        private bool isconnect()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// system data
        /// </summary>
        /// <returns></returns>
        public vbm.objs.dataversion get_version()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_version().Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.dataversion > (JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.main_menu_class_obj> get_menus()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_menudata(channel).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<vbm.objs.main_menu_class_obj>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public vbm.objs.emenu_info_return get_all_extras_spices()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_all_extras_spices().Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.emenu_info_return>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.vbm_store> get_stores()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_vbmstores().Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<vbm.objs.vbm_store>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public vbm.objs.digital_wallet get_digitals()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_digitals().Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.digital_wallet>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.promo_obj> get_promos()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_promos(channel).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<vbm.objs.promo_obj>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.banner_obj> get_banners()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_banners().Result;
            if (result.success)
            {
               return JsonConvert.DeserializeObject<List<vbm.objs.banner_obj>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.culture_obj> get_cultures()
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_cultures(channel).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<vbm.objs.culture_obj>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public vbm.objs.promotion_time check_promo_time(int promoid, int shopid)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.check_promo_time(promoid, shopid).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.promotion_time>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public vbm.objs.internal_contact check_order_time(bool IsTimed, DateTime time, int ShopID)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.check_order_time(IsTimed, time, ShopID).Result;
            if (result.success)
            {
                return result;
            }
            else
            {
                // log errors
            }
            return null;
        }


        /// <summary>
        /// user data
        /// </summary>
        /// <returns></returns>
        public vbm.objs.full_user_info get_user_info(string uname)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_user_info(uname).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.full_user_info>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.user_address> get_user_address(string uname, long userid)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_user_save_address(uname, userid).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<vbm.objs.user_address>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public vbm.objs.get_gifts_bmls get_user_gifts_bmls(string uname, long userid)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_user_gifts_bmls(channel, uname, userid).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.get_gifts_bmls>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.user_noti_obj> get_user_notis(string uname, long userid, long ticks)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_user_notis(uname, userid, ticks).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<vbm.objs.user_noti_obj>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public vbm.objs.bill_client get_user_ratingbills(string uname, long userid)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_user_ratting_bills(uname, userid).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.bill_client>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public vbm.objs.bill_client get_user_ratingbills(long billid)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_billinfo(billid).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<vbm.objs.bill_client>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<vbm.objs.bill_client> get_user_hisbills(long userid)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_history_bills(userid).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<vbm.objs.bill_client>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        public List<long> get_lst_fav(string username, long userid)
        {
            if (!isconnect())
            {
                //log error
                return null;
            }

            var result = tools.get_user_favs(username, userid).Result;
            if (result.success)
            {
                return JsonConvert.DeserializeObject<List<long>>(JsonConvert.SerializeObject(result.data));
            }
            else
            {
                // log errors
            }
            return null;
        }

        #endregion

    }

}
