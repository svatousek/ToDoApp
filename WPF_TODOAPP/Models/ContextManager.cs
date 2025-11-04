using Microsoft.EntityFrameworkCore;
using WPF_TODOAPP.Database;

namespace WPF_TODOAPP.Models
{
    public class ContextManager // Create Read Update Delete (CRUD)
    {
        private readonly ToDoContext _context;

        public ContextManager(ToDoContext context)
        {
            _context = context;
        }

        public void Add(ToDoEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(ToDoEntity entity) { 
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ToDoEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public ToDoEntity? GetById(int id)
        {
            ToDoEntity? entity = _context.Find<ToDoEntity>(id);
            if (entity == null) 
                throw new Exception("Entity does not exists!!!");
            return entity;
        }


        public List<ToDoEntity> GetAll() => _context.Set<ToDoEntity>().ToList();
    }
}
