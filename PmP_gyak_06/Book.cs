namespace PmP_gyak_06
{
    class Book
    {
        private string Author;
        private string Title;
        private int Year;
        private int PageCount;

        public Book(string Author, string Title, int Year, int PageCount)
        {
            this.Author = Author;
            this.Title = Title;
            this.Year = Year;
            this.PageCount = PageCount;
        }

        public string AllData()
        {
            return $"{Author} - {Title} ({Year}) - {PageCount} oldal";

        }
    }
}
