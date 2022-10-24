using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entitites;

namespace TaskManager.DataAccess.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        public Task CreateTask(Task task)
        {
            using (var taskDbContext = new TaskDbContext())
            {
                taskDbContext.Tasks.Add(task);
                taskDbContext.SaveChanges();
                return task;
            }
        }

        public void DeleteTask(int id)
        {
            using (var taskDbContext = new TaskDbContext())
            {
                var deletedTask = GetTaskById(id);
                taskDbContext.Tasks.Remove(deletedTask);
                taskDbContext.SaveChanges();
            }
        }

        public Task GetTaskById(int id)
        {
            using (var taskDbContext = new TaskDbContext())
            {
                return taskDbContext.Tasks.Find(id);
            }
        }

        public List<Task> GetAllTasks()
        {
            using (var taskDbContext = new TaskDbContext())
            {
                return taskDbContext.Tasks.ToList();
            }
        }

        public Task UpdateTask(Task task)
        {
            using (var taskDbContext = new TaskDbContext())
            {
                taskDbContext.Tasks.Update(task);
                taskDbContext.SaveChanges();
                return task;
            }
        }
    }
}
