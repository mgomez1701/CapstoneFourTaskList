using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneFourTaskLisk.Models
{
    public class TaskList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TaskId { get; set; }

        [Required]
        [MaxLength (450)]
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        
        public bool Complete { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }

        public TaskList() 
        {

        }
        public TaskList(int taskId, string taskDescription, DateTime dueDate, bool complete, string userId)
        {
            TaskId = taskId;
            TaskDescription = taskDescription;
            DueDate  = dueDate;
            Complete = complete;
            UserId = userId;
        }
    }
}
