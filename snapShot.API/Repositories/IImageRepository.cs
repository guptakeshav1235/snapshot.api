using snapShot.API.Models.Domain;

namespace snapShot.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UplaodImageAsync(Image image);
    }
}
