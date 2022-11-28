using System;
using System.Collections.Generic;
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

namespace Poker
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

        private void OnDeal(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int[] num = new int[5];

            for (int i = 0; i < num.Length; i++)
            {
                int n = 0;
                do
                {
                    n = r.Next(52);
                } while (num.Contains(n));
                //} while (Array.IndexOf(num, n) > -1);
                num[i] = n;
            }

            Array.Sort(num);

            BitmapImage[] b = new BitmapImage[num.Length];

            for (int i = 0; i < num.Length; i++)
                b[i] = new BitmapImage(new Uri($"images/{GetCardName(num[i])}",
                    UriKind.RelativeOrAbsolute));

            Card1.Source = b[0];
            Card2.Source = b[1];
            Card3.Source = b[2];
            Card4.Source = b[3];
            Card5.Source = b[4];
        }

        private string GetCardName(int c)
        {
            string shape = "";
            switch (c / 13)
            {
                case 0: shape = "spades"; break;
                case 1: shape = "diamonds"; break;
                case 2: shape = "hearts"; break;
                case 3: shape = "clubs"; break;
            }

            string number = "";
            switch (c % 13)
            {
                case 0: number = "ace"; break;
                case int n when (n > 0 && n < 10):
                    number = (c % 13 + 1).ToString(); break;
                case 10: number = "jack"; shape += "2"; break;
                case 11: number = "queen"; shape += "2"; break;
                case 12: number = "king"; shape += "2"; break;
            }
            return string.Format("{0}_of_{1}.png", number, shape);
        }
    }
}
