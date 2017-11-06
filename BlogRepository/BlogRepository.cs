using BlogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogRepository
{
    public class PostRepository
    {
        static List<Post> Posts = new List<Post>
        {
            new Post(){
                ID=1,
                Title="文章1",
                Content="我是文章1的内容",
                CreateDate=DateTime.Now,
                ModifyDate=DateTime.Now,
                Author="小神",
            },
            new Post(){
                ID=2,
                Title="文章2",
                Content="我是文章2的内容",
                CreateDate=DateTime.Now,
                ModifyDate=DateTime.Now,
                Author="小神",
            },            new Post(){
                ID=3,
                Title="文章3",
                Content="我是文章3的内容",
                CreateDate=DateTime.Now,
                ModifyDate=DateTime.Now,
                Author="小神",
            },            new Post(){
                ID=4,
                Title="文章4",
                Content="我是文章4的内容",
                CreateDate=DateTime.Now,
                ModifyDate=DateTime.Now,
                Author="小神",
            },            new Post(){
                ID=5,
                Title="文章5",
                Content="我是文章5的内容",
                CreateDate=DateTime.Now,
                ModifyDate=DateTime.Now,
                Author="小神",
            },
        };
        BlogContext blogContext = new BlogContext();
        public IEnumerable<Post> GetAllPost()
        {
            return blogContext.Post;
        }
        public Post GetPostByID(int id)
        {
            return blogContext.Post.FirstOrDefault(i => i.ID == id);
        }
        public void InsertPost(Post post)
        {
            blogContext.Post.Add(post);
            blogContext.SaveChanges();
        }
        public void UpdatePost(Post post)
        {
            blogContext.Entry<Post>(post).State = System.Data.Entity.EntityState.Modified;
            blogContext.SaveChanges();
        }
        public void DeletePost(Post post)
        {
            blogContext.Post.Remove(post);
            blogContext.SaveChanges();
        }
    }
}
