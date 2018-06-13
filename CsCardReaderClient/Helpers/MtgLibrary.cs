using System.Runtime.InteropServices;

namespace CsCardReaderClient.Helpers
{
    public class MtgLibrary
    {
        [DllImport("CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReadCardTitles(byte[] input, byte[] result, int resultMaxLength);

        [DllImport("CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CompareCardNames(byte[] cardName1, byte[] cardName2);

        [DllImport("CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMaxCardAmount();

        [DllImport("CardReaderLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetResultExample(byte[] result, int maxLength);
    }
}
