﻿using AccessPointMap.Domain.AccessPoints;
using AccessPointMap.Domain.Identities;
using AccessPointMap.Infrastructure.Core.Abstraction;
using AccessPointMap.Infrastructure.MySql.Repositories;
using System.Threading.Tasks;

namespace AccessPointMap.Infrastructure.MySql
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccessPointMapDbContext _dbcontext;

        private IIdentityRepository _identityRepository;
        private IAccessPointRepository _accessPointRepository;

        public IIdentityRepository IdentityRepository
        {
            get
            {
                if (_identityRepository is null)_identityRepository = new IdentityRepository(_dbcontext);

                return _identityRepository;
            }
        }

        public IAccessPointRepository AccessPointRepository
        {
            get
            {
                if (_accessPointRepository is null) _accessPointRepository = new AccessPointRepository(_dbcontext);

                return _accessPointRepository;
            }
        }

        public async Task Commit()
        {
            _ = await _dbcontext.SaveChangesAsync(); 
        }
    }
}
