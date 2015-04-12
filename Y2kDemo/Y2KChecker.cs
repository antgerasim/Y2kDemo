using System;

namespace Y2kDemo
{

   public class Y2KChecker
   {

      public void ThrowIfY2K()
      {
         if (DateTime.Now == new DateTime(2000, 1, 1)) { throw new Y2KException(); }
      }

   }

}