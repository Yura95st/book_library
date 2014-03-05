using System.Collections.Generic;

namespace library_data_models.Models
{
    public class Reader
    {
        public Reader()
        { }

        public int Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public List<Penalty> Penalties
        {
            get;
            set;
        }

        public List<ReadersBook> Books
        {
            get;
            set;
        }
    }
}
