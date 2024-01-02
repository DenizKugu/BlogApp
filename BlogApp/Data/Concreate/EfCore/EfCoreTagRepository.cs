using BlogApp.Data.Abstract;
using BlogApp.Entities;

namespace BlogApp.Data.Concreate.EfCore
{
	public class EfCoreTagRepository : ITagRepository
	{
		private readonly BlogContext _context;
		public EfCoreTagRepository(BlogContext context) 
		{ 
			_context = context;
		}
		public IQueryable<Tag> Tags => _context.Tags;

		public void CreateTag(Tag tag)
		{
			_context.Tags.Add(tag);
			_context.SaveChanges();
		}
	}
}
