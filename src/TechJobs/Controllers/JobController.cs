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
            Job newJob =  jobData.Find(id);

            return View(newJob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        //[Route("/Job/{id}")]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if(ModelState.IsValid)
            {
                    Job newJob = new Job
                    {
                        Name = newJobViewModel.Name,
                        Employer = jobData.Find(newJobViewModel.EmployerID).Employer,
                        Location = jobData.Find(newJobViewModel.Location).Location,
                        CoreCompetency = jobData.Find(newJobViewModel.CoreCompetency).CoreCompetency,
                        PositionType = jobData.Find(newJobViewModel.PositionType).PositionType
                    };
                jobData.Jobs.Add(newJob);
                return Redirect("/Job/?=" + newJob.ID);
            }
           
            return View(newJobViewModel);
        }
        // TODO #6 - Validate the ViewModel and if valid, create a 
        // new Job and add it to the JobData data store. Then
        // redirect to the Job detail (Index) action/view for the new Job.
       
    }
}
