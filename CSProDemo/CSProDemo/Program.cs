using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProDemo
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /***
             * 1.login form
             * 2.main form
             ***/
            while (true)
            {
                /******** 1 login form *******/

               
                CSProDemo.View.LoginForm loginForm = new CSProDemo.View.LoginForm();
                loginForm.ShowDialog();
                /******** 2 main form *******/
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    CSProDemo.View.Main mainForm = new CSProDemo.View.Main();

                    Application.Run(mainForm);
                    if (mainForm.DialogResult == DialogResult.Cancel)
                    {
                        try
                        {
                            System.IO.File.Delete(@"./accout.txt");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        break;
                    }
                }
                else if(loginForm.DialogResult == DialogResult.Cancel){
                    try
                    {
                        System.IO.File.Delete(@"./accout.txt");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    break;
                }
            }
            
        }
    }
}
