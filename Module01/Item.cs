using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo
{

    [Serializable]
    public class Item
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }

        public Item()
        {
        }

        public Item(string title, string link, string desc, string pubDate)
        {
            Title = title;
            Link = link;
            Description = desc;
            PubDate = pubDate;
        }

        public override string ToString()
        {
            return "Title:  " + Title + "\nLink:  " +
                 Link + "\nDescription:  " +
                 Description + "\nPubDate:  " +
                 PubDate;
        }
    }
}
