using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Y2kDemo;

namespace Y2kDemoTests
{

   [TestClass()]
   public class Y2KCheckerTests
   {

      [TestMethod()]
      [ExpectedException(typeof (Y2KException))]
      public void ThrowIfY2KTest()
      {
         //arrange
         var systemtime = new SYSTEMTIME(new DateTime(2000, 1, 1));
         var sut = new Y2KChecker();
         var result = SetSystemTime(ref systemtime);

         Assert.IsTrue(result);

         sut.ThrowIfY2K();
      }

      #region Here there be dragons
      [StructLayout(LayoutKind.Sequential)]
      private struct SYSTEMTIME
      {

         [MarshalAs(UnmanagedType.U2)] public short Year;
         [MarshalAs(UnmanagedType.U2)] public short Month;
         [MarshalAs(UnmanagedType.U2)] public short DayOfWeek;

         public SYSTEMTIME(DateTime dateTime)
         {
            Year = (short) dateTime.Year;
            Month = (short) dateTime.Month;
            DayOfWeek = (short) dateTime.DayOfWeek;
         }

      }

      [DllImport("kernel32.dll", SetLastError = true)]
      private static extern bool SetSystemTime(ref SYSTEMTIME time);
      #endregion
   }

}