using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WPFDemo
{
    public static class ReadXML
    {
        public static List<Item> RX()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://habr.com/rss/interesting/");

            /*Создать коллекцию типа List<Item> и записать в нее данные из файла.*/
            List<Item> listItem = new List<Item>();
            foreach (XmlNode titleNode in xmlDoc.SelectNodes("//rss/channel/item"))
            {
                string t, l, p, d;

                t = titleNode.SelectSingleNode("title").InnerText;
                l = titleNode.SelectSingleNode("link").InnerText;
                p = titleNode.SelectSingleNode("pubDate").InnerText;
                d = titleNode.SelectSingleNode("description").InnerText;
                listItem.Add(new Item(t, l, d, p));
            }

            return listItem;
            //listItem.ForEach(Console.WriteLine);
        }

        public static void saveXmlFile()
        {
            List<Item> listItem = RX();

            //Сериализация.
            XmlSerializer formatter = new XmlSerializer(typeof(List<Item>));
            using (FileStream fs = new FileStream("Items.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, listItem);
            }
        }

        /*Прочитать содержимое XML файла со списком последних новостей по ссылке https://habrahabr.ru/rss/interesting/*/
        public static string ReadXMLNews()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://habr.com/rss/interesting/");
            XmlNodeList nodes1 = xmlDoc.SelectNodes("//rss/channel");
            StringBuilder s = new StringBuilder();
            foreach (XmlNode titleNode in nodes1)
                s.Append(titleNode.InnerText).Append("\n");
                //Console.WriteLine(titleNode.InnerText);
            return s.ToString();
        }

        /*a.	При нажатии на кнопку «Получить информацию», в соответствующие поля должна разместиться информация.*/
        public static List<string> fillFields()
        {
            List<string> l = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://habr.com/rss/interesting/");
            XmlNodeList t = xmlDoc.SelectNodes("//rss/channel/title");
            XmlNodeList d = xmlDoc.SelectNodes("//rss/channel/description");
            XmlNodeList p = xmlDoc.SelectNodes("//rss/channel/managingEditor");
            XmlNodeList q = xmlDoc.SelectNodes("//rss/channel/generator");
            XmlNodeList w = xmlDoc.SelectNodes("//rss/channel/pubDate");

            foreach (XmlNode node in t)
                l.Add(node.InnerText);
            foreach (XmlNode node in p)
                l.Add(node.InnerText);
            foreach (XmlNode node in d)
                l.Add(node.InnerText);
            foreach (XmlNode node in q)
                l.Add(node.InnerText);
            foreach (XmlNode node in w)
                l.Add(node.InnerText);


            return l;
        }

        /*b.	Так же при нажатии на кнопку «Получить информацию», должно быть выведено количество новостей.*/
        public static string cntOfNews()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://habr.com/rss/interesting/");
            int cnt = 0;
            foreach (XmlNode titleNode in xmlDoc.SelectNodes("//rss/channel/item"))
            {
                if (titleNode.Name == "item")
                    ++cnt;
            }

            return cnt.ToString();
        }
    }
}
