using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkerServiceApp.Model
{
    public class Test
    {

        [Key]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

    }
}
