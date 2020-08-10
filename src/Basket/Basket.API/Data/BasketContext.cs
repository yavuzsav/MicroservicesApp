using Basket.API.Data.Interfaces;
using StackExchange.Redis;
using System;

namespace Basket.API.Data
{
    public class BasketContext : IBasketContext
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public BasketContext(ConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
            Redis = _connectionMultiplexer.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
