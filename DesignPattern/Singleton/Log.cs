using System;
using System.IO;

namespace DesignPattern.Singleton
{
   public class Log
   {
      private readonly static Log _instance = new Log();
      private readonly string _path = "log.txt";

      public static Log Instance
      {
         get => _instance;
      }

      private Log()
      {

      }

      public void Save(string message)
      {
         File.AppendAllText(_path, message + Environment.NewLine);
      }
   }
}
