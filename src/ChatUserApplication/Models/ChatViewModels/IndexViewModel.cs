using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatUserApplication.Models.ChatViewModels
{
    public class IndexViewModel
    {
        [Required]
        public int ChatUserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
