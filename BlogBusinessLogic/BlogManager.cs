using BlogModel;
using BlogRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBusinessLogic
{
    public class BlogManager
    {
        PostRepository postRepository = new PostRepository();
        public List<Post> GetPost()
        {
            return postRepository.GetAllPost().ToList();
        }
        public Post GetPostByID(int id)
        {
            return postRepository.GetPostByID(id);
        }
        public void Insert(Post post)
        {
            postRepository.InsertPost(post);
        }
        public void Update(Post post)
        {
            postRepository.UpdatePost(post);
        }
        public void Delete(Post post)
        {
            postRepository.DeletePost(post);
        }
    }
}
