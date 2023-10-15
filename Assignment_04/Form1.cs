using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Dictionary<string,string> history;
        Evaluator evaluator;
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = inputText;
            inputText.Focus();
            history = new Dictionary<string,string>();
            evaluator = new Evaluator();
        }

        private void undobtn_Click(object sender, EventArgs e)
        {
            inputText.Text = inputText.Text.Substring(0, inputText.Text.Length - 1);
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            inputText.Text = "";
        }

        private void historyText_TextChanged(object sender, EventArgs e)
        {
            //foreach(var kvp in history)
            //{
            //    historyText.Text = $"Input: {kvp.Key}\nOutput: {kvp.Value}";
            //}
            historyText.ScrollBars = ScrollBars.Vertical;
        } 

        private void inputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void dotbtn_Click(object sender, EventArgs e)
        {
            inputText.Text += ".";
        }

        private void one_Click(object sender, EventArgs e)
        {
            inputText.Text += "1";
        }

        private void two_Click(object sender, EventArgs e)
        {
            inputText.Text += "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            inputText.Text += "3";
        }

        private void four_Click(object sender, EventArgs e)
        {
            inputText.Text += "4";

        }

        private void five_Click(object sender, EventArgs e)
        {
            inputText.Text += "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            inputText.Text += "6";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            inputText.Text += "7"; 
        }

        private void eight_Click(object sender, EventArgs e)
        {
            inputText.Text += "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            inputText.Text += "9";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            inputText.Text += "0";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            outputText.Text = evaluator.stringSolve(inputText.Text);
            historyText.Text += $"\nInput: {inputText.Text} \n";
            historyText.Text += $"\nOutput: {outputText.Text} \n";
            inputText.Text = "";
        }

        private void plus_Click(object sender, EventArgs e)
        {
            inputText.Text += "+";
        }
                
        private void minus_Click(object sender, EventArgs e)
        {
            inputText.Text += "-";
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            inputText.Text += "x";
        }

        private void divide_Click(object sender, EventArgs e)
        {
            inputText.Text += "/";
        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                outputText.Text = evaluator.stringSolve(inputText.Text);
                historyText.Text += $"Input: {inputText.Text} {Environment.NewLine}";
                historyText.Text += $"Output: {outputText.Text} {Environment.NewLine}";
                inputText.Text = "";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                inputText.Text = inputText.Text.Substring(0, inputText.Text.Length - 1);
            }

        }

        private void closeBracketbtn_Click(object sender, EventArgs e)
        {
            inputText.Text += ")";
        }

        private void openBracketbtn_Click(object sender, EventArgs e)
        {
            inputText.Text += "(";
        }
    }
}
