using Microsoft.AspNetCore.Mvc;
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

        public TransactionsController(TransactionsSimulation context)
        {
            _context = context;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,originatorConversationId,amount,reference,channelType,customerAccountNo")] Transactions transactions)
        {
            var token = GetToken();

            if (ModelState.IsValid)
            {   
                _context.Add(transactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactions);
        }

        /*[HttpPost]
        public async Task<PaymentOrderDTO> MakeTransaction()
        {

        }
*/


        /// <summary>
        /// API
        /// </summary>


        [NonAction]
        public string GetToken()
        {
            var client = new RestClient("http://54.224.92.175:10001/");

            var request = new RestRequest("connect/token", Method.Post);
            request.AddParameter("client_id", "Flavian");
            request.AddParameter("client_secret", "a3cfa964-30ad-469a-b1e2-bdf220f69acc");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "PyPay_api");
            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                
            }
            var auth = JsonConvert.DeserializeObject<RequestTokenDTO>(response.Content!);

            return auth!.access_token;
        }


        [NonAction]
        public List<ChannelTypeDTO> GetRoutes(string auth)
        {
            var client = new RestClient("https://sandboxapi.zamupay.com/v1/");
            var request = new RestRequest("transaction-routes/assigned-routes", Method.Get);
            request.AddHeader("Authorization", "Bearer" + auth);
            RestResponse response = client.Execute(request);

            List<ChannelTypeDTO> selectItems = new List<ChannelTypeDTO>();


            var items = JsonConvert.DeserializeObject<RequestRoutesDTO>(response.Content);

            foreach (var route in items.routes)
            {

                foreach (var x in route.channelTypes)
                {
                    ChannelTypeDTO selectItem = new ChannelTypeDTO()
                    {
                        Text = x.channelDescription,
                        channelType = x.channelType.ToString(),
                        Value = route.id.ToString()
                    };

                    selectItems.Add(selectItem);
                }
            }
            return selectItems;
        }

        
    }
}
