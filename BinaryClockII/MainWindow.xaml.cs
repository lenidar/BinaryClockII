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
using System.Windows.Threading;

namespace BinaryClockII
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[][] displayArr = new TextBox[13][];
        private string[] dTime = new string[6];
        private DispatcherTimer dt = new DispatcherTimer();
        private DispatcherTimer animation = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            // Hours
            displayArr[0] = new TextBox[] { txtBH00, txtBH01 };
            displayArr[1] = new TextBox[] { txtBH10, txtBH11, txtBH12, txtBH13 };
            // Mins
            displayArr[2] = new TextBox[] { txtBM00, txtBM01, txtBM02 };
            displayArr[3] = new TextBox[] { txtBM10, txtBM11, txtBM12, txtBM13 };
            // Secs
            displayArr[4] = new TextBox[] { txtBS00, txtBS01, txtBS02 };
            displayArr[5] = new TextBox[] { txtBS10, txtBS11, txtBS12, txtBS13 };
            // Day
            displayArr[6] = new TextBox[] { txtBD00, txtBD01 };
            displayArr[7] = new TextBox[] { txtBD10, txtBD11, txtBD12, txtBD13 };
            //Month
            displayArr[8] = new TextBox[] { txtBm10, txtBm11, txtBm12, txtBm13 };
            //Year
            displayArr[9] = new TextBox[] { txtBY10, txtBY11, txtBY12, txtBY13 };
            displayArr[10] = new TextBox[] { txtBY20, txtBY21, txtBY22, txtBY23 };
            displayArr[11] = new TextBox[] { txtBY30, txtBY31, txtBY32, txtBY33 };
            displayArr[12] = new TextBox[] { txtBY40, txtBY41, txtBY42, txtBY43 };


            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += Dt_Tick;

            animation.Interval = new TimeSpan(0, 0, 0, 0, 500);
            animation.Tick += Animation_Tick; 

            animation.Start();

            dt.Start();
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            if(lblC1.IsVisible)
            {
                lblC1.Visibility = Visibility.Hidden;
                lblC2.Visibility = Visibility.Hidden;
                lblC3.Visibility = Visibility.Hidden;
                lblC4.Visibility = Visibility.Hidden;
            }
            else
            {
                lblC1.Visibility = Visibility.Visible;
                lblC2.Visibility = Visibility.Visible;
                lblC3.Visibility = Visibility.Visible;
                lblC4.Visibility = Visibility.Visible;
            }
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            dTime[0] = formatLeadingZero(DateTime.Now.Hour.ToString());
            dTime[1] = formatLeadingZero(DateTime.Now.Minute.ToString());
            dTime[2] = formatLeadingZero(DateTime.Now.Second.ToString());
            dTime[3] = formatLeadingZero(DateTime.Now.Day.ToString());
            dTime[4] = formatLeadingZero(DateTime.Now.Month.ToString());
            dTime[5] = formatLeadingZero(DateTime.Now.Year.ToString());

            updateDisplay(binaryConvert(int.Parse(dTime[0][0].ToString())), displayArr[0]);
            lblH1.Content = dTime[0][0].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[0][1].ToString())), displayArr[1]);
            lblH2.Content = dTime[0][1].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[1][0].ToString())), displayArr[2]);
            lblM1.Content = dTime[1][0].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[1][1].ToString())), displayArr[3]);
            lblM2.Content = dTime[1][1].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[2][0].ToString())), displayArr[4]);
            lblS1.Content = dTime[2][0].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[2][1].ToString())), displayArr[5]);
            lblS2.Content = dTime[2][1].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[3][0].ToString())), displayArr[6]);
            lblD1.Content = dTime[3][0].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[3][1].ToString())), displayArr[7]);
            lblD2.Content = dTime[3][1].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[4])), displayArr[8]);
            lblM.Content = dTime[4].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[5][0].ToString())), displayArr[9]);
            lblY1.Content = dTime[5][0].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[5][1].ToString())), displayArr[10]);
            lblY2.Content = dTime[5][1].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[5][2].ToString())), displayArr[11]);
            lblY3.Content = dTime[5][2].ToString();
            updateDisplay(binaryConvert(int.Parse(dTime[5][3].ToString())), displayArr[12]);
            lblY4.Content = dTime[5][3].ToString();
        }

        public string formatLeadingZero(string number)
        {
            if (number.Length == 1)
            {
                number = "0" + number;
            }
            return number;
        }

        private bool[] binaryConvert(int num)
        {
            bool[] bit4 = new bool[] { false, false, false, false };

            if(num >= 8)
            {
                bit4[3] = true;
                num -= 8;
            }
            if(num >= 4)
            {
                bit4[2] = true;
                num -= 4;
            }
            if(num >= 2)
            {
                bit4[1] = true;
                num -= 2;
            }
            if(num >= 1)
            {
                bit4[0] = true;
                num--;
            }

            return bit4;
        }

        private void updateDisplay(bool[] binary, TextBox[] display)
        {
            for(int x = 0; x < display.Length; x++)
            {
                if (binary[x])
                    display[x].Text = "X";
                else
                    display[x].Text = "O";
            }
        }
    }
}
