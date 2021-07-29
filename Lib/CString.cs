using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace GCore.NativeInterop
{
    public enum CEncoding
    {
        Ascii,
        Wide,
        UTF8,
        UTF16,
        UTF32
    }

    public static class CEncodingExtension
    {
        public static int GetStride(this Encoding self)
        {
            if (self == Encoding.ASCII)
                return 1;
            if (self == Encoding.UTF8)
                return 1;
            if (self == Encoding.Unicode) // UTF16
                return 2;
            if (self == Encoding.UTF32)
                return 4;
            if (self == Encoding.Default) // UTF8
                return 1;
            throw new NotImplementedException();
        }

        public static int GetStride(this CEncoding self) => self.ToEncoding().GetStride();

        public static Encoding ToEncoding(this CEncoding self)
        {
            return self switch
            {
                CEncoding.Ascii => Encoding.ASCII,
                CEncoding.Wide => Environment.OSVersion.Platform == PlatformID.Unix
                                  || Environment.OSVersion.Platform == PlatformID.MacOSX
                    ? System.Text.Encoding.UTF32
                    : System.Text.Encoding.Unicode, // UTF-16
                CEncoding.UTF8 => Encoding.UTF8,
                CEncoding.UTF16 => Encoding.Unicode,
                CEncoding.UTF32 => Encoding.UTF32, // UTF-16
                _ => Encoding.ASCII
            };
        }

        public static byte[] GetBytes(this CEncoding self, string str) => self.ToEncoding().GetBytes(str + '\0');

        public static string GetString(this CEncoding self, byte[] str) => self.ToEncoding().GetString(str);

        public static string GetString(this CEncoding self, IntPtr str) => self.ToEncoding().GetString(str);

        public static string GetString(this Encoding self, IntPtr str)
        {
            if (str == IntPtr.Zero)
                return null;

            int stride = self.GetStride();
            int pos = 0;

            if (stride == 1)
                while (Marshal.ReadByte(str, pos) != 0)
                    pos += stride;
            else if (stride == 2)
                while (Marshal.ReadInt16(str, pos) != 0)
                    pos += stride;
            else if (stride == 4)
                while (Marshal.ReadInt32(str, pos) != 0)
                    pos += stride;

            byte[] strbuf = new byte[pos];
            Marshal.Copy(str, strbuf, 0, pos);
            return self.GetString(strbuf);
        }
    }

    public class CString : UnmanagedMemory
    {
        public Encoding Enc { get; protected set; }
        public String Str { get; protected set; }

        public CString(string str, CEncoding env = CEncoding.Ascii)
        {
            Enc = env.ToEncoding();
            Str = str;

            var data = Enc.GetBytes(str + '\0');
            Size = data.Length;
            Alloc(Size);
            Marshal.Copy(data, 0, Ptr, Size);
        }
    }

    public struct NativeString
    {
        public IntPtr Ptr;

        public override string ToString()
        {
            return Encoding.ASCII.GetString(Ptr);
        }
    }

    public struct NativeWString
    {
        public IntPtr Ptr;

        public override string ToString()
        {
            return CEncoding.Wide.GetString(Ptr);
        }
    }
}