using BlogApp.Data.Abstract;
using BlogApp.Entities;

namespace BlogApp.Data.Concreate.EfCore
{
	public class EfCoreUserRepository : IUserRepository
	{
		private readonly BlogContext _context;
		public EfCoreUserRepository(BlogContext context) 
		{ 
			_context = context;
		}
		//IQueryable<User> Users => _context.Users;

		public IQueryable<User> Users => _context.Users;

		public void CreateUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}

	}
}
