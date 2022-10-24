using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Abstract;
using TaskManager.DataAccess.Concrete;
using TaskManager.Entitites;

namespace TaskManager.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private ITaskRepository _taskRepository;
        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public Task<Entitites.Task> CreateTaskAsync(Entitites.Task task)
        {
            task.CreateTime = DateTime.Now;
            return _taskRepository.CreateTaskAsync(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }

        public Task<List<Entitites.Task>> GetAllTasksAsync()
        {
            return _taskRepository.GetAllTasksAsync();
        }

        public Entitites.Task GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public Entitites.Task UpdateTask(Entitites.Task task)
        {
            return _taskRepository.UpdateTask(task);
        }
    }
}
