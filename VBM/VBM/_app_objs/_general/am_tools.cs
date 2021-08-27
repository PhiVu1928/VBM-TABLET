using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace VBM._app_objs._general
{
    public class am_tools
    {
        public am_tools()
        {

        }

        public string HtmlToText(string HTMLText, bool decode = true)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            var stripped = reg.Replace(HTMLText, "");
            return decode ? HttpUtility.HtmlDecode(stripped) : stripped;
        }

        public void ios_safe_area(PopupPage page)
        {
            string phoneModel = DeviceInfo.Model;

            //DeviceInfo.Model => Real device Model  
            //iPhone7,1  => iPhone 6+  
            //iPhone7,2  => iPhone 6  
            //iPhone8,1  => iPhone 6S  
            //iPhone8,2  => iPhone 6S+  
            //iPhone8,4  => iPhone SE  
            //iPhone9,1  => iPhone 7  
            //iPhone9,2  => iPhone 7+  
            //iPhone9,3  => iPhone 7  
            //iPhone9,4  => iPhone 7+  
            //iPhone10,1 => iPhone 8  
            //iPhone10,2 => iPhone 8+  
            //iPhone10,3 => iPhone X  
            //iPhone11,2 => iPhone XS  
            //iPhone11,4 => iPhone XS Max  
            //iPhone11,8 => iPhone XR  

            if (phoneModel.ToLower().Contains("iphone11") || phoneModel.ToLower().Contains("iphone12") ||
                phoneModel.ToLower() == "iphone10,3" || phoneModel.ToLower().Contains("x86"))
                page.On<iOS>().SetUseSafeArea(true);
        }

        public string avoid_cached_img(string url)
        {
            return $"{url}?{DateTime.Now.Second}";
        }

        public void start_prepare_data2()
        {
            var mg = localdb._manager;
            var com = mg._communicate;
            var val = mg._varialbles;
            try
            {
                var cur_version = com.get_version();
                if (cur_version != null)
                {
                    try
                    {
                        if (mg._cached.version == null)
                        {
                            //thuc hien lay toan bo system data
                            //bo qua lay user data (vi chac chan chua start app lan nao)
                            //tao tasks system data
                            var system_tasks = new List<Task>();
                            system_tasks.Add(Task.Run(() => { val._menus = com.get_menus(); }));
                            system_tasks.Add(Task.Run(() => { val._exts_spis = com.get_all_extras_spices(); }));
                            system_tasks.Add(Task.Run(() => { val._promos = com.get_promos(); }));
                            system_tasks.Add(Task.Run(() => { val._banners = com.get_banners(); }));
                            system_tasks.Add(Task.Run(() => { val._cultures = com.get_cultures(); }));
                            system_tasks.Add(Task.Run(() => { val._stores = com.get_stores(); }));

                            //se add task system notis (tam thoi chua)

                            Task.WaitAll(system_tasks.ToArray());

                            if (val._menus != null && val._promos != null && val._banners != null && val._cultures != null && val._stores != null && val._exts_spis != null)
                            {
                                //thuc hien 'cach' cac thong tin neu qua trinh start app thanh cong
                                mg._cached.update_menu(val._menus);
                                mg._cached.update_exts_spis(val._exts_spis);
                                mg._cached.update_promos(val._promos);
                                mg._cached.update_banners(val._banners);
                                mg._cached.update_culture_actis(val._cultures);
                                mg._cached.update_version(cur_version);
                                mg._cached.update_stores(val._stores);
                                //thuc hien start app dc roi
                                start_app();
                            }

                        }
                        else
                        {
                            var system_tasks = new List<Task>();
                            if (cur_version.menu_ver > mg._cached.version.menu_ver)
                            {
                                //add task menu
                                system_tasks.Add(Task.Run(() => { val._menus = com.get_menus(); }));
                                system_tasks.Add(Task.Run(() => { val._exts_spis = com.get_all_extras_spices(); }));
                            }
                            else
                            {
                                //set am_contents _menu = cached menu
                                val._menus = mg._cached.menu;
                                val._exts_spis = mg._cached.exts_spis;
                            }
                            if (cur_version.promo_ver > mg._cached.version.promo_ver)
                            {
                                //add task promos
                                system_tasks.Add(Task.Run(() => { val._promos = com.get_promos(); }));
                            }
                            else
                            {
                                //set am_contents _promos = cached promos
                                val._promos = mg._cached.promos;
                            }
                            if (cur_version.hot_banner_ver > mg._cached.version.hot_banner_ver)
                            {
                                //add task banners
                                system_tasks.Add(Task.Run(() => { val._banners = com.get_banners(); }));
                            }
                            else
                            {
                                //set am_contents _banners = cached banners
                                val._banners = mg._cached.banners;
                            }
                            if (cur_version.culture_acti_ver > mg._cached.version.culture_acti_ver)
                            {
                                //add task cultures
                                system_tasks.Add(Task.Run(() => { val._cultures = com.get_cultures(); }));
                            }
                            else
                            {
                                //set am_contents _culture = cached cultures
                                val._cultures = mg._cached.culture_actis;
                            }
                            if (cur_version.shop_ver > mg._cached.version.shop_ver)
                            {
                                //add task shops
                                system_tasks.Add(Task.Run(() => { val._stores = com.get_stores(); }));
                            }
                            else
                            {
                                val._stores = mg._cached.stores;
                            }

                            //se add task system notis (tam thoi chua)

                            Task.WaitAll(system_tasks.ToArray());

                            if (val._menus != null && val._promos != null && val._banners != null && val._cultures != null && val._stores != null && val._exts_spis != null)
                            {
                                //thuc hien 'cach' cac thong tin neu qua trinh start app thanh cong
                                mg._cached.update_menu(val._menus);
                                mg._cached.update_exts_spis(val._exts_spis);
                                mg._cached.update_promos(val._promos);
                                mg._cached.update_banners(val._banners);
                                mg._cached.update_culture_actis(val._cultures);
                                mg._cached.update_version(cur_version);
                                //get user info
                                if (mg._cached.phoneno != null)
                                {
                                    //lay user info
                                    val._user_info = com.get_user_info(mg._cached.phoneno);
                                    if (val._user_info != null)
                                    {
                                        //tao tasks moi
                                        var user_tasks = new List<Task>();
                                        //add task lay _user_notis
                                        user_tasks.Add(Task.Run(() => { val._user_notis = com.get_user_notis(val._user_info.PhoneNo, val._user_info.UserID, mg._cached.ticks); }));
                                        //add task lay _user_favs
                                        user_tasks.Add(Task.Run(() => { val._user_favs = com.get_lst_fav(val._user_info.PhoneNo, val._user_info.UserID); }));
                                        //add task lay _user_gifts_bmls
                                        user_tasks.Add(Task.Run(() => { val._user_gifts_bmls = com.get_user_gifts_bmls(val._user_info.PhoneNo, val._user_info.UserID); }));
                                        //add tasks lay _user_rating_bill
                                        user_tasks.Add(Task.Run(() => { val._user_rating_bill = com.get_user_ratingbills(val._user_info.PhoneNo, val._user_info.UserID); }));
                                        //add tasks lay _user_address
                                        user_tasks.Add(Task.Run(() => { val._user_address = com.get_user_address(val._user_info.PhoneNo, val._user_info.UserID); }));

                                        Task.WaitAll(user_tasks.ToArray());

                                        if (val._user_notis != null && val._user_favs != null && val._user_gifts_bmls != null && val._user_gifts_bmls != null && val._user_address != null)
                                        {
                                            //update tasks cached
                                            mg._cached.update_ticks(DateTime.Now.Ticks);
                                            //thuc hien start app dc roi
                                            start_app();
                                        }
                                        else
                                        {   
                                            //alert error
                                        }
                                    }
                                    else
                                    {
                                        //alert error
                                    }
                                }
                                else
                                {
                                    //thuc hien start app dc roi
                                    start_app();
                                }
                            }
                            else
                            {
                                //alert error
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //alert error
                        //log error
                    }
                }
                else
                {
                    //alert disconnect
                }
            }
            catch (Exception e)
            {

            }
        }

        public async void start_prepare_data()
        {
            
            var mg = localdb._manager;
            var com = mg._communicate;
            var val = mg._varialbles;
            try
            {
                var system_tasks = new List<Task>();
                system_tasks.Add(Task.Run(() => { val._menus = com.get_menus(); }));
                system_tasks.Add(Task.Run(() => { val._exts_spis = com.get_all_extras_spices(); }));
                system_tasks.Add(Task.Run(() => { val._promos = com.get_vouchers(); }));
                system_tasks.Add(Task.Run(() => { val._stores = com.get_stores(); }));

                Task.WaitAll(system_tasks.ToArray());

                if(val._menus != null && val._exts_spis != null && val._cart_temp != null && val._promos != null)
                {
                    mg._cached.update_menu(val._menus);
                    mg._cached.update_exts_spis(val._exts_spis);
                    mg._cached.update_promos(val._promos);
                    mg._cached.update_stores(val._stores);
                    start_app();
                }    
            }
            catch(Exception)
            {
                 await App.Current.MainPage.DisplayAlert("Error", "Không lấy được thông tin, vui long thử lại sau !!!", "OK");
            }
        }

        private void start_app()
        {
            var bg = localdb._manager;
            Device.BeginInvokeOnMainThread(() =>
            {
                bg._contents._cover_page.start_app();
            });

        }
        public void start_prepare_data1()
        {
            start_app1();
        }

        private void start_app1()
        {
            var bg = localdb._manager;
            Device.BeginInvokeOnMainThread(() =>
            {
                bg._contents._outline_page1.start_app();
            });

        }

    }
}