using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.RegularExpressions;
using ExtendedArithmetic;

namespace polynomial_calculator
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AdditionEvent(object sender, EventArgs e)
        {
            // Pobierz łańcuchy znaków reprezentujące dwa wielomiany


            string wielomian1 = firstPolynominalText.Text;
            string outputString1 = "";

            for (int i = 0; i < wielomian1.Length; i++)
            {
                if (wielomian1[i] == 'x')
                {
                    outputString1 += "*x";
                }
                else if (wielomian1[i] == '-' && (i == 0 || wielomian1[i - 1] == '+'))
                {
                    outputString1 += "-1";
                }
                else if (wielomian1[i] == '+' || wielomian1[i] == '-')
                {
                    outputString1 += wielomian1[i];
                }
                else
                {
                    outputString1 += wielomian1[i];
                }
            }
            string wielomian2 = secondPolynominalText.Text;
            string outputString2 = "";

            for (int i = 0; i < wielomian2.Length; i++)
            {
                if (wielomian2[i] == 'x')
                {
                    outputString2 += "*x";
                }
                else if (wielomian2[i] == '-' && (i == 0 || wielomian2[i - 1] == '+'))
                {
                    outputString2 += "-1";
                }
                else if (wielomian2[i] == '+' || wielomian2[i] == '-')
                {
                    outputString2 += wielomian2[i];
                }
                else
                {
                    outputString2 += wielomian2[i];
                }
            }
            ExtendedArithmetic.Polynomial asd = Polynomial.Parse(outputString1);
            ExtendedArithmetic.Polynomial assd = Polynomial.Parse(outputString2);

            Polynomial wynik = ExtendedArithmetic.Polynomial.Add(asd, assd);
            String qwe = wynik.ToString();

            resultLabel.Text = "Wynik: " + qwe;

            string znak = "+";
            saveResult(wielomian1, znak, wielomian2, qwe);
        }

        private void SubtractionEvent(object sender, EventArgs e)
        {
            // Pobierz łańcuchy znaków reprezentujące dwa wielomiany


            string wielomian1 = firstPolynominalText.Text;
            string outputString1 = "";

            for (int i = 0; i < wielomian1.Length; i++)
            {
                if (wielomian1[i] == 'x')
                {
                    outputString1 += "*x";
                }
                else if (wielomian1[i] == '-' && (i == 0 || wielomian1[i - 1] == '+'))
                {
                    outputString1 += "-1";
                }
                else if (wielomian1[i] == '+' || wielomian1[i] == '-')
                {
                    outputString1 += wielomian1[i];
                }
                else
                {
                    outputString1 += wielomian1[i];
                }
            }
            string wielomian2 = secondPolynominalText.Text;
            string outputString2 = "";

            for (int i = 0; i < wielomian2.Length; i++)
            {
                if (wielomian2[i] == 'x')
                {
                    outputString2 += "*x";
                }
                else if (wielomian2[i] == '-' && (i == 0 || wielomian2[i - 1] == '+'))
                {
                    outputString2 += "-1";
                }
                else if (wielomian2[i] == '+' || wielomian2[i] == '-')
                {
                    outputString2 += wielomian2[i];
                }
                else
                {
                    outputString2 += wielomian2[i];
                }
            }
            ExtendedArithmetic.Polynomial asd = Polynomial.Parse(outputString1);
            ExtendedArithmetic.Polynomial assd = Polynomial.Parse(outputString2);

            Polynomial wynik = ExtendedArithmetic.Polynomial.Subtract(asd, assd);
            String qwe = wynik.ToString();

            resultLabel.Text = "Wynik: " + qwe;
            string znak = "-";
            saveResult(wielomian1, znak, wielomian2, qwe);
        }

        private void MultiplycationEvent(object sender, EventArgs e)
        {
            // Pobierz łańcuchy znaków reprezentujące dwa wielomiany


            string wielomian1 = firstPolynominalText.Text;
            string outputString1 = "";

            for (int i = 0; i < wielomian1.Length; i++)
            {
                if (wielomian1[i] == 'x')
                {
                    outputString1 += "*x";
                }
                else if (wielomian1[i] == '-' && (i == 0 || wielomian1[i - 1] == '+'))
                {
                    outputString1 += "-1";
                }
                else if (wielomian1[i] == '+' || wielomian1[i] == '-')
                {
                    outputString1 += wielomian1[i];
                }
                else
                {
                    outputString1 += wielomian1[i];
                }
            }
            string wielomian2 = secondPolynominalText.Text;
            string outputString2 = "";

            for (int i = 0; i < wielomian2.Length; i++)
            {
                if (wielomian2[i] == 'x')
                {
                    outputString2 += "*x";
                }
                else if (wielomian2[i] == '-' && (i == 0 || wielomian2[i - 1] == '+'))
                {
                    outputString2 += "-1";
                }
                else if (wielomian2[i] == '+' || wielomian2[i] == '-')
                {
                    outputString2 += wielomian2[i];
                }
                else
                {
                    outputString2 += wielomian2[i];
                }
            }
            ExtendedArithmetic.Polynomial asd = Polynomial.Parse(outputString1);
            ExtendedArithmetic.Polynomial assd = Polynomial.Parse(outputString2);

            Polynomial wynik = ExtendedArithmetic.Polynomial.Multiply(asd, assd);
            String qwe = wynik.ToString();

            resultLabel.Text = "Wynik: " + qwe;
            string znak = "*";
            saveResult(wielomian1, znak, wielomian2, qwe);
        }

        private void DivisionEvent(object sender, EventArgs e)
        {// Pobierz łańcuchy znaków reprezentujące dwa wielomiany


            string wielomian1 = firstPolynominalText.Text;
            string outputString1 = "";

            for (int i = 0; i < wielomian1.Length; i++)
            {
                if (wielomian1[i] == 'x')
                {
                    outputString1 += "*x";
                }
                else if (wielomian1[i] == '-' && (i == 0 || wielomian1[i - 1] == '+'))
                {
                    outputString1 += "-1";
                }
                else if (wielomian1[i] == '+' || wielomian1[i] == '-')
                {
                    outputString1 += wielomian1[i];
                }
                else
                {
                    outputString1 += wielomian1[i];
                }
            }
            string wielomian2 = secondPolynominalText.Text;
            string outputString2 = "";

            for (int i = 0; i < wielomian2.Length; i++)
            {
                if (wielomian2[i] == 'x')
                {
                    outputString2 += "*x";
                }
                else if (wielomian2[i] == '-' && (i == 0 || wielomian2[i - 1] == '+'))
                {
                    outputString2 += "-1";
                }
                else if (wielomian2[i] == '+' || wielomian2[i] == '-')
                {
                    outputString2 += wielomian2[i];
                }
                else
                {
                    outputString2 += wielomian2[i];
                }
            }
            ExtendedArithmetic.Polynomial asd = Polynomial.Parse(outputString1);
            ExtendedArithmetic.Polynomial assd = Polynomial.Parse(outputString2);

            Polynomial wynik = ExtendedArithmetic.Polynomial.Divide(asd, assd);
            String qwe = wynik.ToString();

            resultLabel.Text = "Wynik: " + qwe;
            string znak = "/";
            saveResult(wielomian1, znak ,wielomian2, qwe);
        }

        private void secondPolynominalText_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstPolynominalText_TextChanged(object sender, EventArgs e)
        {



        }

        private void saveResult(string wielomian1,string znak, string wielomian2, string result) 
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result.txt");
            string fullPath = Path.GetFullPath("result.txt");
            Console.WriteLine($"Zapisano plik {"result.txt"} w {fullPath}");

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(wielomian1+" "+znak+" "+wielomian2+" = "+ result);
            }
            //display the last 5 lines of the file result.txt in label2
            string[] lines = File.ReadAllLines(filePath);
            int count = lines.Length;
            if (count > 5)
            {
                for (int i = count - 5; i < count; i++)
                {
                    label2.Text += lines[i] + Environment.NewLine;
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    label2.Text += lines[i] + Environment.NewLine;
                }
            }

        }
    }


}






