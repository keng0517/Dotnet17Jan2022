using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserEFRepo : IRepo<int, User>
    {
        private readonly UserContext _context;

        public UserEFRepo (UserContext context)
        {
            _context = context;
        }
        public bool Add(User t)
        {
            _context.Users.Add(t);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int k)
        {

            _context.Users.Remove(GetT(k));
            _context.SaveChanges();
            return true;
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetT(int k)
        {
            return _context.Users.FirstOrDefault(p => p.user_id == k);
        }

        public bool Update(int k, User t)
        {
            var MyUser = _context.Users.FirstOrDefault(p => p.user_id == k);

            if (MyUser != null)
            {
                MyUser.user_name = t.user_name;
                MyUser.user_password = t.user_password;
                MyUser.user_email = t.user_email;

                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
