using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using BusinessLayer.Coins.Interfaces;
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
        private readonly IExchangeManager _exchangeManager;

        public CoinExchangeController(ILogger<CoinExchangeController> logger, IExchangeManager exchangeManager)
        {
            _logger = logger;
            _exchangeManager = exchangeManager;
        }

        [HttpGet]
        [Route("GetAllExchangeTypes")]
        public IEnumerable<ExchangeTypeModel> GetAllExchangeTypes()
        {
            return Enum.GetValues(typeof(ExchangeType)).OfType<ExchangeType>()
                        .Select(et => new ExchangeTypeModel {
                            ID = (int) et,
                            Name = et.ToString()
                        })
                        .ToList();
        }

        [HttpGet]
        [Route("GetAllCoinTypes")]
        public IEnumerable<CoinTypeModel> GetAllCoinTypes()
        {
            return Enum.GetValues(typeof(CoinType)).OfType<CoinType>()
                       .Select(ct => new CoinTypeModel {
                           ID = (int) ct,
                           Name = ct.ToString()
                        }).ToList();
        }

        [HttpGet]
        [Route("GetValues")]
        public IEnumerable<CoinModel> GetValues(string baseCoin, string prizeCoin)
        {
            bool baseCoinParsedSucceed = Enum.TryParse<CoinType>(baseCoin, out CoinType baseCoinType);
            bool prizeCoinParsedSucceed = Enum.TryParse<CoinType>(prizeCoin, out CoinType prizeCoinType);

            if (baseCoinParsedSucceed && prizeCoinParsedSucceed) {
                List<Coin> allKnownCoins = _exchangeManager.GetAllValues(baseCoinType, prizeCoinType);
                return allKnownCoins.Select(akc => new CoinModel(akc));
            }

            return new List<CoinModel>();
        }
    }
}
