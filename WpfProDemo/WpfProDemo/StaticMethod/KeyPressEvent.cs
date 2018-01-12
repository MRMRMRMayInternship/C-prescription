using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
namespace WpfProDemo.StaticMethod
{
    static class KeyPressEvent
    {
        /***
         * some textBox be allow to entry only number;
         ***/
        public static void KeyPressOnlyNumberEventHandle(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            //[ㄱ-힣] Only korean
            string exp = @"[\d]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
        
        public static void KeyPressOnlyNumberAndPointEventHandle(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[.]|[\d]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '\b') return;
                string text = txt.Text + e.KeyChar;
                var subTextList = text.Split('.');
                if (subTextList.Count() > 2 || (subTextList.Count() == 2 && subTextList[1].Length > 3))
                {
                    e.Handled = true;
                }
            }
        }
        /***
         * Method Name : KeyPressOnlyNumberAndLetterEventHandle
         * Detail: some textBoxs be only allowed to entry number and letter;
         * By : MRMRMRMAY
         * Creation date: 17-12-28
         ***/
        public static void KeyPressOnlyNumberAndLetterEventHandle(object sender, KeyPressEventArgs e)
        {
            string exp = @"[0-9a-zA-Z]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
        /***
         * some textBox be allow to entry only letter;
         ***/
        public static void KeyPressOnlyLetterEventHandle(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string exp = @"[a-zA-Z]|[\b]"; 
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.Key, exp))
            {
                e.Handled = true;
            }
        }
    }
}
