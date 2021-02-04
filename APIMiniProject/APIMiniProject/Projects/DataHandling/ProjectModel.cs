using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class ProjectRoot
    {
        public Project[] AllProject { get; set; }
    }

    public class Project
    {
        public long Id { get; set; }
        public int Color { get; set; }
        public string Name { get; set; }
        public int Comment_count { get; set; }
        public bool Shared { get; set; }
        public bool Favorite { get; set; }
        public int Sync_id { get; set; }
        public bool Inbox_project { get; set; }
        public int Order { get; set; }
        public long Parent_id { get; set; }
    }
}
