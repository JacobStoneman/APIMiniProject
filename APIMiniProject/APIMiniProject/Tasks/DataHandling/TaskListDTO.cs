using Newtonsoft.Json;

namespace APIMiniProject
{
    public class TaskListDTO
    {
        public TaskModel[] Tasks { get; set; }
        public void DeserialiseTask(string taskJsonString)
        {
            Tasks = JsonConvert.DeserializeObject<TaskModel[]>(taskJsonString);
        }
    }
}
