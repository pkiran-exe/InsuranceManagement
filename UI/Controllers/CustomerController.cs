using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using UI.Models;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        private InsuranceDbContext dbContext;
        public CustomerController()
        {
            dbContext = new InsuranceDbContext(); // Initialize your DbContext
        }
        // GET: Customer
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult GetAllCustomers()
        {
            var customers = dbContext.Customers.ToList();
            return View(customers);
        }

        // Action method to get all users
        public ActionResult GetAllUsers()
        {
            var users = dbContext.Customers.ToList(); // Assuming users are stored in the same table as customers
            return View(users);
        }



        ////


        public ActionResult ViewPoliciesToApply()
        {
            List<Policy> policies = dbContext.Policies.ToList();
            return View(policies);
        }

        
        public ActionResult Apply(int policyId)
        {
            // Replace the logic below with your code to get the actual customer ID
            int customerId = 3;

            // Check if the customer has already applied for the policy
            bool alreadyApplied = dbContext.AppliedPolicies
                .Any(ap => ap.CustomerId == customerId && ap.AppliedPolicyId == policyId);

            if (!alreadyApplied)
            {
                // Retrieve the policy details
                Policy policy = dbContext.Policies.FirstOrDefault(p => p.PolicyId == policyId);

                if (policy != null)
                {
                    // Create an AppliedPolicy object
                    AppliedPolicy appliedPolicy = new AppliedPolicy
                    {
                        PolicyNumber = policy.PolicyNumber,
                        AppliedDate = DateTime.Now,
                        Category = policy.Category,
                        CustomerId = customerId
                    };

                    // Add the applied policy to the database
                    dbContext.AppliedPolicies.Add(appliedPolicy);
                    dbContext.SaveChanges();
                }
                else
                {
                    // Handle the case where the policy with the specified ID doesn't exist
                    // You might want to add logging or return an appropriate response to the user.
                }
            }

            // Redirect to the action that shows applied policies
            return RedirectToAction("AppliedPolicies");
        }


        



        public ActionResult AppliedPolicies()
        {
            // Assuming you have a CustomerId to identify the customer
            // Replace 1 with the actual CustomerId or logic to get the customer
            int customerId = 3;

            // Retrieve applied policies for the customer from the database
            List<Policy> appliedPolicies = dbContext.Policies
                .Where(cp => cp.CustomerId == customerId)
                .ToList();

            return View(appliedPolicies);
        }


        //////
        ///

        public ActionResult Categories()
        {
            var categories = dbContext.Categories.ToList();
            return View(categories);
        }


        /// <summary>
        /// ////////////////
        /// </summary>
        /// <returns></returns>
        /// 


        public ActionResult AskQuestion()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AskQuestion(QuestionView questionView)
        {
            if (ModelState.IsValid)
            {
                // Create a new Questions entity
                Questions newQuestion = new Questions
                {
                    Question = questionView.Question,
                    Date = questionView.Date,
                    Answer = questionView.Answer,
                    CustomerId = questionView.CustomerId
                };

                // Add the new question to the database
                dbContext.Questions.Add(newQuestion);
                dbContext.SaveChanges();

                // Redirect to a success page or display a success message
                return RedirectToAction("Success");
            }

            // If ModelState is not valid, return to the AskQuestion view with the validation errors
            return View(questionView);
        }


        public ActionResult Success()
        {
            return View();
        }

        // Add any other actions or methods as needed

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }




        public ActionResult AskCustomerId()
        {
            return View();
        }

        // Action method to display questions for the specified customer ID
        [HttpPost]
        public ActionResult DisplayQuestionsByCustomerId(int? customerId)
        {
            // Check if customerId is null
            if (!customerId.HasValue)
            {
                // Handle the case when customerId is null, for example, redirect to an error page or return a specific view
                return RedirectToAction("Error");
            }

            // Retrieve all questions associated with the specified customerId
            var questions = dbContext.Questions.Where(q => q.CustomerId == customerId.Value).ToList();

            // Pass the list of questions and customer ID to the view
            ViewBag.CustomerId = customerId.Value;
            return View(questions);
        }

    }
















}
