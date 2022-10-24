using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entitites;

namespace TaskManager.DataAccess.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        public async Task<Entitites.Task> CreateTaskAsync(Entitites.Task task)
        {
            using (var taskDbContext = new TaskDbContext())
            {
                taskDbContext.Tasks.Add(task);
                await taskDbContext.SaveChangesAsync();
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

        public Entitites.Task GetTaskById(int id)
        {
            using (var taskDbContext = new TaskDbContext())
            {
                return taskDbContext.Tasks.Find(id);
            }
        }

        public async Task<List<Entitites.Task>> GetAllTasksAsync()
        {
            using (var taskDbContext = new TaskDbContext())
            {
                return await taskDbContext.Tasks.ToListAsync();
            }
        }

        public Entitites.Task UpdateTask(Entitites.Task task)
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
