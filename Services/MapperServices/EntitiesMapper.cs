using AutoMapper;
using Domain.Entities;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MapperServices
{
    public  class EntitiesMapper:Profile 
    {
        public EntitiesMapper()
        {
            CreateMap<WalletDto, Wallet>();
            CreateMap<TransactionDto, Transaction>();
            CreateMap<UserDto, User>();
        }
    }
}
