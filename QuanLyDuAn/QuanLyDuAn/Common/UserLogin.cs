using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public List<long> DuAn { get; set; }
    }
}