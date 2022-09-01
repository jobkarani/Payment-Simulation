﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payment_Simulation.Data;
using Payment_Simulation.Models;
using Payment_Simulation.Services;
using System.Linq.Dynamic.Core;
using RestSharp;
using Newtonsoft.Json;

namespace Payment_Simulation.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionsSimulation _context;
        public Task<string> token;

        public TransactionsController(TransactionsSimulation context)
        {
            _context = context;
            token = GetToken();
        }

        // GET: Transactions/Table
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GetTransactions()
        {
            int totalRecord = 0;
            int filterRecord = 0;
            var draw = Request.Form["draw"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var data = _context.Set<Models.Transactions>().AsQueryable();
            //get total count of data in table
            totalRecord = data.Count();
            // search data when search value found
            if (!string.IsNullOrEmpty(searchValue))
            {
                data = data.Where(x => x.Id.ToString().Contains(searchValue.ToLower())
                || x.Remitter.name.ToString().Contains(searchValue.ToLower())
                || x.amount.ToString().Contains(searchValue.ToLower())
                || x.customerAccountNo.ToString().Contains(searchValue.ToLower())
                || x.reference.ToLower().Contains(searchValue.ToLower())
                );
            }


            // get total count of records after search
            filterRecord = data.Count();

            //sort data
            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection)) data = data.OrderBy(sortColumn + " " + sortColumnDirection);

            //pagination
            var empList = data.Skip(skip).Take(pageSize).ToList();
            var returnObj = new
            {
                draw = draw,
                recordsTotal = totalRecord,
                recordsFiltered = filterRecord,
                data = empList
            };

            return Ok(returnObj);
        }


        

        // GET: Transactions/Create
        public async Task<IActionResult> Create()
        {
            // await GetRoutes();
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionsDTO transaction)
        {
            Remitter domainRemitter = new Remitter();
            domainRemitter.address = transaction.address;
            domainRemitter.name = transaction.name;
            domainRemitter.idNumber = transaction.phoneNumber;
            domainRemitter.phoneNumber = transaction.phoneNumber;

            Recipient domainRecipient = new Recipient();
            domainRecipient.address= transaction.address;
            domainRecipient.phoneNumber = transaction.phoneNumber;
            domainRecipient.idNumber = transaction.idNumber;
            domainRecipient.primaryAccountNumber = transaction.primaryAccountNumber;
            domainRecipient.emailAddress = transaction.emailAddress;
            domainRecipient.financialInstitution = transaction.financialInstitution;


            Transactions domainTransaction = new Transactions();
            domainTransaction.originatorConversationId   = transaction.originatorConversationId;
            domainTransaction.amount = domainTransaction.amount;
            domainTransaction.reference = domainTransaction.reference;
            domainTransaction.channelType = domainTransaction.channelType;
            domainTransaction.customerAccountNo = domainTransaction.customerAccountNo;
            domainTransaction.Id = domainTransaction.Id;
            domainTransaction.Remitter = domainRemitter;
            domainTransaction.Recipient = domainRecipient;

            // var token = GetToken();

            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }




        /// <summary>
        /// API
        /// </summary>

       

        [NonAction]
        public async Task<string> GetToken()
        {
            var client = new RestClient("http://54.224.92.175:10001/");

            var request = new RestRequest("connect/token", Method.Post);

            string client_id = "Flavian"  ;
            string client_secret = "a3cfa964-30ad-469a-b1e2-bdf220f69acc"     ;

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={client_id}&client_secret={client_secret}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var auth = JsonConvert.DeserializeObject<RequestTokenDTO>(response.Content);
                return auth.access_token;
            }
            else{
                Console.WriteLine("Authorization token request failed with the following error: @{Error}", response.Content);
                throw new Exception(response.Content);
            }
            
        }


        [HttpGet]
        public async Task<JsonResult> GetRoutes()
        {
            var client = new RestClient("https://sandboxapi.zamupay.com/v1/");
            var request = new RestRequest("transaction-routes/assigned-routes", Method.Get);
            request.AddHeader("Authorization", "Bearer " + token.Result);
            RestResponse response =  client.Execute(request);

            List<ChannelTypeDTO> selectItems = new List<ChannelTypeDTO>();


            var items = JsonConvert.DeserializeObject<RequestRoutesDTO>(response.Content);

            foreach (var route in items.routes)
            {

                foreach (var type in route.channelTypes)
                {
                    ChannelTypeDTO selectItem = new ChannelTypeDTO()
                    {
                        Text = type.channelDescription,
                        channelType = type.channelType.ToString(),
                        Value = route.id.ToString()
                    };

                    selectItems.Add(selectItem);
                }
            }
            return Json(selectItems);
        }
    
    }

     public class PaymentOrderRequest{
            public string originatorConversationId {get; set;}
            public string paymentNotes{get; set;}
            public List<Recipient> paymentOrderLines{get; set;}
        }

        public class RecipientDetails{
            public RecipientItem recipient{get; set;}
            public TransactionItem transaction{get; set;}
        }

        public class RecipientItem{
            public string name { get; set; }
            public string address { get; set; }
            public string emailAddress { get; set; }
            public string phoneNumber { get; set; }
            public string idType { get; set; }
            public string idNumber { get; set; }
            public string financialInstitution { get; set; }
            public string primaryAccountNumber { get; set; }
            public string mccmnc { get; set; }
            public int ccy { get; set; }
            public string country { get; set; }
            public string purpose { get; set; }
        }

        public class TransactionItem{
            public string routeId { get; set; }
            public int ChannelType { get; set; }
            public int amount { get; set; }
            public string reference { get; set; }
            public string systemTraceAuditNumber { get; set; }
        }
}
