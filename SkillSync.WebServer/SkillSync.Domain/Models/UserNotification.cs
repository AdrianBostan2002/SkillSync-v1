namespace SkillSync.Domain.Models
{
    public class UserNotification
    {
        public string SenderId { get; set; }
        public User Sender { get; set; }

        public string ReceiverId { get; set; }
        public User Receiver { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}