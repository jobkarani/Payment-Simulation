using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payment_Simulation.Data;
using Payment_Simulation.Models;
using Payment_Simulation.Services;
using System.Linq.Dynamic.Core;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

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

            var data = _context.Set<Transactions>().AsQueryable();

            //get total count of data in table

            totalRecord = data.Count();

            // search data when search value found

            if (!string.IsNullOrEmpty(searchValue))
            {

                data = data.Where(x => x.dateCreated.ToLower().Contains(searchValue.ToLower())

                || x.Remitter.name.ToLower().Contains(searchValue.ToLower())

                || x.Remitter.primaryAccountNumber.ToLower().Contains(searchValue.ToLower())

                || x.Recipient.name.ToLower().Contains(searchValue.ToLower())

                || x.Recipient.primaryAccountNumber.ToLower().Contains(searchValue.ToLower())

                || x.channelType.ToString().Contains(searchValue.ToLower())

                || x.trackingNumber.ToLower().Contains(searchValue.ToLower())

                || x.statusDescription.ToLower().Contains(searchValue.ToLower())

                || x.amount.ToString().ToLower().Contains(searchValue.ToLower())

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

            return View();

        }

        // POST: Transactions/Create

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(TransactionsDTO transaction)
        {

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;


            Remitter domainRemitter = new Remitter();

            domainRemitter.address = transaction.RemitterAddress;

            domainRemitter.name = transaction.RemitterName;

            domainRemitter.phoneNumber = transaction.RemitterPhoneNumber;

            domainRemitter.idNumber = transaction.RecipientIdNumber;

            domainRemitter.financialInstitution = transaction.RecipientFinancialInstitution;

            domainRemitter.primaryAccountNumber = transaction.RemitterPrimaryAccountNumber;


            Recipient domainRecipient = new Recipient();

            domainRecipient.name = transaction.RecipientName;

            domainRecipient.address = transaction.RecipientAddress;

            domainRecipient.phoneNumber = transaction.RecipientPhoneNumber;

            domainRecipient.idNumber = transaction.RecipientIdNumber;

            domainRecipient.primaryAccountNumber = transaction.RecipientPrimaryAccountNumber;

            domainRecipient.emailAddress = transaction.RecipientEmailAddress;

            domainRecipient.financialInstitution = transaction.RecipientFinancialInstitution;


            Transactions domainTransaction = new Transactions();

            domainTransaction.Remitter = domainRemitter;

            domainTransaction.Recipient = domainRecipient;

            domainTransaction.routeId = transaction.routeId;

            domainTransaction.amount = transaction.amount;

            domainTransaction.reference = transaction.reference;

            domainTransaction.systemConversationId = transaction.systemConversationId;

            domainTransaction.originatorConversationId = transaction.originatorConversationId;

            domainTransaction.channelType = transaction.channelType;

            domainTransaction.channelTypeDescription = transaction.channelTypeDescription;

            domainTransaction.dateCreated = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            domainTransaction.feeAmount = 0.0;

            domainTransaction.resultCodeDescription = string.Empty;

            domainTransaction.statusDescription = string.Empty;

            domainTransaction.trackingNumber = string.Empty;


            // var token = GetToken();

            if (ModelState.IsValid)
            {
                _context.Add(domainTransaction);

                if (await _context.SaveChangesAsync() > 0)
                {

                    RecipientItem domainRecipientItem = new RecipientItem();

                    domainRecipientItem.name = transaction.RecipientName;

                    domainRecipientItem.address = transaction.RecipientAddress;

                    domainRecipientItem.phoneNumber = transaction.RecipientPhoneNumber;

                    domainRecipientItem.idNumber = transaction.RecipientIdNumber;

                    domainRecipientItem.emailAddress = transaction.RecipientEmailAddress;

                    domainRecipientItem.financialInstitution = transaction.RecipientFinancialInstitution;

                    domainRecipientItem.primaryAccountNumber = transaction.RecipientPrimaryAccountNumber;

                    domainRecipientItem.ccy = 404;

                    domainRecipientItem.country = "KE";

                    domainRecipientItem.mccmnc = "63902";


                    RemitterDetails domainRemitterItem = new RemitterDetails();

                    domainRemitterItem.name = transaction.RemitterName;

                    domainRemitterItem.address = transaction.RemitterAddress;

                    domainRemitterItem.phoneNumber = transaction.RemitterPhoneNumber;

                    domainRemitterItem.idNumber = transaction.RemitterIdNumber;

                    domainRemitterItem.financialInstitution = transaction.RemitterFinancialInstitution;

                    domainRemitterItem.primaryAccountNumber = transaction.RemitterPrimaryAccountNumber;


                    TransactionItem domainTransactionItem = new TransactionItem();

                    domainTransactionItem.routeId = transaction.routeId;

                    domainTransactionItem.ChannelType = transaction.channelType;

                    domainTransactionItem.amount = Convert.ToInt32(transaction.amount);

                    domainTransactionItem.reference = transaction.reference;

                    domainTransactionItem.systemTraceAuditNumber = Guid.NewGuid().ToString();


                    Paymentorderline domainRecipientDetails = new Paymentorderline();

                    domainRecipientDetails.recipient = domainRecipientItem;

                    domainRecipientDetails.remitter = domainRemitterItem;

                    domainRecipientDetails.transaction = domainTransactionItem;


                    PaymentRequestDTO domainPaymentOrderRequest = new PaymentRequestDTO();

                    domainPaymentOrderRequest.originatorConversationId = domainTransaction.originatorConversationId;

                    domainPaymentOrderRequest.paymentNotes = "Debt payment";

                    domainPaymentOrderRequest.paymentOrderLines = new List<Paymentorderline>

                    {

                        domainRecipientDetails

                    };

                    var client = new RestClient("https://sandboxapi.zamupay.com/v1/");

                    var request = new RestRequest("payment-order/new-order", Method.Post);

                    request.AddHeader("Content-Type", "application/json");

                    request.AddHeader("authorization", "Bearer " + token.Result);

                    request.AddParameter("application/json", JsonConvert.SerializeObject(domainPaymentOrderRequest), ParameterType.RequestBody);

                    RestResponse response = client.Execute(request);


                    if (response.IsSuccessful)
                    {
                        //Deserialize into an object

                        var result = JsonConvert.DeserializeObject<OrderRequestDTO>(response.Content);

                        transaction.systemConversationId = result.message.systemConversationId;

                        _context.Attach(domainTransaction);

                        _context.Entry(domainTransaction).State = EntityState.Modified;

                        _context.SaveChanges();


                        // Find Payment Order By originatorConversationId" end point

                        var originatorConversationId = result.message.originatorConversationId;


                        var idType = "OriginatorConversationId";

                        var Client = new RestClient("https://sandboxapi.zamupay.com/v1/");

                        var Request = new RestRequest("payment-order/check-status", Method.Get);

                        Request.AddHeader("authorization", "Bearer " + token.Result);

                        Request.AddParameter("id", originatorConversationId, ParameterType.QueryString);

                        Request.AddParameter("idType", idType, ParameterType.QueryString);

                        var Response = await Client.ExecuteAsync(Request);


                        //Deserialize into an object
                        var Outcome = JsonConvert.DeserializeObject<FindPaymentOrderDTO>(Response.Content);

                        //Update the database
                        domainTransaction.feeAmount = Outcome.orderLines[0].transactionOutcome.feeAmount;

                        domainTransaction.trackingNumber = Outcome.orderLines[0].transactionOutcome.trackingNumber;

                        domainTransaction.statusDescription = Outcome.orderLines[0].transactionOutcome.transactionStatusDescription;

                        _context.SaveChanges();

                    }

                }

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

            string client_id = "Flavian";

            string client_secret = "a3cfa964-30ad-469a-b1e2-bdf220f69acc";

            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={client_id}&client_secret={client_secret}", ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {

                var auth = JsonConvert.DeserializeObject<RequestTokenDTO>(response.Content);

                return auth.access_token;

            }

            else
            {

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

            RestResponse response = client.Execute(request);

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

        public async Task<IActionResult> GetDetails(int id)
        {

            Transactions transactions = await _context.Transactions.FindAsync(id);

            Console.WriteLine(id);

            return View(transactions);

        }

    }
}
