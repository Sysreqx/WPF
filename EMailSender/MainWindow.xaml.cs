using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
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
using EMailSender.Model;

namespace EMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sndMSG(object sender, RoutedEventArgs e)
        {
            string message = "";
            if (MSGSender.SendMail("gersen.e.a@gmail.com", Recipient.Text, cc.Text, bcc.Text, Subject.Text, text.Text, out message))
            {
                lblMessage.Foreground = new SolidColorBrush(Colors.Green);
                lblMessage.Content = message;
            }
            else
            {
                lblMessage.Foreground = new SolidColorBrush(Colors.Red);
                lblMessage.Content = message;
            }
        }
    }
}
