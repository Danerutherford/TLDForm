using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.Entity;

namespace Capstone.Models
{
    public class OrderModel
    {
        [Key]
        public int orderId { get; set; }

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

    public class OrderDBContext: DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
    }

}