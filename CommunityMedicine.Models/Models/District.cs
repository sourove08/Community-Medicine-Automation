﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class District
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public virtual List<Thana> Thanas { set; get; }
    }
}
