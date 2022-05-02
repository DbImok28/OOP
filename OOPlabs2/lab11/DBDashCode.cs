using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class DBDashCode
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
            context.SaveChanges();
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
            var user = context.Users.Where(func).First();
            context.Entry(user).CurrentValues.SetValues(item(user.UserId));
            context.SaveChanges();
        }
        public bool Remove(Func<Users, bool> func)
        {
            var toDel = context.Users.Where(func).ToList();
            if (toDel.Count > 0)
            {
                context.Users.RemoveRange(toDel);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Add(Chats item)
        {
            context.Chats.Add(item);
            context.SaveChanges();
        }
        public void Update(Func<Chats, bool> func, Func<int, Chats> item)
        {

            //var entity = Chats.Find(name);
            //if (entity == null)
            //{
            //    return;
            //}

            //IEnumerable<Chats> chats = context.Chats
            //.Where(func)
            //.Select(c => c.ChatId)
            //.AsEnumerable()
            //.Select(item);
            //Chats chat = context.Chats
            //.Where(func)
            //.Select(c => c.ChatId)
            //.AsEnumerable()
            //.Select(item).First();

            //foreach (var chat in chats)
            //{
            //    context.Chats.Attach(chat);
            //    //context.Entry(chat).State = EntityState.Modified;
            //    context.Entry(chat).Property(c => c.Name).IsModified = true;

            //}
            var chat = context.Chats.Where(func).First();
            context.Entry(chat).CurrentValues.SetValues(item(chat.ChatId));
            context.SaveChanges();

        }
        public bool Remove(Func<Chats, bool> func)
        {
            var toDel = context.Chats.Where(func).ToList();
            if (toDel.Count > 0)
            {
                context.Chats.RemoveRange(toDel);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
