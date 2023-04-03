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
            poly1 = firstPolynominalText.Text;
            poly2 = secondPolynominalText.Text;
            //todo: odczytać wielomiany 
            //      dodać je
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
    }
}
