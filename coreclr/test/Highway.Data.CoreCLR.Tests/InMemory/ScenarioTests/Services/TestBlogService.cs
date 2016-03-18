using System.Collections.Generic;
using Highway.Data.CoreCLR.Tests.InMemory.Domain;
using Highway.Data.CoreCLR.Tests.InMemory.ScenarioTests.Queries;

namespace Highway.Data.CoreCLR.Tests.InMemory.ScenarioTests.Services
{
    public class TestBlogService
    {
        private readonly IRepository _repo;

        public TestBlogService(IRepository repo)
        {
            _repo = repo;
        }

        public void StartBlog(string title, Author author)
        {
            _repo.Context.Add(new Blog(title) {Author = author});
            _repo.Context.Commit();
        }

        public void Post(string title, Post post)
        {
            var blog = _repo.Find(new FindBlogByTitle(title));
            blog.Posts.Add(post);
            _repo.Context.Commit();
        }

        public IEnumerable<Post> Posts(string title)
        {
            var blog = _repo.Find(new FindBlogByTitle(title));
            return blog.Posts;
        }
    }
}