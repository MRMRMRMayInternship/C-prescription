using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPrescriptionInterfaceProgramBate001.Controllers
{
    static class KeyPressEvent
    {
        /***
         * some textBox be allow to entry only number;
         ***/
        public static void KeyPressOnlyNumberEventHandle(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[0-9]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
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
            TextBox txt = (TextBox)sender;
            string exp = @"[0-9a-zA-Z]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
        /***
         * some textBox be allow to entry only letter;
         ***/
        public static void KeyPressOnlyLetterEventHandle(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[a-zA-Z]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
    }
}
