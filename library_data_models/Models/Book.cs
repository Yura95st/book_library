using System;
using System.Collections.Generic;

namespace library_data_models.Models
{
    public class Book
    {
        public Book()
        { }

        public int Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public Publisher Publisher
        {
            get;
            set;
        }

        public DateTime pubDate
        {
            get;
            set;
        }

        public List<Author> Authors
        {
            get;
            set;
        }

        public Location Location
        {
            get;
            set;
        }
        public string Isnb
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }
    }
}
