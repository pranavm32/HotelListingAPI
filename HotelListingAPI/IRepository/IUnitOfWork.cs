using System;
using HotelListingAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListingAPI.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        public IGenericRepository<Country> Countries { get; }
        public IGenericRepository<Hotel> Hotels { get; }
        public Task Save();
    }
}
