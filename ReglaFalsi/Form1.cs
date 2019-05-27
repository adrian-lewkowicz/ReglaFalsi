using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double fourPower;
        double threePower;
        double twoPower;
        double onePower;
        double C;
        double A;
        double B;
        double epsilon;
        double[] x = new double[100];
        double stala;
        private void StartButton_Click(object sender, EventArgs e)
        {
            initializeValues();
            if (FunkcjaOblicz(A)*FunkcjaOblicz(B)<0)
            {
                if(FunkcjaOblicz(A)<0 && FunkcjaOblicz(B)>0 && pochodnaDruga(B) > 0)
                {
                    x[0] = A;
                    stala = B;
                }
                else if (FunkcjaOblicz(A) < 0 && FunkcjaOblicz(B) > 0 && pochodnaDruga(A) < 0)
                {
                    x[0] = B;
                    stala = A;
                }
                else if (FunkcjaOblicz(A) > 0 && FunkcjaOblicz(B) < 0 && pochodnaDruga(A) > 0)
                {
                    x[0] = B;
                    stala = A;
                }
                else if (FunkcjaOblicz(A) > 0 && FunkcjaOblicz(B) > 0 && pochodnaDruga(B) < 0)
                {
                    x[0] = A;
                    stala = B;
                }
                int i = 0;
                do
                {
                    x[i + 1] = x[i] - ((stala - x[i]) * FunkcjaOblicz(x[i])) / (FunkcjaOblicz(stala) - FunkcjaOblicz(x[i]));
                    i++;
                } while (Math.Abs(x[i] - x[i - 1]) > epsilon);
                EqualsTextBox.Text = x[i].ToString();
            }
            else
            {
                MessageBox.Show("Nie poprawny przedział");
            }
        }
        double FunkcjaOblicz(double x)
        {
            double funckja = fourPower * Math.Pow(x, 4) + threePower * Math.Pow(x, 3) + twoPower * Math.Pow(x, 2) + onePower * Math.Pow(x, 1) + C;
            return funckja;
        }
        double pochodnaPierwsza(double x)
        {
            double pochodna = fourPower * 4 * Math.Pow(x, 3) + threePower * 3 * Math.Pow(x, 2) + twoPower * 2 * x + onePower;
            return pochodna;
        }
        double pochodnaDruga(double x)
        {
            return 4 * 3 * Math.Pow(x, 2) + 3 * 2 * x + twoPower;
        }
        void initializeValues()
        {
            A = (double)AnumericUpDown.Value;
            B = (double)BnumericUpDown.Value;
            fourPower = (double)fourPowernumericUpDown.Value;
            threePower = (double)ThreePowernumericUpDown.Value;
            twoPower = (double)TwonumericUpDown.Value;
            onePower = (double)PowernumericUpDown.Value;
            C = (double)CNumericUpDown.Value;
            epsilon = (double)EPSnumericUpDown.Value;
        }

    }
}
