using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineChat.PersistantMain.Chats;
using OnlineChat.PersistantMain.General;

namespace OnlineChat.PersistantMain.Chats
{
    public class Chat
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public User Reciver { get; set; }
        public int ReciverId { get; set; }
        public User Sender { get; set; }
        public int SenderId { get; set; }
    }
}


namespace OnlineChat.PersistantMain.Configuration
{
    public class ChatMap : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable(nameof(Chat), "Chat");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Reciver)
                    .WithMany(a => a.Chats)
                    .HasForeignKey(e => e.ReciverId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Reciver)
                   .WithMany(a => a.Chats)
                   .HasForeignKey(e => e.ReciverId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
