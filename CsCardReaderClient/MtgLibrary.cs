using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsCardReaderClient
{
    public class MtgLibrary
    {
        //[DllImport("C:\\Users\\BjornLa\\source\\repos\\ReadMagicCard\\Debug\\CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int GetMaxCardAmount();

        //[DllImport("C:\\Users\\BjornLa\\source\\repos\\ReadMagicCard\\Debug\\CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //public static extern string GetResultExample([MarshalAs(UnmanagedType.LPStr)] string example, int maxLength);

        //[DllImport("C:\\Users\\BjornLa\\source\\repos\\SimpleDll\\Debug\\SimpleDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern IntPtr GetString(IntPtr result, int maxLength);

        //Working test:

        //[DllImport("C:\\Users\\BjornLa\\source\\repos\\SimpleDll\\Debug\\SimpleDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Add(int a, int b);

        //[DllImport("C:\\Users\\BjornLa\\source\\repos\\SimpleDll\\Debug\\SimpleDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void GetString(byte[] result, int maxLength);

        [DllImport("CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMaxCardAmount();

        [DllImport("CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetResultExample(byte[] result, int maxLength);
    }
}
