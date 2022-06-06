using MIS.Backend.Models;

namespace MIS.Backend.DataAccess.Repositories;

public class ConfigurationValueRepository : Repository<ConfigurationValue>
{
    public ConfigurationValueRepository(DatabaseContext dbContext) : base(dbContext, dbContext.ConfigurationValues) { }
}