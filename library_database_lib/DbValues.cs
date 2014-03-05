namespace library_database_lib
{
    public static class DbValues
    {
        // Table Names
        public static string TABLE_BOOKS = "books";
        public static string TABLE_BOOK_RATE = "book_rate";
        public static string TABLE_BOOK_LOCATION = "book_location";
        public static string TABLE_BOOK_AUTHORS = "book_authors";

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
    }
}
