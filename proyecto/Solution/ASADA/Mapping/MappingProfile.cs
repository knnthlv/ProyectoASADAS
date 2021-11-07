using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DAL.DO.Objects;
using models = ASADA.Models;

namespace ASADA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Averia, models.Averia>().ReverseMap();
            CreateMap<data.Comprobante, models.Comprobante>().ReverseMap();
            CreateMap<data.Estado, models.Estado>().ReverseMap();
            CreateMap<data.Marca, models.Marca>().ReverseMap();
            CreateMap<data.Medidor, models.Medidor>().ReverseMap();
            CreateMap<data.Recibo, models.Recibo>().ReverseMap();
            CreateMap<data.Tarjeta, models.Tarjeta>().ReverseMap();
            CreateMap<data.TipoUsuario, models.TipoUsuario>().ReverseMap();
            CreateMap<data.Usuario, models.Usuario>().ReverseMap();
        }
    }
}
