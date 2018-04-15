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

        public OrderModel()
        {
            Neutron = "NT";
            HolderType = "LA";
            WLocation = "WB";
            
        }


       [Key]
       public int orderId { get; set; }
        
        
        [Display (Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Number of Badges")]
        public string NumBadge { get; set; }

        [StringLength(6, ErrorMessage = "Cannot be longer than 6 characters.")]
        public string AccountNbr { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string AccountName1 { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string AccountName2 { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string Fname { get; set; }

        [StringLength(17, ErrorMessage = "Cannot be longer than 17 characters.")]
        public string Lname { get; set; }

        [StringLength(8, ErrorMessage = "Cannot be longer than 8 characters.")]
        public string IDNbr { get; set; }

        [StringLength(2, ErrorMessage = "Cannot be longer than 2 characters.")]
        public string HolderType { get; set; }
        



        [StringLength(2, ErrorMessage = "Cannot be longer than 2 characters.")]
        public string Neutron { get; set; }

        public string BarCode { get; set; }

        public string WLocation { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string UPD { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        public string Sname { get; set; }

        public string CustomerKey { get; set; }

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