using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entitites;

namespace TaskManager.DataAccess.Abstract
{
    public interface ITaskRepository
    {
        List<Task> GetAllTasks();

        Task GetTaskById(int id);

        Task CreateTask(Task task);

        Task UpdateTask(Task task);

        void DeleteTask(int id);

    }
}
