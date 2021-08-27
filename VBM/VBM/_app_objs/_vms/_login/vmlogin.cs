using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace VBM._app_objs._vms._login
{
    public class vmlogin : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
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
                vbm_Stores.Add(items);
            }
        }
        void getstore()
        {
            var mg = localdb._manager;
            var val = mg._varialbles;
            foreach(var item in vbm_Stores)
            {
                if(item.ShopName == shopname)
                {
                    val._store_selected = new vbm.objs.vbm_store
                    {
                        ShopID = item.ShopID,
                        ShopName = item.ShopName,
                        DiaChi = item.DiaChi,
                        AvatarStore = item.AvatarStore,
                        QRCodeStore = item.QRCodeStore,
                        IsAllowShipRequestOrder = item.IsAllowShipRequestOrder,
                        LatitudeStore = item.LatitudeStore,
                        LongtitudeStore = item.LongtitudeStore,
                        OpenHourStore = item.OpenHourStore,
                        CloseHourStore = item.CloseHourStore,
                        DistanceAllow = item.DistanceAllow,
                    };
                }
                else
                {
                    //log error
                }
            }
        }
        #endregion



        #region bien
        string shopname_;
        public string shopname
        {
            get
            {
                return shopname_;
            }
            set
            {
                shopname_ = value;
                getstore();
                OnPropertyChanged("shopname");
            }
        }
        public List<string> name { get; set; }
        public List<vbm.objs.vbm_store> vbm_Stores { get; set; }
        #endregion
    }
}
