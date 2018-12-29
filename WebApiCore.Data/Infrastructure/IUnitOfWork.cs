using System;
using WebApiCore.Data.Repositories;
using WebApiCore.Models.Domain;

namespace WebApiCore.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IPhotoRepository PhotoRepository { get; }
        IRepository<Tag> TagRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        void Complete();
    }
}
