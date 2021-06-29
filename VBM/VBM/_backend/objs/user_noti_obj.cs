using System;
using System.Collections.Generic;
using System.Text;

namespace vbm.objs
{
    public class user_noti_obj
    {
        public int IsPopup
        {
            get; set;
        }

        public string PopupHTML
        {
            get; set;
        }

        public long Ticks
        {
            get; set;
        }

        public long UserID
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string TitleEn
        {
            get; set;
        }

        public string Body
        {
            get; set;
        }

        public string BodyEn
        {
            get; set;
        }

        public bool IsValid
        {
            get; set;
        }

        public int IsRead
        {
            get; set;
        }

        public DateTime CreateDate
        {
            get; set;
        }

        public long NotiID { get; set; }

        public string WebViewUrl { get; set; }

        public string WebViewUrlEn { get; set; }
        public bool isnew { get; set; }
    }
}
