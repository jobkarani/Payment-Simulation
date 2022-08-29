using AutoMapper;
using Payment_Simulation.Models;
using Payment_Simulation.Services;
using System.Transactions;

namespace Payment_Simulation.Profiles
{
    public class TransactionsAutoMapper: Profile
    {
        public TransactionsAutoMapper()
        {
            CreateMap<Transactions, PaymentOrderDTO>().ReverseMap();
            CreateMap<Recipient, PaymentOrderDTO>().ReverseMap();
            CreateMap<Remitter, PaymentOrderDTO>().ReverseMap(); 
        }
    }
}
