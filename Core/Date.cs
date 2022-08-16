using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Date
    {
        [Key]
        public int DateId { get; set; }
        public int DateNumber { get; set; }
    }
}
