using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComboBoxes.WinWorms;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace ComboBoxes
{
    public enum TypeFields
    {
        textBox   = 1,
        checkBox  = 2
    }
    public class ViewField
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public TypeFields Type { get; set; }
    }
    public class ResField
    {
        public string Name { get; set; }
        public TextBox TxtBx { get; set; }
        public string Val { get; set; }
        public bool IsSearchByField { get; set; }
    }
    public class TSimpleCmb<T>
    {
        private List<T> _srcCmb { get; set; }
        private List<ViewField> _vwFlds { get; set; }
        private List<ResField> _resFlds { get; set; }
        private string _caption { get; set; }
        private fmCmbSimple _fmCmb { get; set; }

        public TSimpleCmb(string caption)
        {
            _caption = caption;
        }
        private void ClearFileds()
        {
            foreach (ResField field in _resFlds)
            {
                if(field.TxtBx != null)
                    field.TxtBx.Text = string.Empty;
                field.Val = string.Empty;
            }
        }
        private void FillResFiledsFromInstance(T obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();
            if (props.Length == 0)
                return;

            foreach (ResField field in _resFlds)
            {
                bool isFound = false;
                int k = 0;
                for(k = 0; k < props.Length; k++)
                {
                    if(props[k].Name == field.Name)
                    {
                        isFound = true;
                        break;
                    }
                }
                if(isFound)
                {
                    field.Val = props[k].GetValue(obj).ToString();
                    if (field.TxtBx != null)
                        field.TxtBx.Text = field.Val;
                }
            }
        }

        public void AddCombobox(Button btn, List<T> srcCmb, List<ViewField> viewFields, List<ResField> resFields, bool addSortGrid, string defSortField)
        {
            if (btn == null) return;
            if (srcCmb == null) return;
            if (viewFields == null) return;
            if (addSortGrid && defSortField == string.Empty) return;
            
            _srcCmb = srcCmb;
            _vwFlds = viewFields;
            _resFlds = resFields;

            _fmCmb = new fmCmbSimple(_caption, viewFields);
            _fmCmb.SetSourceDgv(_srcCmb);
            if(addSortGrid)
                _fmCmb.AddSortGrid<T>(defSortField);

            foreach (ResField fld in resFields)
            {
                if (fld.IsSearchByField == true && fld.TxtBx != null)
                {
                    fld.TxtBx.Validating += new CancelEventHandler(textBox_Validating);
                    fld.TxtBx.KeyDown += new KeyEventHandler(textBox_KeyDown);
                }
            }
            if (btn != null)
            {
                btn.Click += new EventHandler(btn_Click);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(_fmCmb.ShowDialog() == DialogResult.OK)
            {
                T currentObject = _fmCmb.GetData<T>();
                FillResFiledsFromInstance(currentObject);
            }
        }
        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            string name = ((TextBox)sender).Name;
            ResField fld = _resFlds.FirstOrDefault(rec => rec.TxtBx != null && rec.TxtBx.Name == name);
            if (fld == null)
                return;
            if(fld.TxtBx.Text == string.Empty)
            {
                ClearFileds();
                return;
            }

            int i = 0;
            bool isFound = false;
            for (i = 0; i < _srcCmb.Count; i++)
            {
                PropertyInfo[] props = _srcCmb[i].GetType().GetProperties();

                if (props.Length == 0)
                    continue;

                for (int k = 0; k < props.Length; k++)
                {
                    if (props[k].Name == fld.Name)
                    {
                        string val = props[k].GetValue(_srcCmb[i]).ToString();
                        if (val == fld.TxtBx.Text)
                        {
                            isFound = true;
                            break;
                        }
                    }
                }
                if (isFound == true)
                    break;
            }
            if(isFound == true)
            {
                FillResFiledsFromInstance(_srcCmb[i]);
            }
            else
            {
                ClearFileds();
                btn_Click(sender, e);
            }
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_Validating(sender, new CancelEventArgs());
            }
        }

        public void ReadCombobox(string field, string val)
        {
            if (_srcCmb == null) return;
            if (_resFlds == null) return;

            int i = 0;
            bool isFound = false;
            for (i = 0; i < _srcCmb.Count; i++)
            {
                PropertyInfo[] props = _srcCmb[i].GetType().GetProperties();

                if (props.Length == 0)
                    continue;

                for (int k = 0; k < props.Length; k++)
                {
                    if (props[k].Name == field)
                    {
                        string propVal = props[k].GetValue(_srcCmb[i]).ToString();
                        if (val == propVal)
                        {
                            isFound = true;
                            break;
                        }
                    }
                }
                if (isFound == true)
                    break;
            }
            if (isFound == true)
            {
                FillResFiledsFromInstance(_srcCmb[i]);
            }
            else
            {
                ClearFileds();
            }
        }
    }
}
