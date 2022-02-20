using System;
using HotelListingAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListingAPI.IRepository
{
    interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        public IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
