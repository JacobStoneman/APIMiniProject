using Newtonsoft.Json;

namespace APIMiniProject
{
    public class TaskListDTO
    {
        public TaskModel[] Tasks { get; set; }
        public void DeserialiseTask(string taskJsonString, bool isArray)
        {
            if (isArray)
            {
                Tasks = JsonConvert.DeserializeObject<TaskModel[]>(taskJsonString);
            } else
			{
                Tasks = new TaskModel[1];
                Tasks[0] = JsonConvert.DeserializeObject<TaskModel>(taskJsonString);
            }
        }
    }
}
