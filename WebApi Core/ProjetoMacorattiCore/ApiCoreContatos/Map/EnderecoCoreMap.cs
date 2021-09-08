using ApiCoreContatos.Models;
using ApiCoreContatos.Poco;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreContatos.Map
{
    public class EnderecoCoreMap : AncestralMap
    {
        public EnderecoCoreMap()
        {
            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<EnderecoCore, EnderecoCorePoco>();
                cfg.CreateMap<EnderecoCorePoco, EnderecoCore>();
            });
            this.getMapper = configuration.CreateMapper();
        }
    }
}
