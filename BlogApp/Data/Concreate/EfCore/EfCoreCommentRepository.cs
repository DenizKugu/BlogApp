using BlogApp.Data.Abstract;
using BlogApp.Entities;

namespace BlogApp.Data.Concreate.EfCore
{
	public class EfCoreCommentRepository : ICommentRepository
	{
		private readonly BlogContext _context;

		public EfCoreCommentRepository(BlogContext context)
		{
			_context = context;
		}
		public IQueryable<Comment> Comments => _context.Comments;

		public void CreateComment(Comment comment)
		{
			_context.Comments.Add(comment);
			_context.SaveChanges();
		}
	}
}
