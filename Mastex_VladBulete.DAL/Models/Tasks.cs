using System;
using System.Collections.Generic;

namespace Mastex_BuleteVlad.DAL.Models
{
    public partial class Tasks : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
    }
}
