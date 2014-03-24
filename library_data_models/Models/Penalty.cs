﻿using System;

namespace library_data_models.Models
{
    public class Penalty
    {
        public Penalty()
        { }

        public int Id
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public int State
        {
            get;
            set;
        }

        public DateTime ExpirationDate
        {
            get;
            set;
        }
    }
}
 