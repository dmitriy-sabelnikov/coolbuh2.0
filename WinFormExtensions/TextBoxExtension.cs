using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormExtensions
{
    public static class TextBoxExtension
    {
        private static ToolTip tooltip = new ToolTip();
        private static void SetColorTextBox(TextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                textbox.BackColor = System.Drawing.SystemColors.Info;
            }
            else
            {
                textbox.BackColor = System.Drawing.SystemColors.Window;
            }
        }
        public static void NecessaryField(this TextBox textbox, int paddingWidthTooltip = 0)
        {
            SetColorTextBox(textbox);
            textbox.GotFocus += (object sender, EventArgs e) =>
            {
                textbox.BackColor = System.Drawing.Color.White;
                tooltip.Show("Обов'язкове поле для заповнення", textbox, textbox.Width + paddingWidthTooltip, 0);
            };

            textbox.LostFocus += (object sender, EventArgs e) =>
            {
                SetColorTextBox(textbox);
                tooltip.Hide(textbox);
            };

            textbox.TextChanged += (object sender, EventArgs e) =>
            {
                SetColorTextBox(textbox);
            };
        }
        public static void SetToolTipe(this TextBox textbox, string text)
        {
            tooltip.Show(text, textbox, textbox.Width, 0);
        }

        public static void AddFloatField(this TextBox textbox, int lnIntPart = 3, int lnFractPart = 2)
        {
            textbox.KeyPress += (object sender, KeyPressEventArgs e) =>
            {
                if(char.IsControl(e.KeyChar) || (e.KeyChar == 32))
                {
                    e.Handled = false;
                    return;
                }
                //32 - пробел
                if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == 44))
                {
                    e.Handled = true;
                    return;
                }
                if (char.IsDigit(e.KeyChar))
                {
                    //Есть выделение цифр
                    if (textbox.SelectionLength > 0)
                    {
                        textbox.Text = textbox.Text.Remove(textbox.SelectionStart, textbox.SelectionLength);
                    }

                    if (textbox.TextLength == lnIntPart + lnFractPart + 1)
                    {
                        e.Handled = true;
                        return;
                    }
                    int nSeparator = textbox.Text.IndexOf(',');
                    if (nSeparator >= 0)
                    {
                        int lnFract = textbox.Text.Substring(nSeparator + 1).Length;
                        int lnInt = textbox.TextLength - lnFract - 1;
                        int select = textbox.SelectionStart;
                        //проверяем целую часть
                        if (select <= nSeparator)
                        {
                            if (lnInt >= lnIntPart)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        else
                        //проверяем дробную часть
                        {
                            if (lnFract >= lnFractPart)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                    }
                    //Введено больше lnIntPart цифр ставим сепаратор
                    if (nSeparator == -1 && textbox.TextLength >= lnIntPart)
                    {
                        StringBuilder text = new StringBuilder();
                        for (int i = 0; i < textbox.TextLength; i++)
                        {
                            if (char.IsDigit(textbox.Text[i]))
                            {
                                text.Append(textbox.Text[i]);
                                if(i == lnIntPart -1)
                                    text.Append(',');
                            }
                        }
                        textbox.Text = text.ToString();
                        textbox.SelectionStart = text.Length;
                    }
                }
            };
            //Проверка возможности конвертирования текста в флоат
            textbox.Validating += (object sender, System.ComponentModel.CancelEventArgs e) =>
            {
                if (textbox.Text == string.Empty)
                {
                    e.Cancel = false;
                    return;
                }

                StringBuilder text = new StringBuilder(textbox.Text);
                int nSeparator = textbox.Text.IndexOf(',');
                if(nSeparator == -1)
                {
                    text.Append(",");
                    nSeparator = textbox.TextLength ;
                }
                int lnFract = text.ToString().Substring(nSeparator+1).Length;
                if (lnFract < lnFractPart)
                {
                    for (int i = 0; i < lnFractPart - lnFract; i++)
                    {
                        text.Append('0');
                    }
                }
                textbox.Text = text.ToString();
                textbox.SelectionStart = text.Length;

                float ft;
                if (!float.TryParse(textbox.Text, out ft))
                {
                    e.Cancel = true;
                    textbox.Select(0, textbox.Text.Length);
                    tooltip.Show("Некоректний формат числа з комою", textbox, textbox.Width, 0);
                }
            };

            textbox.LostFocus += (object sender, EventArgs e) =>
            {
                tooltip.Hide(textbox);
            };
        }

        public static void AddNumericField(this TextBox textbox)
        {
            textbox.KeyPress += (object sender, KeyPressEventArgs e) =>
            {
                //32 - пробел
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == 32))
                {
                    e.Handled = true;
                }
            };
        }
        public static void AddDateField(this TextBox textbox, char separator)
        {
            textbox.KeyPress += (object sender, KeyPressEventArgs e) =>
            {
                //Проверка на ввод цифр, управляющих символов и пробела
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == 32))
                {
                    e.Handled = true;
                }
                if (char.IsDigit(e.KeyChar))
                {
                    //Есть выделение цифр
                    if (textbox.SelectionLength > 0)
                    {
                        textbox.Text = textbox.Text.Remove(textbox.SelectionStart, textbox.SelectionLength);
                    }

                    if (textbox.TextLength == 10)
                    {
                        e.Handled = true;
                        return;
                    }
                    /*
                    StringBuilder first_part = new StringBuilder();
                    StringBuilder second_part = new StringBuilder();
                    StringBuilder third_part = new StringBuilder();
                    int length = textbox.Text.Length;
                    if(length >0 and length < 3)
                      first_part.Append(textbox.Text.Substring(0, 2));
                    second_part.Append(textbox.Text.Substring(3, 2));
                    third_part.Append(textbox.Text.Substring(6, 4));
                    */

                    /*_ _._ _._ _ _ _*/

                    int selectionStart = textbox.SelectionStart;
                    StringBuilder text = new StringBuilder();
                    for (int i = 0; i < 10; i++)
                    {
                        if (textbox.SelectionStart == i)
                            text.Append(e.KeyChar.ToString());
                        if (i < textbox.Text.Length && char.IsDigit(textbox.Text[i]))
                            text.Append(textbox.Text[i]);
                        if (text.Length == 2 || text.Length == 5)
                        {
                            text.Append(separator);
                            selectionStart++;
                        }
                    }
                    textbox.Text = text.ToString();
                    textbox.SelectionStart = selectionStart+1;
                    e.Handled = true;
                }
            };
            //Проверка возможности конвертирования текста в дату
            textbox.Validating += (object sender, System.ComponentModel.CancelEventArgs e) =>
            {
                if (textbox.Text == string.Empty)
                {
                    e.Cancel = false;
                    return;
                }
                DateTime dt;
                if (!DateTime.TryParse(textbox.Text, out dt))
                {
                    e.Cancel = true;
                    textbox.Select(0, textbox.Text.Length);
                    tooltip.Show("Некоректний формат дати", textbox, textbox.Width, 0);
                }
            };

            textbox.LostFocus += (object sender, EventArgs e) =>
            {
                tooltip.Hide(textbox);
            };

        }
        public static void IsModifyField(this TextBox textbox, Action isModify)
        {
            textbox.TextChanged += (object sender, EventArgs e) =>
            {
                isModify();
            };
        }
    }
}
