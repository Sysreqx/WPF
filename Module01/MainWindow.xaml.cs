using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (File.Exists(@"C:\Users\SysRq\source\repos\Module 01\WPFDemo\bin\Debug\Items.xml"))
            {
                File.Delete(@"C:\Users\SysRq\source\repos\Module 01\WPFDemo\bin\Debug\Items.xml");
            }
            List<Item> items = new List<Item>();
            InitializeComponent();
            items = ReadXML.RX();
        }

        private void FetchInfo(object sender, RoutedEventArgs e)
        {
            List<string> l = ReadXML.fillFields();
            lblDesc.Content = l[1];
            lblTitle.Content = l[0];
            lblMNGEditor.Content = l[2];
            lblGenerator.Content = l[3];
            lblPubDate.Content = l[4];
            numberOfNews.Content = "Количество новостей: " + ReadXML.cntOfNews();
        }

        private void SaveXmlFileBTN(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadXML.saveXmlFile();
            }
            catch (Exception z)
            {
                lblException.Content = z;
                lblException.Foreground = Brushes.Red;
            }
            finally
            {
                lblException.Content = "Xml File created";
                lblException.Foreground = Brushes.Green;
                hyperlinkk.IsEnabled = true;
            }
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            var appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            System.Diagnostics.Process.Start(appPath + "Items.xml");
            tbFileContainer.Text = "Open XML";
            
            //lblException.tex = "XML file link";
        }
    }
}
