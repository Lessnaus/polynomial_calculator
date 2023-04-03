using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polynomial_calculator
{
    public partial class Form1 : Form
    {

        string poly1;
        string poly2;
        string result;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AdditionEvent(object sender, EventArgs e)
        {
            poly1 = firstPolynominalText.Text;
            poly2 = secondPolynominalText.Text;

            string[] poly1Terms = poly1.Split('+', '-');
            string[] poly2Terms = poly2.Split('+', '-');

            int[] poly1Coeffs = new int[poly1Terms.Length];
            int[] poly2Coeffs = new int[poly2Terms.Length];

            for (int i = 0; i < poly1Terms.Length; i++)
            {
                string term = poly1Terms[i].Trim();

                if (term == "") continue;

                int coef, exp;
                ParseTerm(term, out coef, out exp);

                if (poly1Terms[i][0] == '-')
                {
                    coef = -coef;
                }

                poly1Coeffs[exp] = coef;
            }

            for (int i = 0; i < poly2Terms.Length; i++)
            {
                string term = poly2Terms[i].Trim();

                if (term == "") continue;

                int coef, exp;
                ParseTerm(term, out coef, out exp);

                if (poly2Terms[i][0] == '-')
                {
                    coef = -coef;
                }

                poly2Coeffs[exp] = coef;
            }

            int[] resultCoeffs = new int[Math.Max(poly1Coeffs.Length, poly2Coeffs.Length)];

            for (int i = 0; i < resultCoeffs.Length; i++)
            {
                int coef1 = (i < poly1Coeffs.Length) ? poly1Coeffs[i] : 0;
                int coef2 = (i < poly2Coeffs.Length) ? poly2Coeffs[i] : 0;

                resultCoeffs[i] = coef1 + coef2;
            }

            for (int i = resultCoeffs.Length - 1; i >= 0; i--)
            {
                if (resultCoeffs[i] == 0) continue;

                if (resultCoeffs[i] > 0 && result != "")
                {
                    result += "+";
                }

                result += resultCoeffs[i].ToString();

                if (i > 0)
                {
                    result += "x";
                }

                if (i > 1)
                {
                    result += "^" + i.ToString();
                }
            }



            resultLabel.Text = "Wynik: " + Environment.NewLine + result;
        }

        private void SubtractionEvent(object sender, EventArgs e)
        {
            poly1 = firstPolynominalText.Text;
            poly2 = secondPolynominalText.Text;

            resultLabel.Text = "Wynik: " + Environment.NewLine + result;
        }

        private void MultiplycationEvent(object sender, EventArgs e)
        {
            poly1 = firstPolynominalText.Text;
            poly2 = secondPolynominalText.Text;

            resultLabel.Text = "Wynik: " + Environment.NewLine + result;
        }

        private void DivisionEvent(object sender, EventArgs e)
        {
            poly1 = firstPolynominalText.Text;
            poly2 = secondPolynominalText.Text;




            resultLabel.Text = "Wynik: " + Environment.NewLine + result;
        }
        private void Parse(string expression)
        {
            string[] terms = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string term in terms)
            {
                double coefficient;
                int exponent;
                if (double.TryParse(term.Trim(' ', '+', '-'), out coefficient))
                {
                    if (term.Contains('x'))
                    {
                        exponent = GetExponent(term);
                        if (coefficients.ContainsKey(exponent))
                        {
                            coefficients[exponent] += coefficient;
                        }
                        else
                        {
                            coefficients[exponent] = coefficient;
                        }
                    }
                    else
                    {
                        if (coefficients.ContainsKey(0))
                        {
                            coefficients[0] += coefficient;
                        }
                        else
                        {
                            coefficients[0] = coefficient;
                        }
                    }
                }
            }
        }
    }
}
