using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class TaskDTO
    {
        public TaskModel Task { get; set; }
        public void DeserialiseTask(string taskJsonString)
        {
            Task = JsonConvert.DeserializeObject<TaskModel>(taskJsonString);
        }
    }
}
