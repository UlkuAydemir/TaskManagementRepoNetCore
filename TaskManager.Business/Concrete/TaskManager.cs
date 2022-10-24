using System;
using System.Collections.Generic;
using System.Text;
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
        public Task CreateTask(Task task)
        {
            task.CreateTime = DateTime.Now;
            return _taskRepository.CreateTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }

        public List<Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public Task GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public Task UpdateTask(Task task)
        {
            return _taskRepository.UpdateTask(task);
        }
    }
}
