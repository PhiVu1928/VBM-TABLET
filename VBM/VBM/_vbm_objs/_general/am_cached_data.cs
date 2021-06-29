using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VBM._app_objs._general
{
    public class am_cached_data
    {
        public am_cached_data()
        {

        }

        public void get_cached_values()
        {
            DeviceDB = new _app_utils.SQLiteBase();
            foreach (var t1 in DeviceDB.LstValues)
            {
                switch (t1.DBKey)
                {
                    case "promos":
                        {
                            try
                            {
                                promos = JsonConvert.DeserializeObject<List<vbm.objs.promo_obj>>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "banners":
                        {
                            try
                            {
                                banners = JsonConvert.DeserializeObject<List<vbm.objs.banner_obj>>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "culture_actis":
                        {
                            try
                            {
                                culture_actis = JsonConvert.DeserializeObject<List<vbm.objs.culture_obj>>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "menu":
                        {
                            try
                            {
                                menu = JsonConvert.DeserializeObject<List<vbm.objs.main_menu_class_obj>>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "phoneno":
                        {
                            try
                            {
                                phoneno = t1.DBValue;
                            }
                            catch { }
                            break;
                        }
                    case "ticks":
                        {
                            try
                            {
                                ticks = long.Parse(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "version":
                        {
                            try
                            {
                                version = JsonConvert.DeserializeObject<vbm.objs.dataversion>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "added_pros":
                        {
                            try
                            {
                                added_pros = JsonConvert.DeserializeObject<List<cart_pros>>(t1.DBValue);
                                localdb._manager._varialbles._cart_pros = JsonConvert.DeserializeObject<List<cart_pros>>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "stores":
                        {
                            try
                            {
                                stores = JsonConvert.DeserializeObject<List<vbm.objs.vbm_store>>(t1.DBValue);
                                localdb._manager._varialbles._stores = JsonConvert.DeserializeObject<List<vbm.objs.vbm_store>>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                    case "exts_spis":
                        {
                            try
                            {
                                exts_spis = JsonConvert.DeserializeObject<vbm.objs.emenu_info_return>(t1.DBValue);
                                localdb._manager._varialbles._exts_spis = JsonConvert.DeserializeObject<vbm.objs.emenu_info_return>(t1.DBValue);
                            }
                            catch { }
                            break;
                        }
                }
            }
        }
        
        #region bien
        public List<vbm.objs.promo_obj> promos { get; set; }
       public List<vbm.objs.banner_obj> banners { get; set; }
        public List<vbm.objs.culture_obj> culture_actis { get; set; }
        public List<vbm.objs.vbm_store> stores { get; set; }
        public List<vbm.objs.main_menu_class_obj> menu { get; set; }
        public vbm.objs.emenu_info_return exts_spis { get; set; }
        public string phoneno { get; set; } = "0947968745";
        public long ticks { get; set; }
        public vbm.objs.dataversion version { get; set; }
        public List<cart_pros> added_pros { get; set; }
        public _app_utils.SQLiteBase DeviceDB { get; set; }
        #endregion

        #region functions
        public void update_promos(List<vbm.objs.promo_obj> data)
        {
            try
            {
                DeviceDB.ChangeDBStore("promos", JsonConvert.SerializeObject(data));
                promos = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_banners(List<vbm.objs.banner_obj> data)
        {
            try
            {
                DeviceDB.ChangeDBStore("banners", JsonConvert.SerializeObject(data));
                banners = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_culture_actis(List<vbm.objs.culture_obj> data)
        {
            try
            {
                DeviceDB.ChangeDBStore("culture_actis", JsonConvert.SerializeObject(data));
                culture_actis = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_stores(List<vbm.objs.vbm_store> data)
        {
            try
            {
                DeviceDB.ChangeDBStore("stores", JsonConvert.SerializeObject(data));
                stores = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_menu(List<vbm.objs.main_menu_class_obj> data)
        {
            try
            {
                DeviceDB.ChangeDBStore("menu", JsonConvert.SerializeObject(data));
                menu = data;
            }
            catch(Exception e)
            {
                //error log
            }
        }

        public void update_exts_spis(vbm.objs.emenu_info_return data)
        {
            try
            {
                DeviceDB.ChangeDBStore("exts_spis", JsonConvert.SerializeObject(data));
                exts_spis = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_phoneno(string data)
        {
            try
            {
                DeviceDB.ChangeDBStore("phoneno", data);
                phoneno = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_ticks(long data)
        {
            try
            {
                DeviceDB.ChangeDBStore("ticks", data.ToString());
                ticks = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_version(vbm.objs.dataversion data)
        {
            try
            {
                DeviceDB.ChangeDBStore("version", JsonConvert.SerializeObject(data));
                version = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_added_pros(List<cart_pros> data)
        {
            try
            {
                DeviceDB.ChangeDBStore("added_pros", JsonConvert.SerializeObject(data));
                added_pros = data;
            }
            catch (Exception e)
            {
                //error log
            }
        }

        public void update_added_pros(ObservableCollection<cart_pros> data)
        {
            try
            {
                DeviceDB.ChangeDBStore("added_pros", JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                //error log
            }
        }

        #endregion

    }
}
