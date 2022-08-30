using AutoMapper;
using Payment_Simulation.Models;
using Payment_Simulation.Services;

namespace Payment_Simulation.Profiles
{
    public class TransactionsAutoMapper: Profile
    {
        public TransactionsAutoMapper()
        {
            CreateMap<Transactions, TransactionsDTO>().ReverseMap();
            CreateMap<Recipient, TransactionsDTO>().ReverseMap();
            CreateMap<Remitter, TransactionsDTO>().ReverseMap(); 
        }
    }
}
