using Microsoft.EntityFrameworkCore;
using WhatCanICook.Persistence.DatabaseContext;

namespace WhatCanICook.Persistence.IntegrationTests; 
public class CookDatabaseContextTests {

    private readonly CookDatabaseContext _cookDatabaseContext;
    public CookDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<CookDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _cookDatabaseContext = new CookDatabaseContext(dbOptions);
    }

 }