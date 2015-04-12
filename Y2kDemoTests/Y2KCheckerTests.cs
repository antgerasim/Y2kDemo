using System;
using System.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
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
         using (ShimsContext.Create())
         {
            var sut = new Y2KChecker();

            ShimDateTime.NowGet = () => new DateTime(2000, 1, 1);

            sut.ThrowIfY2K();
         }

      }

   }

}