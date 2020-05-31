﻿using Mastex_BuleteVlad.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastex_BuleteVlad.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
    }
}
