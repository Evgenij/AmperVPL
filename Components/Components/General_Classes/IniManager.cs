using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class INIManager
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public INIManager(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string ReadString(string Section, string Key)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public int ReadInt(string Section, string Key)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Convert.ToString(Key), "", RetVal, 255, Path);
            return Convert.ToInt32(RetVal.ToString());
        }

        public void WriteString(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }
        public void WriteInt(string Section, string Key, int Value)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Convert.ToString(Value), Path);
        }

        public void DeleteSection(string Section = null)
        {
            WriteString(Section ?? EXE, null, null);
        }

        public void DeleteKey(string Section, string Key)
        {
            WriteString(Section ?? EXE, Key, null);
        }

        public bool KeyExists(string Section, string Key)
        {
            return ReadString(Section, Key).Length > 0;
        }
    }
}
