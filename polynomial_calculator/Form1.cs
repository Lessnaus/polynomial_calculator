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
            // Pobierz łańcuchy znaków reprezentujące dwa wielomiany
            string poly1 = firstPolynominalText.Text.Trim();
            string poly2 = secondPolynominalText.Text.Trim();

            // Stwórz listę obiektów Term dla każdego wielomianu
            List<Term> terms1 = ParsePolynomial(poly1);
            List<Term> terms2 = ParsePolynomial(poly2);

            // Zsumuj wielomiany
            List<Term> result = AddPolynomials(terms1, terms2);

            // Konwertuj wynik na łańcuch i wyświetl go w kontrolce tekstowej
            string resultStr = ConvertPolynomialToString(result);



            resultLabel.Text = "Wynik: " + Environment.NewLine + resultStr;
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

        private void secondPolynominalText_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstPolynominalText_TextChanged(object sender, EventArgs e)
        {



        }

        private void resultLabel_Click(object sender, EventArgs e)
        {
            string result = resultLabel.Text;

            //serialize result to json
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("result.json", json);

            string fullPath = Path.GetFullPath("result.json");
            File.WriteAllText(fullPath, json);

            Console.WriteLine($"Zapisano plik {"result.json"} w {fullPath}");
            //deserialize json to object
            string jsonFromFile = File.ReadAllText("result.json");
            string resultFromFile = JsonConvert.DeserializeObject<string>(jsonFromFile);

            //display results in label2 
            label2.Text = resultFromFile;

        }

        private List<Term> ParsePolynomial(string polynomial)
        {
            List<Term> terms = new List<Term>();

            // Podziel wielomian na pojedyncze wyrazy
            string minus = polynomial.Substring(0, 1);
            string[] tokens = polynomial.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

            // Dla każdego wyrazu wykonaj następujące kroki:
            foreach (string token in tokens)
            {
                string termStr = token.Trim();

                // Sprawdź znak przed wyrazem (dodawanie lub odejmowanie)
                int sign = 1;
                if (termStr.StartsWith("-") || minus == "-")
                {
                    sign = -1;
                    //termStr = termStr.Substring(1);
                }
                else if (termStr.StartsWith(minus))
                {
                    termStr = termStr.Substring(1);
                }

                // Podziel wyraz na współczynnik i wykładnik
                int coef, exp;
                if (termStr.EndsWith("x"))
                {

                    if (termStr.Length > 1)
                        coef = int.Parse(termStr.Substring(0, termStr.Length - 1));
                    else
                        coef = 1;

                    exp = 1;
                }
                else if (termStr.Contains("x^"))
                {
                    string[] parts = termStr.Split(new string[] { "x^" }, StringSplitOptions.None);

                    if (parts[0] == "")
                    {
                        parts[0] = "1";
                    }

                    coef = int.Parse(parts[0]);
                    exp = int.Parse(parts[1]);
                }
                else
                {
                    coef = int.Parse(termStr);
                    exp = 0;
                }

                // Dodaj nowy wyraz do listy
                terms.Add(new Term(sign * coef, exp));
            }

            return terms;
        }

        private List<Term> AddPolynomials(List<Term> poly1, List<Term> poly2)
        {
            List<Term> result = new List<Term>();

            // Połącz obie listy, aby uzyskać wszystkie wyrazy
            List<Term> allTerms = poly1.Concat(poly2).ToList();

            // Zgrupuj wyrazy o tym samym wykładniku i dodaj ich współczynniki
            var groupedTerms = allTerms.GroupBy(t => t.Exponent);
            foreach (var group in groupedTerms)
            {
                int sum = group.Sum(t => t.Coefficient);
                if (sum != 0)
                {
                    result.Add(new Term(sum, group.Key));
                }
            }

            return result;
        }

        private string ConvertPolynomialToString(List<Term> polynomial)
        {
            // Sortuj wyrazy względem wykładnika malejąco
            polynomial = polynomial.OrderByDescending(t => t.Exponent).ToList();

            // Konwertuj wyrazy na łańcuchy znaków
            List<string> termStrings = polynomial.Select(t => t.ToString()).ToList();

            // Połącz łańcuchy znaków z wyrazami za pomocą znaku plus
            string result = string.Join(" + ", termStrings);

            // Jeśli wynik ma znak minus na początku, usuń go
            //if (result.StartsWith("-"))
            //{
            //    result = result.Substring(1);
            //}

            return result;
        }
    }

    public class Term
    {
        public int Coefficient { get; set; }
        public int Exponent { get; set; }

        public Term(int coef, int exp)
        {
            Coefficient = coef;
            Exponent = exp;
        }

        public override string ToString()
        {
            if (Coefficient == 0)
            {
                return "0";
            }

            string coefStr = (Coefficient > 0) ? Coefficient.ToString() : $"-{Math.Abs(Coefficient)}";
            string expStr = (Exponent == 0) ? "" : $"x^{Exponent}";

            return $"{coefStr}{expStr}";
        }
    }
}
