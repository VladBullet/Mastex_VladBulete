﻿using System;
using System.Collections.Generic;

namespace Mastex_BuleteVlad.DAL.Models
{
    public partial class Users : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool Deleted { get; set; }
    }
}
