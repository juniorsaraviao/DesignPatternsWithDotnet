using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Tools.Generator
{
   public class Generator
   {
      public List<string> Content { get; set; }
      public string Path { get; set; }
      public TypeFormat Format { get; set; }
      public TypeCharacter Character { get; set; }

      public void Save()
      {
         string result = "";
         result = Format == TypeFormat.Json ? GetJson() : GetPipe();
         switch(Character) {
            case TypeCharacter.Uppercase:
               result.ToUpper();
               break;
            case TypeCharacter.Lowercase:
               result.ToLower();
               break;
         }

         File.WriteAllText(Path, result);
      }

      string GetJson()
      {
         return JsonSerializer.Serialize(Content);
      }

      string GetPipe()
      {
         return Content.Aggregate((accum, current) => $"{accum}|{current}");
      }
   }
}
