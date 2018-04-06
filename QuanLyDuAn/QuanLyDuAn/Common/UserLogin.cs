using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserID { get; set; }
        public string Name { get; set; }
    }
}