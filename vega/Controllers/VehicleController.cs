using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vega.Persistance;

namespace vega.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public VehicleController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<>>


    }
}