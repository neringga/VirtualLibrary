namespace VirtualLibrary.View
{
    public interface IBook
    {
        string Title { get; set; } //Auto-Implemented Properties
        string Author { get; set; }
        string Code { get; set; }
        int DaysForBorrowing { get; set; }
    }
}
