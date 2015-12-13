using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Entity
{
   public class Credentials
    {
      public string VkLogin { get; set; }
      public string VkPassword { get; set; }

      public string SkypeLogin { get; set; }
      public string SkypePassword { get; set; }

      public string EmailLogin { get; set; }
      public string EmailPassword { get; set; }

      public string WhatsLogin { get; set; }
      public string WhatsPassword { get; set; }
    }
}
