using System.Collections.Generic;
using WebApiCore.Data.Infrastructure;
using WebApiCore.Models.Domain;

namespace WebApiCore.Data.Repositories
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Photo GetPhotoWithTags(object photoId);
        IEnumerable<Photo> GetPhotosWithTags(object memberid);
    }
}
