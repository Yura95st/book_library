﻿using System;

namespace library_data_models.Models
{
    public class ReadersBook
    {
        public ReadersBook()
        { }

        public Book Book
        {
            get;
            set;
        }

        public DateTime ExpirationDate
        {
            get;
            set;
        }

        public int State
        {
            get;
            set;
        }
    }
}
 