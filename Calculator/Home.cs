using Calculator.Classes;
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
    public partial class Home : Form
    {
        bool eraser;
        bool reset = false;
        int operation = 0;
        Dictionary<int, string> symbols = new();
        double a = 0;
        double b = 0;
        double result = 0;

        public Home()
        {
            InitializeComponent();
            eraser = true;
            symbols.Add(0, "=");
            symbols.Add(1, "+");
            symbols.Add(2, "-");
            symbols.Add(3, "x");
            symbols.Add(4, "÷");
        }

        private void Add_Symbol(string number)
        {
            if (reset)
            {
                history.Text = "";
                reset = false;
            }
            if (eraser || screen.Text == "0")
            {
                screen.Text = number;
                eraser = false;
                reset = false;
            }
            else
            {
                screen.Text += number;
            }
        }

        private void Calculate()
        {
            switch (operation)
            {
                case 1:
                    result = Operation.Plus(a, b);
                    break;
                case 2:
                    result = Operation.Subtract(a, b);
                    break;
                case 3:
                    result = Operation.Times(a, b);
                    break;
                case 4:
                    result = Operation.Divide(a, b);
                    break;
            }
        }

        private void Operate(int symbol)
        {
            if (history.Text == "")
            {
                a = Convert.ToDouble(screen.Text);
                history.Text = screen.Text + symbols[operation];
                eraser = true;
            }
            else
            {
                if (reset)
                {
                    Calculate();
                    history.Text = String.Format("{0}{1}{2}=", a, symbols[operation], b);
                    a = result;
                    screen.Text = result.ToString();
                }
                else if (eraser)
                {
                    history.Text = history.Text.Remove(history.Text.Length - 1).ToString() + symbols[symbol];
                }
                else
                {
                    a = Convert.ToDouble(history.Text.Remove(history.Text.Length - 1).ToString());
                    b = Convert.ToDouble(screen.Text);
                    Console.WriteLine(a.ToString() + b.ToString());
                    Calculate();
                    history.Text = result.ToString() + symbols[symbol];
                    eraser = true;
                }
            }
        }
        private void one_Click(object sender, EventArgs e)
        {
            Add_Symbol("1");
        }

        private void two_Click(object sender, EventArgs e)
        {
            Add_Symbol("2");
        }

        private void three_Click(object sender, EventArgs e)
        {
            Add_Symbol("3");
        }

        private void four_Click(object sender, EventArgs e)
        {
            Add_Symbol("4");
        }

        private void five_Click(object sender, EventArgs e)
        {
            Add_Symbol("5");
        }

        private void six_Click(object sender, EventArgs e)
        {
            Add_Symbol("6");
        }

        private void seven_Click(object sender, EventArgs e)
        {
            Add_Symbol("7");
        }

        private void eight_Click(object sender, EventArgs e)
        {
            Add_Symbol("8");
        }

        private void nine_Click(object sender, EventArgs e)
        {
            Add_Symbol("9");
        }

        private void zero_Click(object sender, EventArgs e)
        {
            Add_Symbol("0");
        }

        private void ce_Click(object sender, EventArgs e)
        {
            screen.Text = "0";
            if (reset)
            {
                history.Text = "";
            }
        }

        private void point_Click(object sender, EventArgs e)
        {
            if (reset || eraser)
            {
                screen.Text = "0.";
                reset = false;  
                eraser = false;
            }
            else if (!screen.Text.Contains('.'))
            {
                screen.Text += ".";
            }
            
        }

        private void sign_Click(object sender, EventArgs e)
        {
            screen.Text = (Convert.ToDouble(screen.Text) * -1).ToString();
            if (reset)
            {
                a = a * -1;
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (screen.Text.Length > 1)
            {
                screen.Text = screen.Text.Remove(screen.Text.Length - 1).ToString();

            }
            else 
            {
                screen.Text = "0";
            }
            if (screen.Text == "-")
            {
                screen.Text = "0";
            }
            if (reset)
            {
                a = Convert.ToDouble(screen.Text);
            }
        }

        private void c_Click(object sender, EventArgs e)
        {
            screen.Text = "0";
            history.Text = "";
            operation = 0;
        }

        private void divide_Click(object sender, EventArgs e)
        {
            if (reset)
            {
                reset = false;
                operation = 4;
                history.Text = result.ToString() + symbols[4];
            }
            else
            {
                if (operation == 0)
                {
                    operation = 4;
                }
                Operate(4);
                operation = 4;
            }
        }

        private void times_Click(object sender, EventArgs e)
        {
            if (reset)
            {
                reset = false;
                operation = 3;
                history.Text = result.ToString() + symbols[3];
            }
            else
            {
                if (operation == 0)
                {
                    operation = 3;
                }
                Operate(3);
                operation = 3;
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (reset)
            {
                reset = false;
                operation = 2;
                history.Text = result.ToString() + symbols[2];
            }
            else
            {
                if (operation == 0)
                {
                    operation = 2;
                }
                Operate(2);
                operation = 2;
            }
        }
        private void plus_Click(object sender, EventArgs e)
        {
            if (reset)
            {
                reset = false;
                operation = 1;
                history.Text = result.ToString() + symbols[1];
            }
            else
            {
                if (operation == 0)
                {
                    operation = 1;
                }
                Operate(1);
                operation = 1;
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            eraser = true;
            if (operation == 0)
            {
                history.Text = screen.Text + "=";
            }
            else
            {
                if (!reset)
                {
                    b = Convert.ToDouble(screen.Text);
                    reset = true;
                }
                Operate(0);
            }
        }
    }
}
