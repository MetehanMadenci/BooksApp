﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;

namespace BLL.Models
{
    public class AuthorsModel
    {
        public Author Record { get; set; } 
        public string Name => Record.Name;
    }
}
