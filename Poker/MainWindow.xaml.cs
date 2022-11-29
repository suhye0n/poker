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
        public static int[] arr1 = new int[5];
        public static int[] arr2 = new int[5];
        public static int cnt1 = 0;
        public static int cnt2 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDeal(object sender, RoutedEventArgs e)
        {
            cnt1 = 0;
            cnt2 = 0;

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

            Array.Sort(arr1);
            Array.Sort(arr2);

            if (arr1[0] == arr1[1] && arr1[1] == arr1[2] && arr1[2] == arr1[3] && arr1[3] == arr1[4])
            {
                if (arr2[0] + arr2[1] + arr2[2] + arr2[3] + arr2[4] == 15)
                {
                    L1.Content = "백 스트레이트 플러시";
                }
                else if (arr2[0] + arr2[1] + arr2[2] + arr2[3] + arr2[4] == 47)
                {
                    L1.Content = "로열 스트레이트 플러시";
                }
                else if (arr2[0] + 1 == arr2[1] && arr2[1] + 1 == arr2[2] && arr2[2] + 1 == arr2[3] && arr2[3] + 1 == arr2[4])
                {
                    L1.Content = "스트레이트 플러시";
                }
                else
                {
                    L1.Content = " 플러시";
                }

            }
            else if (arr2[0] == arr2[1] && arr2[1] == arr2[2] && arr2[2] == arr2[3]) //4
            {
                L1.Content = "포 카드";
            }
            else if (arr2[1] == arr2[2] && arr2[2] == arr2[3] && arr2[3] == arr2[4]) //0
            {
                L1.Content = "포 카드";
            }
            else if (arr2[0] == arr2[2] && arr2[2] == arr2[3] && arr2[3] == arr2[4]) //1
            {
                L1.Content = "포 카드";
            }
            else if (arr2[0] == arr2[1] && arr2[1] == arr2[3] && arr2[3] == arr2[4]) //2
            {
                L1.Content = "포 카드";
            }
            else if (arr2[0] == arr2[1] && arr2[1] == arr2[2] && arr2[2] == arr2[4]) //3
            {
                L1.Content = "포 카드";
            }
            else if (arr2[0] == arr2[1] && arr2[2] == arr2[3] && arr2[3] == arr2[4]) //01 234
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[0] == arr2[2] && arr2[1] == arr2[3] && arr2[3] == arr2[4]) //02 134
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[0] == arr2[3] && arr2[1] == arr2[2] && arr2[2] == arr2[4]) //03 124
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[0] == arr2[4] && arr2[1] == arr2[2] && arr2[2] == arr2[3]) //04 123
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[1] == arr2[2] && arr2[0] == arr2[3] && arr2[3] == arr2[4]) //12 034
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[1] == arr2[3] && arr2[0] == arr2[2] && arr2[2] == arr2[4]) //13 024
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[1] == arr2[4] && arr2[0] == arr2[2] && arr2[2] == arr2[3]) //14 023
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[2] == arr2[3] && arr2[0] == arr2[1] && arr2[1] == arr2[4]) //23 014
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[2] == arr2[4] && arr2[0] == arr2[1] && arr2[1] == arr2[3]) //24 013
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[3] == arr2[4] && arr2[0] == arr2[1] && arr2[1] == arr2[2]) //34 012
            {
                L1.Content = "풀 하우스";
            }
            else if (arr2[0] + arr2[1] + arr2[2] + arr2[3] + arr2[4] == 47)
            {
                L1.Content = "마운틴";
            }
            else if (arr2[0] + arr2[1] + arr2[2] + arr2[3] + arr2[4] == 15)
            {
                L1.Content = "백 스트레이트";
            }
            else if (arr2[0] + 1 == arr2[1] && arr2[1] + 1 == arr2[2] && arr2[2] + 1 == arr2[3] && arr2[3] + 1 == arr2[4])
            {
                L1.Content = "스트레이트";
            }
            else if (arr2[2] == arr2[3] && arr2[3] == arr2[4]) //234
            {
                L1.Content = "트리플";
            }
            else if (arr2[1] == arr2[3] && arr2[3] == arr2[4]) //134
            {
                L1.Content = "트리플";
            }
            else if (arr2[1] == arr2[2] && arr2[2] == arr2[4]) //124
            {
                L1.Content = "트리플";
            }
            else if (arr2[1] == arr2[2] && arr2[2] == arr2[3]) //123
            {
                L1.Content = "트리플";
            }
            else if (arr2[0] == arr2[3] && arr2[3] == arr2[4]) //034
            {
                L1.Content = "트리플";
            }
            else if (arr2[0] == arr2[2] && arr2[2] == arr2[4]) //024
            {
                L1.Content = "트리플";
            }
            else if (arr2[0] == arr2[2] && arr2[2] == arr2[3]) //023
            {
                L1.Content = "트리플";
            }
            else if (arr2[0] == arr2[1] && arr2[1] == arr2[4]) //014
            {
                L1.Content = "트리플";
            }
            else if (arr2[0] == arr2[1] && arr2[1] == arr2[3]) //013
            {
                L1.Content = "트리플";
            }
            else if (arr2[0] == arr2[1] && arr2[1] == arr2[2]) //012
            {
                L1.Content = "트리플";
            }
            else if (arr2[0] == arr2[1]) //01
            {
                L1.Content = "원 페어";
            }
            else if (arr2[0] == arr2[2]) //02
            {
                L1.Content = "원 페어";
            }
            else if (arr2[0] == arr2[3]) //03
            {
                L1.Content = "원 페어";
            }
            else if (arr2[0] == arr2[4]) //04
            {
                L1.Content = "원 페어";
            }
            else if (arr2[1] == arr2[2]) //12
            {
                L1.Content = "원 페어";
            }
            else if (arr2[1] == arr2[3]) //13
            {
                L1.Content = "원 페어";
            }
            else if (arr2[1] == arr2[4]) //14
            {
                L1.Content = "원 페어";
            }
            else if (arr2[2] == arr2[3]) //23
            {
                L1.Content = "원 페어";
            }
            else if (arr2[2] == arr2[4]) //24
            {
                L1.Content = "원 페어";
            }
            else if (arr2[3] == arr2[4]) //34
            {
                L1.Content = "원 페어";
            }
            else if (arr2[0] == arr2[1] && arr2[2] == arr2[3]) // 01 23
            {
                L1.Content = "투 페어";
            }
            else if (arr2[0] == arr2[1] && arr2[2] == arr2[4]) // 01 24
            {
                L1.Content = "투 페어";
            }
            else if (arr2[0] == arr2[2] && arr2[1] == arr2[3]) // 02 13
            {
                L1.Content = "투 페어";
            }
            else if (arr2[0] == arr2[2] && arr2[1] == arr2[4]) // 02 14
            {
                L1.Content = "투 페어";
            }
            else if (arr2[0] == arr2[3] && arr2[2] == arr2[1]) // 03 12
            {
                L1.Content = "투 페어";
            }
            else if (arr2[0] == arr2[3] && arr2[1] == arr2[4]) // 03 14
            {
                L1.Content = "투 페어";
            }
            else if (arr2[0] == arr2[4] && arr2[2] == arr2[1]) // 04 12
            {
                L1.Content = "투 페어";
            }
            else if (arr2[0] == arr2[4] && arr2[1] == arr2[3]) // 04 13
            {
                L1.Content = "투 페어";
            }
            else if (arr2[2] == arr2[1] && arr2[4] == arr2[3]) // 12 34
            {
                L1.Content = "투 페어";
            }
            else if (arr2[3] == arr2[1] && arr2[2] == arr2[4]) // 13 24
            {
                L1.Content = "투 페어";
            }
            else if (arr2[4] == arr2[1] && arr2[2] == arr2[3]) // 14 23
            {
                L1.Content = "투 페어";
            }
            else
            {
                L1.Content = "탑";
            }
        }

        private string GetCardName(int c)
        {
            string shape = "";
            switch (c / 13)
            {
                case 0: shape = "spades"; arr1[cnt1] = 0; cnt1+=1; break;
                case 1: shape = "diamonds"; arr1[cnt1] = 1; cnt1 += 1; break;
                case 2: shape = "hearts"; arr1[cnt1] = 2; cnt1 += 1; break;
                case 3: shape = "clubs"; arr1[cnt1] = 3; cnt1 += 1; break;
            }

            string number = "";
            switch (c % 13)
            {
                case 0: number = "ace"; arr2[cnt2] = 0; cnt2 += 1; break;
                case int n when (n > 0 && n < 10):
                    number = (c % 13 + 1).ToString(); arr2[cnt2] = n; cnt2 += 1; break;
                case 10: number = "jack"; arr2[cnt2] = 10; cnt2 += 1; shape += "2"; break;
                case 11: number = "queen"; arr2[cnt2] = 11; cnt2 += 1; shape += "2"; break;
                case 12: number = "king"; arr2[cnt2] = 12; cnt2 += 1; shape += "2"; break;
            }

            return string.Format("{0}_of_{1}.png", number, shape);
        }
    }
}
