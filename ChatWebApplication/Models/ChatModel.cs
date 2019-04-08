namespace ChatWebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChatModel : DbContext
    {
        public ChatModel()
            : base("name=ChatModel")
        {
        }

        public virtual DbSet<Chat> Chat { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .Property(e => e.Message)
                .IsUnicode(false);
        }
    }
}
