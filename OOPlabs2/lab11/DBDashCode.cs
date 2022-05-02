using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class DBDashCode : IDBRepository<Users>, IDBRepository<Chats>, IDBUnitOfWork
    {
        private DashCodeBDContext context;
        public DBDashCode()
        {
            context = new DashCodeBDContext();
        }

        public int Count => context.Users.Count();
        public DbSet<Users> Users => context.Users;
        public DbSet<Chats> Chats => context.Chats;
        public void Add(Users item)
        {
            context.Users.Add(item);
            //SaveChanges();
        }
        public void Update(Func<Users, bool> func, Func<int, Users> item)
        {
            //IEnumerable<Users> users = context.Users
            //.Where(func)
            //.Select(c => c.UserId)
            //.AsEnumerable()
            //.Select(item);

            //foreach (var user in users)
            //{
            //    context.Users.Attach(user);
            //    context.Entry(user)
            //        .Property(c => c.Name).IsModified = true;
            //}
            var user = context.Users.First(func);
            context.Entry(user).CurrentValues.SetValues(item(user.UserId));
            //SaveChanges();
        }
        public bool Remove(Func<Users, bool> func)
        {
            var toDel = context.Users.Where(func).ToList();
            if (toDel.Count > 0)
            {
                context.Users.RemoveRange(toDel);
                //SaveChanges();
                return true;
            }
            return false;
        }

        public void Add(Chats item)
        {
            context.Chats.Add(item);
            //SaveChanges();
        }
        public void Update(Func<Chats, bool> func, Func<int, Chats> item)
        {
            var chat = context.Chats.First(func);
            context.Entry(chat).CurrentValues.SetValues(item(chat.ChatId));
            //SaveChanges();
        }
        public bool Remove(Func<Chats, bool> func)
        {
            var toDel = context.Chats.Where(func).ToList();
            if (toDel.Count > 0)
            {
                context.Chats.RemoveRange(toDel);
                //SaveChanges();
                return true;
            }
            return false;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            SaveChanges();
        }
    }
}
