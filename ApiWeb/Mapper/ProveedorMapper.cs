﻿using ApiWeb.DTO;
using ApiWeb.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Mapper
{
    public class ProveedorMapper : Profile
    {
        public ProveedorMapper()
        {
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
        }
    }
}
