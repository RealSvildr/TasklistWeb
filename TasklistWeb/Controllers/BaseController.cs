using Microsoft.AspNetCore.Mvc;
using SqlMinimal;

namespace TasklistWeb.Controllers {
    public partial class BaseController : Controller {
        internal DBContext _dbContext = new DBContext("LAPTOP-530LI779\\SQLEXPRESS", "Tasklist");
    }
}