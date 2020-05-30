using System;
using System.Collections.Generic;

namespace Mastex_BuleteVlad.DAL.Models
{
    public partial class Projects : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
    }
}
