using Dapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Oracle.ManagedDataAccess.Client;

using System.Collections.Generic;
using System.Data;
using System.Linq;

using Versioning.App.Models;


namespace Versioning.App.Controllers
{
    public class MainController : Controller
    {
        // GET: Get List


        public static void GetListDB(IDbConnection connection)
        {
            const string listquery = @" SELECT * FROM VER_MAIN ";

            var result = connection.Query<VER_MAIN>(listquery).ToList();

        }
        public ActionResult Index()
        {
            var configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var DBconnection = configurationRoot.GetConnectionString("DBconnection");

            List<VER_MAIN> VersionList = new List<VER_MAIN>();

            //using (IDbConnection db = new OracleConnection("Data Source=(description=(address=(protocol=tcp)(host=192.168.20.120)(port=1521))(connect_data=(service_name=cbrm)));user id=scott;password=s123;"))
            using (IDbConnection db = new OracleConnection(DBconnection))
            {
                VersionList = db.Query<VER_MAIN>(@" SELECT * FROM VER_MAIN ").ToList();
            }
            return View(VersionList);
        }

        // GET: MainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
