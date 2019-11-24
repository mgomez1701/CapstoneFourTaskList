using System;
using System.Collections.Generic;

namespace CapstoneFourTaskLisk.Models
{
    public partial class TaskList
    {
        public int TaskId { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Complete { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
