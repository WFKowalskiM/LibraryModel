using WebApplication4.Models.Data;

namespace WebApplication4.Models.User
{
    public class UserStorage
    {
        private readonly LibDbContext DbContext;
        public UserStorage(LibDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public List<AppUser> userList { get; set; }
    }
}
