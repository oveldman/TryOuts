using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using CoinChecker.Base.Enums;
using CoinChecker.Base.Interfaces;
using CoinChecker.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinExchangeController : ControllerBase
    {
        private readonly ILogger<CoinExchangeController> _logger;
        private readonly IEnumerable<IExchangeAPI> ExchangeAPIs;

        public CoinExchangeController(ILogger<CoinExchangeController> logger, IEnumerable<IExchangeAPI> exchangeAPIs)
        {
            _logger = logger;

            ExchangeAPIs = exchangeAPIs;
        }

        [HttpGet]
        public IEnumerable<CoinModel> Get()
        {

            List<Coin> allKnownCoins = ExchangeAPIs.Select(ea => ea.GetValue(CoinType.Cardano, CoinType.Euro)).ToList();

            return allKnownCoins.Select(akc => new CoinModel(akc));
        }
    }
}
