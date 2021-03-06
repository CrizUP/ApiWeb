﻿using ApiWeb.DTO;
using ApiWeb.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Mapper
{
    public class ProductoMapper: Profile
    {
        public ProductoMapper()
        {            
            CreateMap<Producto, ProductoDTO>().ReverseMap(); 
        }

    }
}
