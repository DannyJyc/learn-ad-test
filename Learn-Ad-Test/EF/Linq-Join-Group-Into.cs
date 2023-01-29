using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_Ad_Test.EF
{
    internal class Linq_Join_Group_Into
    {
        public class blog
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
        public class blog_tag
        {
            public int Id { get; set; }
            public int Bid { get; set; }
            public int Tid { get; set; }
        }
        public class tag
        {
            public int Id { get; set; }
            public string Tname { get; set; }
        }
        public static void go()
        {
            var blogs = new List<blog>();
            blogs.Add(new blog { Id = 1, Title = "first" });
            var tags = new List<tag>();
            tags.Add(new tag { Id = 1, Tname = "tag1" });
            tags.Add(new tag { Id = 2, Tname = "tag2" });
            var blog_tag = new List<blog_tag>();
            blog_tag.Add(new blog_tag { Id = 1, Bid = 1, Tid = 1 });
            blog_tag.Add(new blog_tag { Id = 2, Bid = 1, Tid = 2 });
            var query1 = from b in blogs
                         join bt in blog_tag on b.Id equals bt.Bid
                         join t in tags on bt.Tid equals t.Id into ts
                         select new
                         {
                             id = b.Id,
                             t = ts.Any() ? ts.FirstOrDefault() : null
                         };
            Console.WriteLine(JsonConvert.SerializeObject(query1));

            var query2 = from q1 in query1
                         group q1 by q1.id into groupq1
                         select new
                         {
                             id = groupq1.Key,
                             t = groupq1.Select(p => p.t)
                         };
            Console.WriteLine(JsonConvert.SerializeObject(query2));
            Console.ReadKey();
        }
    }
}
