using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entitites;

namespace TaskManager.Business.Abstract
{
    public interface ITaskService
    {
        Task<List<Entitites.Task>> GetAllTasksAsync();

        Entitites.Task GetTaskById(int id);

        Task<Entitites.Task> CreateTaskAsync(Entitites.Task task);

        Entitites.Task UpdateTask(Entitites.Task task);

        void DeleteTask(int id);

    }
}
