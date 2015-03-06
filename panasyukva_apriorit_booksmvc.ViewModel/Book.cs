using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using panasyukva_apriorit_booksmvc.DAL.Models;
using System.Data.Entity;

namespace panasyukva_apriorit_booksmvc.ViewModel
{
    class Book
    {
        private DbContext context;
        public int BookID { get; set; }
        public string BookName { get; set; }

        public Book()
        {
            context = new SelfEducationEntities();
        }
    }
}
