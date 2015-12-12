using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public VkUser vkUser { get; set; }
        public FacebookUser fbUser { get; set; }

    }
}
