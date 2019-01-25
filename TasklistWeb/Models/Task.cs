using System;

namespace TasklistWeb.Models {
    public class Task {
        public int TaskID { get; set; }
        public int PriorityID { get; set; }
        public int StatusID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //public bool Deleted { get; set; }

        public string PriorityName { get; set; }
        public string StatusName { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        //public virtual Priority Priority { get; set; }
        //public virtual Status Status { get; set; }
    }
}