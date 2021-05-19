using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;

namespace TheModernBibliotheca._Code.App.Librarian.Books
{
    public class InstancesRepository
    {
        public static IEnumerable<InstancesViewModel> GetNotInCirculation(string ISBN)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Where(e=> ! e.InCirculation && e.ISBN == ISBN ).Select(e => new InstancesViewModel
                {
                    InstanceID = e.InstanceID.ToString()
                  
                }).ToList();
            }


        }
        public static IEnumerable<InstancesViewModel> GetInCirculation(string ISBN)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                return context.BookInstances.Where(e => e.InCirculation && e.ISBN == ISBN).Select(e => new InstancesViewModel
                {
                    InstanceID = e.InstanceID.ToString()

                }).ToList();
            }


        }
        public static void AddInstance(int qty, BookInstance instance)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                for (int i = 0; i < qty; i++)
                {
                    context.BookInstances.Add(instance);
                    context.SaveChanges();
                }

                
            }
        }
        public static void RemoveInCirculation(int instanceid)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var borrow = context.BookInstances.FirstOrDefault(b => b.InstanceID == instanceid);
                borrow.InCirculation = false;
                context.SaveChanges();
            }
        }
        public static void AddInCirculation(int instanceid)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var borrow = context.BookInstances.FirstOrDefault(b => b.InstanceID == instanceid);
                borrow.InCirculation = true;
                context.SaveChanges();
            }
        }
    }
}