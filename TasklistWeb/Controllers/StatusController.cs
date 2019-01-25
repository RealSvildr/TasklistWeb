using System.Collections.Generic;
using System.Linq;
using TasklistWeb.Models;

namespace TasklistWeb.Controllers {
    public class StatusController : BaseController {
        /* No Filter */
        public List<Status> GetList() {
            string sqlQuery = @"
                SELECT
                    StatusID,
                    Name,
                    Description
                FROM
                    Status
            ";


            return _dbContext.SqlQuery<Status>(sqlQuery);
        }

        internal Status GetById(int statusID) {
            string sqlQuery = @"
                SELECT
                    StatusID,
                    Name,
                    Description
                FROM
                    Status
                WHERE
                    StatusID = @p0
            ";


            return _dbContext.SqlQuery<Status>(sqlQuery, statusID).FirstOrDefault();
        }
    }
}
