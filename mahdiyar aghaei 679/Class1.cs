using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahdiyar_aghaei_679
{
    internal class post { 
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set;}
        public int useId { get; set; }

        StreamWriter writer = new StreamWriter("user.txt");
foreach(var postList in posts)
{
    if (postList.userId % 2 != 0)
    {
        writer.WriteLine($"user id : {postList.userId}, Title: {postList.title}");
    }
}
writer.Close();
