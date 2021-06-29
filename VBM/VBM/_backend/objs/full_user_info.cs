using System;
using System.Collections.Generic;
using System.Text;

namespace vbm.objs
{
    public class full_user_info
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string FaceId { get; set; }
        public string Fullname { get; set; }
        public string PhoneNo { get; set; }
        public int Point { get; set; }
        public string UserLevel { get; set; }
        public int SoBanhTichLuy { get; set; }
        public int SoQuaTichLuyConLai { get; set; }
        public string AvatarImage { get; set; }
        public int UserStatus { get; set; }
        public int IndexVBMEmp { get; set; }
        public int ComboNV { get; set; }
        public string KudovaUserID { get; set; }
        public bool activeKudova { get; set; }
        public bool isSurvey { get; set; }
        public bool isSurveySpagheti { get; set; }
        public bool is_has_birthday { get; set; }
        public string special_voucher { get; set; }
    }
}
