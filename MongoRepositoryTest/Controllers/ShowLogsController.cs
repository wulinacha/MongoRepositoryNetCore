using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoRepository;

namespace MongoRepositoryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowLogsController : ControllerBase
    {
        public MongoRepository<LogItem> _logMongo;
        public ShowLogsController(MongoRepository<LogItem> mongo) {
            _logMongo = mongo;
        }
        [HttpGet]
        public dynamic GetLog() {
            var query = _logMongo.Where(it => it.DateTime >= DateTime.Now.AddDays(-1) && it.DateTime < DateTime.Now);
            var count = query.Count();
            return count;
        }
    }
}