using ApiCoreContatos.Models;
using ApiCoreContatos.Poco;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreContatos.Map
{
    public class ContatoCoreMap : AncestralMap
    {
        public ContatoCoreMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContatoCore, ContatoCorePoco>();
                cfg.CreateMap<ContatoCorePoco, ContatoCore>();
            });
            this.getMapper = configuration.CreateMapper();
        }
    }
}
