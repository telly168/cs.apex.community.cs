﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs.apex.community.domain.Model
{
    public class Community
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Player Owner { get; set; }

    }
}
