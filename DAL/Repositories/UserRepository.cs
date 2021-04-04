using DAL.Models;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private ApplicationDbContext _dbContext; 

        public UserRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User Create(User user)
        {
            var entity =_dbContext.Add(user);
            _dbContext.SaveChanges();
            return entity.Entity;
        }

        public User Update(User user)
        {
            var entity = _dbContext.Update(user);
            _dbContext.SaveChanges();
            return entity.Entity;
        }

        public void Delete(User user)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
