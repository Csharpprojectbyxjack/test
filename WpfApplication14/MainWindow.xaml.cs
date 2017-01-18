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

namespace WpfApplication14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool BlockButtons = false;
        char BtnNum = '1';

        Brush b;

        char PoprawnyBtn = '0';

        int poprawne = 0;
        int nie_poprawne = 0;

        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        //komentarzr
        private void OnTimedEvent(object sender, EventArgs e)
        {
            this.btn1.Background = b;
            this.btn2.Background = b;
            this.btn3.Background = b;
            this.btn4.Background = b;
            this.btn5.Background = b;
            this.btn6.Background = b;
            this.btn7.Background = b;
            this.btn8.Background = b;
            this.btn9.Background = b;

            this.BlockButtons = false;

            Timer.Stop();

            this.RegenerateNumbers();
        }

        public void RegenerateNumbers()
        {
            Random rnd = new Random();

            int LA = rnd.Next(10);
            int LB = rnd.Next(10);
            int LC, LS, LX, Zebrane = 0, WYNIK = LA * LB;

            LabQuery.Content = LA.ToString() + 'x' + LB.ToString();

            int[] liczby = new int[9];

            int powtozenia = 0;

            while (Zebrane != 9)
            {
                LS = rnd.Next(2);
                LC = rnd.Next(10);
                LX = 0;

                if (LS == 0) LX = LA;
                if (LS == 1) LX = LB;

                powtozenia++;
                if (powtozenia > 100000) break;

                if ((LX * LC) == WYNIK) continue;

                bool powtoz = false;

                for (int i = 0; i < Zebrane; i++)
                {
                    if (liczby[i] == (LX * LC))
                    {
                        powtoz = true;
                        break;
                    }
                }

                if (powtoz) continue;

                liczby[Zebrane] = LX * LC;

                Zebrane++;
            }

            LC = rnd.Next(0, 9);

            liczby[LC] = WYNIK;

            this.PoprawnyBtn = (LC + 1).ToString()[0];

            this.btn1.Content = liczby[0].ToString();
            this.btn2.Content = liczby[1].ToString();
            this.btn3.Content = liczby[2].ToString();
            this.btn4.Content = liczby[3].ToString();
            this.btn5.Content = liczby[4].ToString();
            this.btn6.Content = liczby[5].ToString();
            this.btn7.Content = liczby[6].ToString();
            this.btn8.Content = liczby[7].ToString();
            this.btn9.Content = liczby[8].ToString();
        }

        public void RefreshScore()
        {
            this.LabGood.Content = this.poprawne.ToString();
            this.LabBad.Content = this.nie_poprawne.ToString();
        }


        public MainWindow()
        {
            InitializeComponent();
            b = (Brush)this.FindResource("NormalButtonBG");

            this.RegenerateNumbers();
            this.RefreshScore();

        }

        private void BtnClickAction(char BtnNumber)
        {
            if (this.BlockButtons) return;

            if (this.PoprawnyBtn == BtnNumber)
            {
                if (BtnNumber == '1') this.btn1.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '2') this.btn2.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '3') this.btn3.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '4') this.btn4.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '5') this.btn5.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '6') this.btn6.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '7') this.btn7.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '8') this.btn8.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '9') this.btn9.Background = (Brush)this.FindResource("GoodButtonBG");

                this.poprawne++;
            }
            else
            {
                if (this.PoprawnyBtn == '1') this.btn1.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '2') this.btn2.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '3') this.btn3.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '4') this.btn4.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '5') this.btn5.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '6') this.btn6.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '7') this.btn7.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '8') this.btn8.Background = (Brush)this.FindResource("BadButtonBG");
                if (this.PoprawnyBtn == '9') this.btn9.Background = (Brush)this.FindResource("BadButtonBG");

                if (BtnNumber == '1') this.btn1.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '2') this.btn2.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '3') this.btn3.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '4') this.btn4.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '5') this.btn5.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '6') this.btn6.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '7') this.btn7.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '8') this.btn8.Background = (Brush)this.FindResource("GoodButtonBG");
                if (BtnNumber == '9') this.btn9.Background = (Brush)this.FindResource("GoodButtonBG");

                this.nie_poprawne++;
            }

            this.BtnNum = BtnNumber;

            Timer.Tick += OnTimedEvent;
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 600);
            Timer.Start();

            this.RefreshScore();

            this.BlockButtons = true;
        }


        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('1');
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('2');
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('3');
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('4');
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('5');
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('6');
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('7');
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('8');
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            this.BtnClickAction('9');
        }

        private void rezize_Buttons()
        {
            btn1.Width = wpf.Width / 3;
            btn2.Width = wpf.Width / 3;
            btn3.Width = wpf.Width / 3;
            btn4.Width = wpf.Width / 3;
            btn5.Width = wpf.Width / 3;
            btn6.Width = wpf.Width / 3;
            btn7.Width = wpf.Width / 3;
            btn8.Width = wpf.Width / 3;
            btn9.Width = wpf.Width / 3;
        }

        private void zmien_rozmiar(object sender, SizeChangedEventArgs e)
        {
            rezize_Buttons();
        }
        // komentarz
        private void zmien_rozmiar2(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                wpf.Width = System.Windows.SystemParameters.PrimaryScreenWidth - 10;
            }

            if (this.WindowState == WindowState.Minimized)
            {
                wpf.Width = 600;
            }

            if (this.WindowState == WindowState.Normal)
            {
                wpf.Width = 600;
            }

            rezize_Buttons();
        }
    }
}
