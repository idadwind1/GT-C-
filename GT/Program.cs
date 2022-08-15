using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GT
{
    internal static class Program
    {
        [DllImport("sensapi.dll", SetLastError = true)]
        private static extern bool IsNetworkAlive(out int connectionDescription);
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref IntPtr dwFlag, int dwReserved);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                DialogResult result = DialogResult.Retry;
                while (result == DialogResult.Retry)
                {
                    if (IsConnected)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                    }
                    else
                    {
                        result = MessageBox.Show("设备现在处于未联网状态，但本软件为线上软件，请联网后再试", "未联网", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if (result == DialogResult.Abort)
                        {
                            return;
                        }
                        else if (result == DialogResult.Ignore)
                        {
                            result = DialogResult.Retry;
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new Form1());
                        }
                    }
                }
            }
            else if (args.Length == 2)
            {
                try
                {
                    new Form2(args[0], int.Parse(args[1])).ShowDialog();
                }
                catch (FormatException)
                {
                    MessageBox.Show("无法将\"" + args[1] +"\"识别为数字");
                }
            }
            else
            {
                MessageBox.Show("用法：\n谷歌生草机 [输入] [翻译次数]\n输入 - 文本，指定要输入的文本\n翻译次数 - 数字，指定要翻译的次数");
            }
        }
        private const int LanNetworkConnectedFlag = 1;
        public static bool IsConnected
        {
            get
            {
                var isNetworkConnected = IsNetworkAlive(out int flags);
                if (isNetworkConnected && flags == LanNetworkConnectedFlag)
                {
                    var dwFlag = new IntPtr();
                    isNetworkConnected = InternetGetConnectedState(ref dwFlag, 0);
                }
                return isNetworkConnected;
            }
        }
    }
}
