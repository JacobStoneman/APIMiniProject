using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class TaskModel
    {
        public long Id { get; set; }
        public int Assigner { get; set; }
        public long Project_id { get; set; }
        public int Section_id { get; set; }
        public int Order { get; set; }
        public string Content { get; set; }
        public bool Completed { get; set; }
        public object[] Label_ids { get; set; }
        public int Priority { get; set; }
        public int Comment_count { get; set; }
        public int Creator { get; set; }
        public DateTime Created { get; set; }
        public DueDate Due { get; set; }
        public string Url { get; set; }
    }

    public class DueDate
    {
        public bool Recurring { get; set; }
        public string String { get; set; }
        public string Date { get; set; }
        public DateTime Datetime { get; set; }
        public string Timezone { get; set; }
    }
}
