using BlogApp.Data.Abstract;
using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concreate.EfCore
{
	public class EfCorePostRepository : IPostRepository
	{
		private BlogContext _context;
        public EfCorePostRepository(BlogContext context)
        {
			_context = context;
        }
        public IQueryable<Post> Post => _context.Posts;

		public void CreatePost(Post post)
		{
			_context.Posts.Add(post);
			_context.SaveChanges();
		}

		public void EditPost(Post post)
        {
            var entity = _context.Posts.FirstOrDefault(i => i.PostId == post.PostId);

            if(entity != null)
            {
                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.Content = post.Content;
                entity.Url = post.Url;
                entity.IsActive = post.IsActive;
				_context.SaveChanges();
                
            }
        }
		public void EditPost(Post post, int[] tagsIds)
		{
			var entity = _context.Posts.Include(i=>i.Tags).FirstOrDefault(i => i.PostId == post.PostId);

			if (entity != null)
			{
				entity.Title = post.Title;
				entity.Description = post.Description;
				entity.Content = post.Content;
				entity.Url = post.Url;
				entity.IsActive = post.IsActive;
				entity.Tags = _context.Tags.Where(tag => tagsIds.Contains(tag.TagId)).ToList();
				_context.SaveChanges();

			}
		}
	}
}
