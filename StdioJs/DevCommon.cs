using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace StdioJs
{
    public static class DevCommon
    {
        public static string Version => "1.0.0.0";
        public static string VersionTime => "2018-12-29 20:23:00";
        public static void MsgBox(this Control @this, string msg)
        {
            MessageBox.Show(@this, msg);
        }
        //字符串生成唯一Hash码,统一用UTF8格式来处理
        public static string MD5GenerateHashString(string str)
        {
            Stream stmcheck = new MemoryStream(Encoding.UTF8.GetBytes(str));
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();

            byte[] result = md5.ComputeHash(stmcheck);

            stmcheck.Close();
            string r = null;
            foreach (byte b in result)
            {
                r = r + b.ToString("x2");
            }
            return r;
        }
    }
}
