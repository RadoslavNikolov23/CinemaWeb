namespace CinemaApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Comment("Manager in the system")]
    public class Manager
    {
        [Comment("Manager identifier")]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        [Comment("Manager's user entity")]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Cinema> ManagedCinemas { get; set; }
            = new HashSet<Cinema>();
    }
}
