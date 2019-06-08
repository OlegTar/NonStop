using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.ViewModels;
using AutoMapper;

namespace Application
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Document, DocumentViewModel>();
            CreateMap<DocumentViewModel, Document>();
        }
    }
}
