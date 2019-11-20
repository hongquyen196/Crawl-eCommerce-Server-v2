﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEDTeam.CES.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers
{
    [Route("product-manager")]
    public class ProductManagerController : Controller
    {
        private IProductService _productService;
        public ProductManagerController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("get-product")]
        [HttpPost]
        public async Task<IActionResult> GetProduct()
        {
            int draw = int.Parse(Request.Form["draw"]);
            int start = int.Parse(Request.Form["start"]);
            int length = int.Parse(Request.Form["length"]);
            string search = Request.Form["search[value]"];
            int columnOrder = int.Parse(Request.Form["order[0][column]"]);
            bool isAsc = "asc".Equals(Request.Form["order[0][dir]"]);
            var result = await _productService.GetProductAsync(start, length, search, columnOrder, isAsc);
            result.Draw = draw;
            return new ObjectResult(result);
        }
    }
}