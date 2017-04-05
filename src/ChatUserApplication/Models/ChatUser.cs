using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatUserApplication.Models
{
    public class ChatUser
    {
        public int ChatUserId { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
    }
}
