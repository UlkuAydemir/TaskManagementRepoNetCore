using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entitites
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }

        [StringLength(50)]
        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsCompleted { get; set; }

        public int TaskStatus { get; set; }

    }
}
