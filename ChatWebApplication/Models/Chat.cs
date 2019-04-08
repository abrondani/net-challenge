namespace ChatWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chat")]
    public partial class Chat
    {
        public int Id { get; set; }

        [StringLength(200), Required(ErrorMessage = "The message is required")]
        public string Message { get; set; }

        public long TimeStamp { get; set; }

        public string UserName { get; set; }
    }
}
