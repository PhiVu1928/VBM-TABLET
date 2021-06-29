using System;
using System.Collections.Generic;
using System.Text;

namespace vbm
{
    //urls 
    public partial class input_data
    {
        public static string port = "http://vuabanhmi.com:6519";
        //public static string port = "http://localhost:6519";
        public static string stores_url = $"{port}/api/UserData/vbm_stores";
        public static string menu_url = $"{port}/api/UserData/get_menu_data";
        public static string extras_spices_url = $"{port}/api/UserData/get_all_extras_spices";
        public static string degital_reslease_url = $"{port}/api/UserData/lst_degital_reslease";
        public static string exsp_url = $"{port}/api/UserData/get_extraspices";
        public static string version_url = $"{port}/api/UserData/get_data_ver";
        public static string promo_url = $"{port}/api/UserData/all_promotions";
        public static string promo_detail_url = $"{port}/api/UserData/promo_menu";
        public static string banner_url = $"{port}/api/UserData/vbm_banners";
        public static string culture_url = $"{port}/api/UserData/vbm_culture";
        public static string define_shipping_store_url = $"{port}/api/UserData/define_shipping_store";
        public static string check_promo_time_url = $"{port}/api/UserData/check_promo_time";
        public static string check_order_time_url = $"{port}/api/UserData/check_order_time";
        public static string user_info_url = $"{port}/api/UserData/full_user_info";
        public static string user_gifts_url = $"{port}/api/UserData/get_gifts_bmls";
        public static string user_favs_url = $"{port}/api/UserData/get_lst_fav";
        public static string user_notis_url = $"{port}/api/UserData/get_lst_user_notis";
        public static string user_address_url = $"{port}/api/UserData/get_user_addresses";
        public static string user_rating_bills_url = $"{port}/api/UserData/get_user_reate_req_bills";
        public static string user_billinfo_url = $"{port}/api/UserData/get_bill_info";
        public static string user_orderedbills_url = $"{port}/api/UserData/get_ordered_bills";

        public static string banner_img = "http://vuabanhmi.com/images/appbanner/";
        public static string emenu_img = "http://manage.vuabanhmi.com/SpImg/";
    }

}
