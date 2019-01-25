using System.Collections.Generic;
using System.Linq;
using TasklistWeb.Models;

namespace TasklistWeb.Controllers {
    public class PriorityController : BaseController {
        /* No Filter */
        public List<Priority> GetList() {
            string sqlQuery = @"
                SELECT
                    PriorityID,
                    PriorityLevel,
                    Name,
                    Description
                FROM
                    Priority
            ";


            return _dbContext.SqlQuery<Priority>(sqlQuery);
        }

        public Priority GetById(int priorityID) {
            string sqlQuery = @"
                SELECT
                    PriorityID,
                    PriorityLevel,
                    Name,
                    Description
                FROM
                    Priority
                WHERE
                    PriorityID = @p0
            ";


            return _dbContext.SqlQuery<Priority>(sqlQuery, priorityID).FirstOrDefault();
        }

        
        public void CreateUpdate(Priority item) {
            if (item.PriorityID == 0) {
                Create(item);
            } else {
                Update(item);
            }
        }

        public void Create(Priority item) {
            string sqlQuery = @"
                INSERT INTO
                    Priority
                (
                    PriorityLevel,
                    Name,
                    Description
                ) VALUES (
                    @p0,
                    @p1,
                    @p2
                )
            ";

            _dbContext.ExecuteSqlCommand(
               sqlQuery,
               item.PriorityLevel,
               item.Name,
               item.Description
           );
        }

        public void Update(Priority item) {
            string sqlQuery = @"
                UPDATE
                    Priority
                SET
                    PriorityLevel = @p1,
                    Name = @p2,
                    Description = @p3
                WHERE
                    PriorityID = @p0
            ";


            _dbContext.ExecuteSqlCommand(
                sqlQuery,
                item.PriorityID,
                item.PriorityLevel,
                item.Name,
                item.Description
            );
        }

        public void Delete(Priority item) {
            string sqlQuery = @"
                DELETE FROM
                    Priority
                WHERE
                    PriorityID = @p0
            ";

            _dbContext.ExecuteSqlCommand(sqlQuery, item.PriorityID);
        }
    }
}
