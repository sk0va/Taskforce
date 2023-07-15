using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taskforce.Domain.Interfaces;
using Taskforce.Db.Entities;
using Taskforce.Domain.Interfaces.Specifications;

namespace Taskforce.Db;

public class GenericRepository<TDomain, TDb> : IRepository<TDomain>
    where TDomain : Domain.Entities.Entity
    where TDb : DbEntity
{
    private readonly TaskforceDbContext _dbContext;

    private DbSet<TDb> DbSet => _dbContext.Set<TDb>();

    private readonly IMapper _mapper;

    public GenericRepository(
        IMapper mapper,
        TaskforceDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TDomain> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var dbEntity = await _dbContext.FindAsync<TDb>(id, ct);
        return _mapper.Map<TDb, TDomain>(dbEntity);
    }

    public async Task AddAsync(TDomain entity, CancellationToken ct)
    {
        var dbEntity = _mapper.Map<TDb>(entity);
        await _dbContext.AddAsync(dbEntity, ct);
    }

    public void Update(TDomain entity)
    {
        var dbEntity = _mapper.Map<TDb>(entity);
        DbSet.Update(dbEntity);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        DbSet.Remove(await _dbContext.FindAsync<TDb>(id, ct));
    }

    public IEntitySet<TDomain> With(ISpecification<TDomain> specification)
    {
        return new EntitySet<TDomain, TDb>(_dbContext, _mapper, specification);
    }
}
