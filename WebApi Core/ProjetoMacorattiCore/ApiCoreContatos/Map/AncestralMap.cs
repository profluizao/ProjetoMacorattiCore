using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreContatos.Map
{
    public abstract class AncestralMap
    {
        protected IMapper getMapper;

        public IMapper GetMapper
        {
            get => this.getMapper;
            set => this.getMapper = value;
        }
    }
}
