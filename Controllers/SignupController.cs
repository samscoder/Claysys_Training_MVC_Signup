using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignUp.Repository;
using SignUp.Models;

namespace SignUp.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllSignupsDetails()
        {
            SignupRepository signupRepo = new SignupRepository();
            ModelState.Clear();
            return View(signupRepo.GetAllSignups());
        }

        //GET: ADD SIGNUPS
        public ActionResult AddSignupDetail()
        {
            return View();
        }

        // POST: ADD SIGNUPS
        [HttpPost]
        public ActionResult AddSignupDetail(Signup signup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SignupRepository signupRepo = new SignupRepository();
                    if (signupRepo.AddSignup(signup))
                    {
                        ViewBag.Message = "User details added Successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //GET: EDIT SIGNUPS
        public ActionResult EditSignupDetails(int id)
        {
            SignupRepository signupRepo = new SignupRepository();

            return View(signupRepo.GetAllSignups().Find(Sign => Sign.Id == id));
        }

        //POST: EDIT SIGNUPS
        [HttpPost]
        public ActionResult EditSignupDetails(int id, Signup signup)
        {
            try
            {
                SignupRepository signupRepo = new SignupRepository();
                signupRepo.EditSignup(signup);

                return RedirectToAction("GetAllSignupsDetails");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteSignupDetails(int id)
        {
            try
            {
                SignupRepository signupRepo = new SignupRepository();
                if (signupRepo.DeleteSignup(id))
                {
                    ViewBag.AlertMsg = "Signup details deleted successfully";
                }
                return RedirectToAction("GetAllSignupsDetails");
            }
            catch
            {
                return View();
            }
        }
    }
}