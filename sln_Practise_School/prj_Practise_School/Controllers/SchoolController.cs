using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using prj_Practise_School.Models;
using prj_Practise_School.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace prj_Practise_School.Controllers
{
    public class SchoolController : Controller
    {
        private readonly Practise_SchoolContext db;
        private readonly IWebHostEnvironment environment;

        public SchoolController(Practise_SchoolContext context,IWebHostEnvironment p)
        {
            db = context;
            environment = p;
        }

        
       
        [HttpGet]
        public IActionResult JobTitle(jobTitleQueryModel model)
        {
            IEnumerable<TJobTitleIdToJobTitleName> jobTitles = null;
            if (string.IsNullOrEmpty(model.JobTitleID) && string.IsNullOrEmpty(model.JobTitleName))
            {
                jobTitles = from j in db.TJobTitleIdToJobTitleNames
                            select j;
            }
            else
            {
                jobTitles = db.TJobTitleIdToJobTitleNames.
                    Where(j => j.FJobTitleId.Contains(model.JobTitleID) || j.FJobTitleName.Contains(model.JobTitleName)).ToList();
            }
            
            return View(jobTitles);
        }

        [HttpPost]
        public IActionResult JobTitle(TJobTitleIdToJobTitleName model)
        {
            if (db.TJobTitleIdToJobTitleNames.FirstOrDefault(j=>j.FJobTitleId==model.FJobTitleId)!=null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    errorno = 1,
                    message = "id重複了"
                });
            }


            db.TJobTitleIdToJobTitleNames.Add(model);
            db.SaveChanges();


            return View(db.TJobTitleIdToJobTitleNames);
        }


        public IActionResult EditJobTitle(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("JobTitle");
            }

            var jobTitle = db.TJobTitleIdToJobTitleNames.FirstOrDefault(j => j.FJobTitleId == id);

            return View(jobTitle);
        }
        [HttpPost]
        public IActionResult EditJobTitle(TJobTitleIdToJobTitleName jEdit)
        {
            var jobTitle = db.TJobTitleIdToJobTitleNames.FirstOrDefault(j => j.FJobTitleId == jEdit.FJobTitleId);
            if (jobTitle != null)
            {
                jobTitle.FJobTitleName = jEdit.FJobTitleName;
                db.SaveChanges();
            }

            return RedirectToAction("JobTitle");
        }

        public IActionResult DeleteJobTitle(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var jobTitle = db.TJobTitleIdToJobTitleNames.FirstOrDefault(j => j.FJobTitleId == id);
                if (jobTitle!=null)
                {
                    db.TJobTitleIdToJobTitleNames.Remove(jobTitle);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("JobTitle");
        }


        public IActionResult Index()
        {
            return View();
        }


    }
}
