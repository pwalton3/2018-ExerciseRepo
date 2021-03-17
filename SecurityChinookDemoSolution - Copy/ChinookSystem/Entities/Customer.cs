namespace ChinookSystem.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    internal partial class Customer
    {
        private string _Company;
        private string _Address;
        private string _City;
        private string _State;
        private string _Country;
        private string _PostalCode;
        
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage ="First name is a required field!")]
        [StringLength(40, ErrorMessage ="First name is limited to 40 characters!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last name is a required field!")]
        [StringLength(20, ErrorMessage ="Last name is limited to 20 characters!")]
        public string LastName { get; set; }

        [StringLength(80, ErrorMessage ="Company is limited to 80 characters!")]
        public string Company 
        { 
            get { return _Company; }
            set { _Company = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(70, ErrorMessage = "Address is limited to 70 characters!")]
        public string Address 
        {
            get { return _Address; }
            set { _Address = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "City is limited to 40 characters!")]
        public string City 
        { 
            get { return _City; }
            set { _City = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "State is limited to 40 characters!")]
        public string State 
        {
            get { return _State; }
            set { _State = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "Country is limited to 40 characters!")]
        public string Country
        {
            get { return _Country; }
            set { _Country = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(10, ErrorMessage = "Postal Code is limited to 10 characters!")]
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(24, ErrorMessage = "Phone is limited to 24 characters!")]
        public string Phone { get; set; }

        [StringLength(24, ErrorMessage = "Fax is limited to 24 characters!")]
        public string Fax { get; set; }

        [Required(ErrorMessage ="Email is a required field!")]
        [StringLength(60, ErrorMessage = "Email is limited to 60 characters!")]
        public string Email { get; set; }

        public int? SupportRepId { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
