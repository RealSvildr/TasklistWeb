using System;
using System.Collections.Generic;
using System.Linq;
using TasklistWeb.Models;

namespace TasklistWeb.Controllers {
    public class TaskController : BaseController {
        /* No Filter */
        public List<Task> GetList() {
            string sqlQuery = @"
                SELECT
                    A.TaskID,
                    A.PriorityID,
                    A.StatusID,
                    A.Name,
                    A.Description,
                    A.CreateDate,
                    PriorityName = B.Name,
                    StatusName = C.Name
                FROM
                    Task AS A WITH (NOLOCK)
                JOIN
                    Priority AS B WITH (NOLOCK) ON B.PriorityID = A.PriorityID
                JOIN
                    Status AS C WITH (NOLOCK) ON C.StatusId = A.StatusId
                WHERE
                    A.Deleted = 0
                ORDER BY
                    B.PriorityLevel DESC,
                    A.CreateDate
            ";


            return _dbContext.SqlQuery<Task>(sqlQuery);
        }

        public Task GetById(int taskId) {
            string sqlQuery = @"
                SELECT
                    TaskID,
                    PriorityID,
                    StatusID,
                    Name,
                    Description,
                    CreateDate
                FROM
                    Task WITH (NOLOCK)
                WHERE
                    TaskID = @p0
            ";


            return _dbContext.SqlQuery<Task>(sqlQuery, taskId).FirstOrDefault();
        }

        public void CreateUpdate(Task item) {
            if(item.TaskID == 0) {
                Create(item);
            } else {
                Update(item);
            }
        }

        public void Create(Task item) {
            string sqlQuery = @"
                INSERT INTO
                    Task
                (
                    PriorityID,
                    StatusID,
                    Name,
                    Description,
                    CreateDate,
                    Deleted
                ) VALUES (
                    @p0,
                    @p1,
                    @p2,
                    @p3,
                    @p4,
                    0
                )
            ";

            _dbContext.ExecuteSqlCommand(
               sqlQuery,
               item.PriorityID,
               item.StatusID,
               item.Name,
               item.Description,
               DateTime.Now
           );
        }

        public void Update(Task item) {
            string sqlQuery = @"
                UPDATE
                    Task
                SET
                    PriorityID = @p1,
                    StatusID = @p2,
                    Name = @p3,
                    Description = @p4
                WHERE
                    TaskID = @p0
            ";


            _dbContext.ExecuteSqlCommand(
                sqlQuery,
                item.TaskID,
                item.PriorityID,
                item.StatusID,
                item.Name,
                item.Description
            );
        }

        public void Delete(Task item) {
            string sqlQuery = @"
                UPDATE
                    Task
                SET
                    Deleted = 1,
                    DeleteDate = @p1
                WHERE
                    TaskID = @p0
            ";


            _dbContext.ExecuteSqlCommand(
                sqlQuery,
                item.TaskID,
                DateTime.Now
            );
        }
    }
}
