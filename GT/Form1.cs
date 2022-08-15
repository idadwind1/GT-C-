using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace GT
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlashWindowEx")]
        private static extern void FlashWindowEx(ref FLASHWINFO pwfi);
        public struct FLASHWINFO
        {
            public UInt32 cbSize;//该结构的字节大小
            public IntPtr hwnd;//要闪烁的窗口的句柄，该窗口可以是打开的或最小化的
            public UInt32 dwFlags;//闪烁的状态
            public UInt32 uCount;//闪烁窗口的次数
            public UInt32 dwTimeout;//窗口闪烁的频度，毫秒为单位；若该值为0，则为默认图标的闪烁频度
        }
        public const UInt32 FLASHW_TRAY = 2;
        public const UInt32 FLASHW_TIMERNOFG = 12;
        public static class TaskbarManager
        {
            private static IntPtr ownerHandle = IntPtr.Zero;
            static TaskbarManager()
            {
                var currentProcess = Process.GetCurrentProcess();
                if (currentProcess != null && currentProcess.MainWindowHandle != IntPtr.Zero)
                    ownerHandle = currentProcess.MainWindowHandle;
            }
            private static bool IsPlatformSupported
            {
                get { return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.CompareTo(new Version(6, 1)) >= 0; }
            }
            public static void SetProgressValue(int currentValue, int maximumValue)
            {
                if (IsPlatformSupported && ownerHandle != IntPtr.Zero)
                    TaskbarList.Instance.SetProgressValue(
                        ownerHandle,
                        Convert.ToUInt32(currentValue),
                        Convert.ToUInt32(maximumValue));
            }
            public static void SetProgressValue(int currentValue, int maximumValue, IntPtr windowHandle)
            {
                if (IsPlatformSupported)
                    TaskbarList.Instance.SetProgressValue(
                        windowHandle,
                        Convert.ToUInt32(currentValue),
                        Convert.ToUInt32(maximumValue));
            }
            public static void SetProgressState(TaskbarProgressBarState state)
            {
                if (IsPlatformSupported && ownerHandle != IntPtr.Zero)
                    TaskbarList.Instance.SetProgressState(ownerHandle, (TaskbarProgressBarStatus)state);
            }
            public static void SetProgressState(TaskbarProgressBarState state, IntPtr windowHandle)
            {
                if (IsPlatformSupported)
                    TaskbarList.Instance.SetProgressState(windowHandle, (TaskbarProgressBarStatus)state);
            }
        }
        public enum TaskbarProgressBarState
        {
            NoProgress = 0,
            Indeterminate = 0x1,
            Normal = 0x2,
            Error = 0x4,
            Paused = 0x8
        }
        internal static class TaskbarList
        {
            private static object _syncLock = new object();

            private static ITaskbarList4 _taskbarList;
            internal static ITaskbarList4 Instance
            {
                get
                {
                    if (_taskbarList == null)
                    {
                        lock (_syncLock)
                        {
                            if (_taskbarList == null)
                            {
                                _taskbarList = (ITaskbarList4)new CTaskbarList();
                                _taskbarList.HrInit();
                            }
                        }
                    }

                    return _taskbarList;
                }
            }
        }
        [GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")]
        [ClassInterfaceAttribute(ClassInterfaceType.None)]
        [ComImportAttribute()]
        internal class CTaskbarList { }
        [ComImportAttribute()]
        [GuidAttribute("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface ITaskbarList4
        {
            [PreserveSig]
            void HrInit();
            [PreserveSig]
            void AddTab(IntPtr hwnd);
            [PreserveSig]
            void DeleteTab(IntPtr hwnd);
            [PreserveSig]
            void ActivateTab(IntPtr hwnd);
            [PreserveSig]
            void SetActiveAlt(IntPtr hwnd);
            [PreserveSig]
            void MarkFullscreenWindow(
                IntPtr hwnd,
                [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
            [PreserveSig]
            void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);
            [PreserveSig]
            void SetProgressState(IntPtr hwnd, TaskbarProgressBarStatus tbpFlags);
            [PreserveSig]
            void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);
            [PreserveSig]
            void UnregisterTab(IntPtr hwndTab);
            [PreserveSig]
            void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);
            [PreserveSig]
            void SetTabActive(IntPtr hwndTab, IntPtr hwndInsertBefore, uint dwReserved);
            [PreserveSig]
            HResult ThumbBarAddButtons(
                IntPtr hwnd,
                uint cButtons,
                [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
            [PreserveSig]
            HResult ThumbBarUpdateButtons(
                IntPtr hwnd,
                uint cButtons,
                [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
            [PreserveSig]
            void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);
            [PreserveSig]
            void SetOverlayIcon(
              IntPtr hwnd,
              IntPtr hIcon,
              [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
            [PreserveSig]
            void SetThumbnailTooltip(
                IntPtr hwnd,
                [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
            [PreserveSig]
            void SetThumbnailClip(
                IntPtr hwnd,
                IntPtr prcClip);
            void SetTabProperties(IntPtr hwndTab, SetTabPropertiesOption stpFlags);
        }
        internal enum TaskbarProgressBarStatus
        {
            NoProgress = 0,
            Indeterminate = 0x1,
            Normal = 0x2,
            Error = 0x4,
            Paused = 0x8
        }
        internal enum ThumbButtonMask
        {
            Bitmap = 0x1,
            Icon = 0x2,
            Tooltip = 0x4,
            THB_FLAGS = 0x8
        }
        [Flags]
        internal enum ThumbButtonOptions
        {
            Enabled = 0x00000000,
            Disabled = 0x00000001,
            DismissOnClick = 0x00000002,
            NoBackground = 0x00000004,
            Hidden = 0x00000008,
            NonInteractive = 0x00000010
        }
        internal enum SetTabPropertiesOption
        {
            None = 0x0,
            UseAppThumbnailAlways = 0x1,
            UseAppThumbnailWhenActive = 0x2,
            UseAppPeekAlways = 0x4,
            UseAppPeekWhenActive = 0x8
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct ThumbButton
        {
            internal const int Clicked = 0x1800;

            [MarshalAs(UnmanagedType.U4)]
            internal ThumbButtonMask Mask;
            internal uint Id;
            internal uint Bitmap;
            internal IntPtr Icon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string Tip;
            [MarshalAs(UnmanagedType.U4)]
            internal ThumbButtonOptions Flags;
        }
        public enum HResult
        {
            Ok = 0x0000,
            False = 0x0001,
            InvalidArguments = unchecked((int)0x80070057),
            OutOfMemory = unchecked((int)0x8007000E),
            NoInterface = unchecked((int)0x80004002),
            Fail = unchecked((int)0x80004005),
            ElementNotFound = unchecked((int)0x80070490),
            TypeElementNotFound = unchecked((int)0x8002802B),
            NoObject = unchecked((int)0x800401E5),
            Win32ErrorCanceled = 1223,
            Canceled = unchecked((int)0x800704C7),
            ResourceInUse = unchecked((int)0x800700AA),
            AccessDenied = unchecked((int)0x80030005)
        }
        public Form1()
        {
            InitializeComponent();
        }
        List<string> language = new List<string>(new[]
        {
            "en",
            "de",
            "ja",
            "fr",
            "mn",
            "pl",
            "el",
            "es",
            "th",
            "ko",
            "my",
            "ru",
            "pt",
            "tt",
            "ts",
            "st",
            "ceb",
            "bm",
            "et",
            "sk",
            "eo",
            "sn",
            "la",
            "gn",
            "ms",
            "be",
            "uk"
        });
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label4.Visible = true;
            button2.Enabled = true;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            numericUpDown1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            richTextBox2.Enabled = false;
            richTextBox1.Enabled = false; 
            new Task(() =>
            {
                TaskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
                string output = richTextBox2.Text;
                if (richTextBox2.Text != "")
                {
                    Random ran = new Random();
                    string tlanguage2 = "zh-CN";
                    string tlanguage = language[ran.Next(0, language.Count)];
                    label4.Text = "正在翻译第1次，语言：" + tlanguage2 + " => " + tlanguage;
                    output = Trans(output, tlanguage2, tlanguage);
                    progressBar1.Value += 100 / ((int)numericUpDown1.Value);
                    TaskbarManager.SetProgressValue(progressBar1.Value, 100);
                    tlanguage2 = tlanguage;
                    for (int i = 0; i < numericUpDown1.Value-1; i++)
                    {
                        if (button2.Enabled)
                        {
                            tlanguage = language[ran.Next(0, language.Count)];
                            while (tlanguage == tlanguage2)
                            {
                                tlanguage = language[ran.Next(0, language.Count)];
                            }
                            label4.Text = "正在翻译第" + (i + 2).ToString() + "次，语言："+ tlanguage2 + " => " + tlanguage;
                            string[] list = { };
                            output = Trans(output, tlanguage2, tlanguage);
                            progressBar1.Value += 100 / ((int)numericUpDown1.Value);
                            TaskbarManager.SetProgressValue(progressBar1.Value, 100);
                            tlanguage2 = tlanguage;
                        }
                    }
                    //progressBar1.Value = 0;
                    //progressBar1.MarqueeAnimationSpeed = 100;
                    //progressBar1.Style = ProgressBarStyle.Marquee; 
                    TaskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);
                    label4.Text = "正在翻译最后一次，语言：" + tlanguage2 + " => zh-CN";
                    Trans(output, tlanguage2, "zh-CN");
                    button2.Text = "取消";
                    label4.Visible = false;
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = "翻译内容不可为空";
                }
                FLASHWINFO fInfo = new FLASHWINFO();
                fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
                fInfo.hwnd = Handle;
                fInfo.dwFlags = FLASHW_TRAY | FLASHW_TIMERNOFG;
                fInfo.uCount = 3;
                fInfo.dwTimeout = 500;
                FlashWindowEx(ref fInfo);
                progressBar1.Style = ProgressBarStyle.Blocks;
                button2.Enabled = false;
                richTextBox2.Enabled = true;
                button3.Enabled = true;
                richTextBox1.Enabled = true;
                button1.Enabled = true;
                numericUpDown1.Enabled = true;
                button4.Enabled = true;
                TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                progressBar1.Value = 0;
            }).Start();
        }

        #region 翻译
        public string Google(string q,string from,string to)
        {
            string url = "https://translate.google.cn/_/TranslateWebserverUi/data/batchexecute?rpcids=MkEWBc&bl=boq_translate-webserver_20210927.13_p0&soc-app=1&soc-platform=1&soc-device=1&rt=c";
            var from_data = "f.req=" + HttpUtility.UrlEncode(
                string.Format("[[[\"MkEWBc\",\"[[\\\"{0}\\\",\\\"{1}\\\",\\\"{2}\\\",true],[null]]\", null, \"generic\"]]]",
                ReplaceString(q), from, to), Encoding.UTF8).Replace("+", "%20");
            byte[] postData = Encoding.UTF8.GetBytes(from_data);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            client.Headers.Add("ContentLength", postData.Length.ToString());
            client.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36");
            //MessageBox.Show(url);
            byte[] responseData = client.UploadData(url, "POST", postData);
            string content = Encoding.UTF8.GetString(responseData);
            richTextBox3.Text = content;
            return MatchResult(content);
        }
        public static string MatchResult(string content)
        {
            string result = "";
            string patttern = @",\[\[\\\""(.*?)\\\"",";
            Regex regex = new Regex(patttern);
            MatchCollection matchcollection = regex.Matches(content);
            if (matchcollection.Count > 0)
            {
                List<string> list = new List<string>();
                list.Add(matchcollection[1].Groups[1].Value);
                result = string.Join(" ", list.Distinct());
                if (result.LastIndexOf(@"\""]]]],\""") > 0)
                {
                    result = result.Substring(0, result.LastIndexOf(@"\""]]]],"));
                }
            }
            return result;
        }
        public static string ReplaceString(string JsonString)
        {
            if (JsonString == null) { return JsonString; }
            if (JsonString.Contains("\\"))
            {
                JsonString = JsonString.Replace("\\", "\\\\");
            }
            if (JsonString.Contains("\'"))
            {
                JsonString = JsonString.Replace("\'", "\\\'");
            }
            if (JsonString.Contains("\""))
            {
                JsonString = JsonString.Replace("\"", "\\\\\\\"");
            }
            //去掉字符串的回车换行符
            JsonString = Regex.Replace(JsonString, @"[\n\r]", "");
            JsonString = JsonString.Trim();
            return JsonString;
        }
        public string Trans(string text, string from, string to)
        {
            richTextBox1.Text = "";
            string[] split = text.Split('\n');
            string Return = "";
            foreach (string s in split)
            {
                richTextBox1.Text += Google(s, from, to) + "\n";
                Return += Google(s, from, to) + "\n";
            }
            return Return;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Enabled)
            {
                button2.Enabled = false;
                button2.Text = "取消中...";
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text += Clipboard.GetText();
        } 

        private void button5_Click(object sender, EventArgs e)
        {
            Form1_HelpButtonClicked(sender, new CancelEventArgs());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        
        public string[] splitbyindex(string text, int index)
        {
            string[] output = {};
            string s = "";
            string s2 = "";
            for (int i = 0; i < index+1; i++)
            {
                if (i != (index))
                {
                    s += text[i];
                }
                s2 += text[i + index];
            }
            output.Append(s);
            output.Append(s2);
            return output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Task(() =>
            {
                while (true)
                {
                    if (button2.Enabled)
                    {
                        Text = "谷歌生草机 正在翻译";
                        Thread.Sleep(50);
                        for (int i = 0; i < 3; i++)
                        {
                            Text += ".";
                            Thread.Sleep(50);
                        }
                    }
                    else
                    {
                        Text = "谷歌生草机";
                    }
                }
            }).Start();
        }

        private void richTextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (richTextBox2.Dock == DockStyle.Fill)
            {
                richTextBox2.Dock = DockStyle.None;
            }
            else
            {
                richTextBox2.Dock = DockStyle.Fill;
                richTextBox2.BringToFront();
            }
        }

        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (richTextBox1.Dock == DockStyle.Fill)
            {
                richTextBox1.Dock = DockStyle.None;
            }
            else
            {
                richTextBox1.Dock = DockStyle.Fill;
                richTextBox1.BringToFront();
            }
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show(
                "谷歌生草机帮助：" +
                "\n\n注：翻译时一行不要多于30个字！！不然将会翻译一半" +
                "\n\n简介：\n最近谷歌翻译在网上火了，因为谷歌翻译是机器翻译，所以如果只是翻译一次，大体还是有九成九的准确度的，但是当使用谷歌翻译选择小语种，然后小语种再翻译到另一个小语种，重复翻译多遍后，内容就会疯狂失真，然后准确度也会随着翻译次数开始偏离原来的真正的意思" +
                "\n由于手动翻译太慢，于是就有了这款自动翻译机" +
                "\n\n用法：" +
                "\n1. 在输入下的输入框中输入要翻译的东西，或按下粘贴按钮粘贴内容到输入框" +
                "\n2. 输入翻译次数" +
                "\n3. 按下翻译按钮" +
                "\n4. 等待翻译结束，或可中通按下取消立刻输出" +
                "\n5. 按下复制按钮复制内容到剪贴板" +
                "\n\nFAQ：" +
                "\nQ：这是假的吗？" +
                "\nA：不是，这是货真价实的谷歌翻译" +
                "\nQ：是线上的还是线下的？" +
                "\nA：本软件为线上的，需要联网，不然无法翻译" +
                "\nQ：为什么每次翻译虽然输入一样，但结果却不同呢？" +
                "\nA：每次翻译的语言顺序不同，结果也不同" +
                "\n\n是否获取更多帮助？"
                , "帮助", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("选择按钮或输入框并按下，即可获取帮助\n按下“确定”开始选择","使用方法",MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.Cancel = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TopMost)
            {
                TopMost = false;
                checkBox1.Checked = false;
            }
            else
            {
                TopMost = true;
                checkBox1.Checked = true;
            }
        }
    }
}
