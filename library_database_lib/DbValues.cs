namespace library_database_lib
{
    public static class DbValues
    {
        // Table Names
        public static string TABLE_BOOKS = "books";
        public static string TABLE_BOOK_RATE = "book_rate";
        public static string TABLE_BOOK_LOCATION = "book_location";
        public static string TABLE_BOOK_AUTHORS = "book_authors";

        public static string TABLE_AUTHORS = "authors";
        
        public static string TABLE_PUBLISHERS = "publishers";
        
        public static string TABLE_READERS = "readers";
        public static string TABLE_READER_BOOKS = "reader_books";
        
        public static string TABLE_PENALTIES = "penalties";

        // BOOKS table - column names
        public static string BOOKS_COLUMN_ID = "book_id";
        public static string BOOKS_COLUMN_TITLE = "title";
        public static string BOOKS_COLUMN_TYPE = "type";
        public static string BOOKS_COLUMN_PUB_ID = "pub_id";
        public static string BOOKS_COLUMN_PUB_DATE = "pub_date";
        public static string BOOKS_COLUMN_ISNB = "isnb";

        // BOOK_RATE table - column names
        public static string BOOK_RATE_COLUMN_READER_ID = "reader_id";
        public static string BOOK_RATE_COLUMN_BOOK_ID = "book_id";
        public static string BOOK_RATE_COLUMN_RATE = "rate";

        // BOOK_LOCATION table - column names
        public static string BOOK_LOCATION_COLUMN_ROW_NUM = "row_num";
        public static string BOOK_LOCATION_COLUMN_SHELF_NUM = "shelf_num";
        public static string BOOK_LOCATION_COLUMN_CELL_NUM = "cell_num";
        public static string BOOK_LOCATION_COLUMN_BOOK_ID = "book_id";

        // BOOK_AUTHORS table - column names
        public static string BOOK_AUTHORS_COLUMN_BOOK_ID = "book_id";
        public static string BOOK_AUTHORS_COLUMN_AUTHOR_ID = "author_id";

        // AUTHORS table - column names
        public static string AUTHORS_COLUMN_AUTHOR_ID = "author_id";
        public static string AUTHORS_COLUMN_FIRST_NAME = "first_name";
        public static string AUTHORS_COLUMN_LAST_NAME = "last_name";

        // PUBLISHERS table - column names
        public static string PUBLISHERS_COLUMN_PUBLISHER_ID = "pub_id";
        public static string PUBLISHERS_COLUMN_NAME = "name";
        public static string PUBLISHERS_COLUMN_PHONE = "phone";
        public static string PUBLISHERS_COLUMN_ADDRESS = "address";
        public static string PUBLISHERS_COLUMN_CITY = "city";

        // READERS table - column names
        public static string READERS_COLUMN_READER_ID = "reader_id";
        public static string READERS_COLUMN_FIRST_NAME = "first_name";
        public static string READERS_COLUMN_LAST_NAME = "last_name";
        public static string READERS_COLUMN_PHONE = "phone";
        public static string READERS_COLUMN_ADDRESS = "address";
        public static string READERS_COLUMN_CITY = "city";

        // READER_BOOKS table - column names
        public static string READER_BOOKS_COLUMN_READER_ID = "reader_id";
        public static string READER_BOOKS_COLUMN_BOOK_ID = "book_id";
        public static string READER_BOOKS_COLUMN_EXP_DATE = "exp_date";
        public static string READER_BOOKS_COLUMN_STATE = "state";

        // PENALTIES table - column names
        public static string PENALTIES_COLUMN_PENALTY_ID = "penalty_id";
        public static string PENALTIES_COLUMN_READER_ID = "reader_id";
        public static string PENALTIES_COLUMN_TYPE = "type";
        public static string PENALTIES_COLUMN_EXP_DATE = "exp_date";
    }
}
