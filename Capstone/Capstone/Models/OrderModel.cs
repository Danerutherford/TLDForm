using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class OrderModel
    {
        public int AccountNbr { get; set; }

        public string AccountName1 { get; set; }

        public string AccountName2 { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public int IDNbr { get; set; }

        public string HolderType { get; set; }

        public string Neutron { get; set; }

        public char BarCode { get; set; }

        public string WLocation { get; set; }

        public string UPD { get; set; }

        public string Sname { get; set; }

        public char CustomerKey { get; set; }

        public string ClipType { get; set; }

        public string SeriesColor { get; set; }

        public string FreqColor { get; set; }

        public string BadgeUse { get; set; }
    }
}