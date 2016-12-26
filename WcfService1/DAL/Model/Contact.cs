namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int ContactId { get; set; }

        [StringLength(250)]
        public string ContactName { get; set; }

        [StringLength(50)]
        public string ContactPhone { get; set; }

        [StringLength(250)]
        public string ContactAddress { get; set; }

        public int? UserRef { get; set; }

        public virtual User User { get; set; }
    }
}
