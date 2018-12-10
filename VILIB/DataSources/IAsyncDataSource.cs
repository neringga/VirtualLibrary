using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.View;
using VILIB.FaceRecognision;
using VILIB.Helpers;

namespace VILIB.DataSources
{
    public interface IAsyncDataSource
    {
        string CurrUser { get; set; }
        IList<IBook> GetBookList();
        IList<IUser> GetUserList();
        IList<Reviews> GetReviewList();
        IList<IBook> GetTakenBookList();
        List<FaceImage> GetFaceImageList();
        IList<string> GetHashtagList();
        IList<string> GetGenreList();
        Task<int> RemoveUser(IUser user);
        Task<int> AddUser(IUser user);
        Task<int> RemoveBook(IBook book);
        Task<int> AddBook(IBook book);
        Task<int> AddReview(Reviews review);
        Task<int> RemoveReview(Reviews review);
        Task<int> AddFaceImage(FaceImage faceImage);
        Task<int> RemoveFaceImages(string Nickname);

        Task<bool> TakeBook(string isbnCode, string username);
        Task<bool> ReturnBook(string isbnCode, string username);

        //TODO: decide which to keep - generic implementations or concrete
        Task<int> RemoveItem<T>(T item);
    }
}