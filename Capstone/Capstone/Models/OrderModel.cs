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
        
        
        [Display (Name = "Date")]
        public string Date { get; set; }

        [Display(Name = "Number of Badges")]
        public int NumBadge { get; set; }

        [StringLength(6, ErrorMessage = "Cannot be longer than 6 characters.")]
        public int AccountNbr { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string AccountName1 { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string AccountName2 { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string Fname { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string Lname { get; set; }

        [StringLength(8, ErrorMessage = "Cannot be longer than 8 characters.")]
        public int IDNbr { get; set; }

        [StringLength(2, ErrorMessage = "Cannot be longer than 2 characters.")]
        string HType = "LA";
        public string HolderType {
            get
            {
                return HType;
            }

            set
            {
                HType = value;
            }
        }



        [StringLength(2, ErrorMessage = "Cannot be longer than 2 characters.")]
        public string Neutron { get; set; }

        public char BarCode { get; set; }

        public string WLocation { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string UPD { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string Sname { get; set; }

        public char CustomerKey { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string ClipType { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string SeriesColor { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string FreqColor { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string BadgeUse { get; set; }

      
    }

    

    public class OrderDBContext : DbContext
    {
        public OrderDBContext(): base("Capstone")
        {
            Database.SetInitializer<OrderDBContext>(new DropCreateDatabaseIfModelChanges<OrderDBContext>());
        }

        public DbSet<OrderModel> Orders { get; set; }

        
    }

}