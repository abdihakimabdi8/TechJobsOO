using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            Job newJob = new Job();
            return View(newJob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        [Route("/Job/Index/{id}")]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if(ModelState.IsValid)
            {
                    Job newJob = new Job
                    {
                        Name = newJobViewModel.Name,
                        Employer = newJobViewModel.Employer,
                        Location = newJobViewModel.Location,
                        CoreCompetency = newJobViewModel.CoreCompetency,
                        PositionType = newJobViewModel.PositionType
                    };
                jobData.Jobs.Add(newJob);
           
            }
           
            return View(newJobViewModel);
            //Redirect("/Job");
            
        }
        // TODO #6 - Validate the ViewModel and if valid, create a 
        // new Job and add it to the JobData data store. Then
        // redirect to the Job detail (Index) action/view for the new Job.
     
    }
}
