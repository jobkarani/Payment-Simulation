using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment_Simulation.Models;
using Payment_Simulation.Services;

namespace Payment_Simulation.configAutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Transactions, PaymentOrderDTO>();
        }
    }
}
