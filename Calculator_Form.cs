using System;
using System.CodeDom.Compiler;
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
    public partial class Calculator_Form : Form
    {
        public bool Previous_Button_is_Digit = false;
        public bool Previous_Button_is_Operation = false;
        public bool Previous_Button_is_Equal = false;
        public bool Previous_Button_is_Clear = false;

        public string Label_String;

        public Calculator_Form()
        {
            InitializeComponent();
            Calculator_label.Text = "";
            Calculator_TextBox.Text = "0";
            
        }

        public void Disable_Buttons()
        {
            Button_1.Enabled = false;
            Button_2.Enabled = false;
            Button_3.Enabled = false;
            Button_4.Enabled = false;
            Button_5.Enabled = false;
            Button_6.Enabled = false;
            Button_7.Enabled = false;
            Button_8.Enabled = false;
            Button_9.Enabled = false;
            Button_0.Enabled = false;

            Button_Minus.Enabled = false;
            Button_Plus.Enabled = false;
            Button_Multi.Enabled = false;
            Button_Div.Enabled = false;

            Button_Equal.Enabled = false;
        }

        public void Enable_buttons()
        {
            Button_1.Enabled = true;
            Button_2.Enabled = true;
            Button_3.Enabled = true;
            Button_4.Enabled = true;
            Button_5.Enabled = true;
            Button_6.Enabled = true;
            Button_7.Enabled = true;
            Button_8.Enabled = true;
            Button_9.Enabled = true;
            Button_0.Enabled = true;

            Button_Minus.Enabled = true;
            Button_Plus.Enabled = true;
            Button_Multi.Enabled = true;
            Button_Div.Enabled = true;

            Button_Equal.Enabled = true;
        }

        public void Digit_Button_pressed(char new_digit)
        {

            if (Previous_Button_is_Digit)
            {
                if ((Calculator_TextBox.Text.Equals("0")))
                {
                    Calculator_TextBox.Text = new_digit.ToString();

                    Label_String = Calculator_label.Text;
                    Label_String = Label_String.Substring(0, Label_String.Length - 1);

                    Calculator_label.Text = Label_String + new_digit.ToString();
                }
                else
                {
                    Calculator_TextBox.Text = Calculator_TextBox.Text + new_digit.ToString();
                    Calculator_label.Text = Calculator_label.Text + new_digit.ToString();
                }
            }
            else if (Previous_Button_is_Equal)
            {
                Calculator_TextBox.Text = new_digit.ToString();
                Calculator_label.Text = new_digit.ToString();
            }
            else if (Previous_Button_is_Operation)
            {
                Calculator_TextBox.Text = new_digit.ToString();
                Calculator_label.Text = Calculator_label.Text + new_digit.ToString();
            }
            else // clear
            {
                Calculator_TextBox.Text = new_digit.ToString();
                Calculator_label.Text = new_digit.ToString();
            }
            Previous_Button_is_Clear = false;
            Previous_Button_is_Digit = true;
            Previous_Button_is_Operation = false;
            Previous_Button_is_Equal = false;
        }

        public void Operation_Button_pressed(char new_op)
        {
            if (Calculator_label.Text.Length > 0)
            {
                if (Char.IsDigit(Calculator_label.Text.Last()))
                {
                    Calculator_label.Text = Calculator_label.Text + new_op.ToString();
                }
                else
                {
                    if (Calculator_label.Text.Last() == '=')
                    {
                        Calculator_label.Text = Calculator_TextBox.Text;
                        Calculator_label.Text = Calculator_label.Text + new_op.ToString();
                    }
                    else
                    {
                        Label_String = Calculator_label.Text;
                        Label_String = Label_String.Substring(0, Label_String.Length - 1);
                        Calculator_label.Text = Label_String + new_op.ToString();
                    }
                }
            }
            else
            {
                Calculator_label.Text = "0" + new_op.ToString();
            }

            Previous_Button_is_Clear = false;
            Previous_Button_is_Digit = false;
            Previous_Button_is_Operation = true;
            Previous_Button_is_Equal = false;

        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('1');
            
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('2');
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('3');
        }

        private void Button_4_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('4');
        }

        private void Button_5_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('5');
        }

        private void Button_6_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('6');
        }

        private void Button_7_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('7');
        }

        private void Button_8_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('8');
        }

        private void Button_9_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('9');
        }

        private void Button_0_Click(object sender, EventArgs e)
        {
            Digit_Button_pressed('0');
        }

        private void Button_Plus_Click(object sender, EventArgs e)
        {
            Operation_Button_pressed('+');
        }

        private void Button_Minus_Click(object sender, EventArgs e)
        {
            Operation_Button_pressed('-');
        }

        private void Button_Multi_Click(object sender, EventArgs e)
        {
            Operation_Button_pressed('*');
        }

        private void Button_Div_Click(object sender, EventArgs e)
        {
            Operation_Button_pressed('/');
        }

        private void Button_Equal_Click(object sender, EventArgs e)
        {
            int val_int = 0;
            double val_double=0.0;
            long val_long=0;
            object result;
            DataTable dt = new DataTable();
 

            if ((Calculator_label.Text.Length == 0) | (String.Equals(Calculator_label.Text, "=")))
            {
                result = 0;
                Calculator_label.Text = "";
            }
            else if ((Calculator_label.Text.Contains("/0")) | (String.Equals(Calculator_label.Text,"0/")))
            {
                MessageBox.Show("Det går inte att dela med 0.");

                Disable_Buttons();

            }
            else
            {
                if (Previous_Button_is_Operation)
                {
                    Calculator_label.Text = Calculator_label.Text + Calculator_TextBox.Text;
                    
                }
                else if (Previous_Button_is_Digit)
                {
                    
                }
                else if (Previous_Button_is_Equal)
                {
                    Calculator_label.Text = Calculator_TextBox.Text + Calculator_label.Text.Last().ToString();
                    
                }
                else // Clear =
                {
                    
                }

                try 
                { 
                    result = dt.Compute(Calculator_label.Text, "");

                    if (Object.ReferenceEquals(result.GetType(), val_double.GetType()))
                    {

                        val_double = (double)result;

                        if ((val_double >= -2147483648) & (val_double <= 2147483647))
                        {

                            val_int = (int)Math.Floor(val_double);
                            if (val_double != Convert.ToDouble(val_int))
                            {
                                MessageBox.Show("Resultat är avrundat.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Resultat överskriver range för Int.");

                            Disable_Buttons();
                        }

                    }
                    else if (Object.ReferenceEquals(result.GetType(), val_int.GetType()))
                    {
                        val_int = (int)result;
                    }
                    else
                    {
                        if (Object.ReferenceEquals(result.GetType(), val_long.GetType()))
                        {
                            val_long = (long)result;
                            if ((val_long >= -2147483648) & (val_long <= 2147483647))
                            {
                                val_int = (int)val_long;
                            }
                            else
                            {
                                MessageBox.Show("Resultat överskriver range för Int.");
                                Disable_Buttons();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Tal som används i matelamiska uttrycket överskriver range för Int.");

                            Disable_Buttons();
                        }
                    }

                    if (Button_1.Enabled)
                    {
                        Calculator_TextBox.Text = $"{val_int}";
                        Calculator_label.Text = Calculator_label.Text + "=";
                    }

                }
                catch (OverflowException)
                {
                    MessageBox.Show("Resultat överskriver range för Int.");

                    Disable_Buttons();
                }

            }

            Previous_Button_is_Clear = false;
            Previous_Button_is_Digit = false;
            Previous_Button_is_Operation = false;
            Previous_Button_is_Equal = true;

        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            Calculator_label.Text = "";
            Calculator_TextBox.Text = "0";

            Enable_buttons();

            Previous_Button_is_Clear = true;
            Previous_Button_is_Digit = false;
            Previous_Button_is_Operation = false;
            Previous_Button_is_Equal = false;
        }

        private void Calculator_label_TextChanged(object sender, EventArgs e)
        {
            if (Calculator_label.Text.Length > 30)
            {
                MessageBox.Show("Det matematiska uttrycket får inte överskrida 30 symboler.");

                Button_1.Enabled = false;
                Button_2.Enabled = false;
                Button_3.Enabled = false;
                Button_4.Enabled = false;
                Button_5.Enabled = false;
                Button_6.Enabled = false;
                Button_7.Enabled = false;
                Button_8.Enabled = false;
                Button_9.Enabled = false;
                Button_0.Enabled = false;

                Button_Minus.Enabled = false;
                Button_Plus.Enabled = false;
                Button_Multi.Enabled = false;
                Button_Div.Enabled = false;

                Button_Equal.Enabled = false;
            }
        }
    }
}
