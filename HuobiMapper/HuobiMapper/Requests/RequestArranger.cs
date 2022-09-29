using System;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.Requests
{
    public sealed class RequestArranger
    {   [NotNull]
        private readonly Func<long> _timestampFactory;
        public RequestArranger( Func<long> timestampFactory = null) =>
          _timestampFactory = timestampFactory ?? (() => DateTime.Now.AddMinutes(1).ToUnixTimeSeconds());

        private long Timestamp => _timestampFactory.Invoke();
        public int TimestampShiftInMilliseconds { get; set; }

        /// <summary>
        /// Конструктор для создания приватных запросов из (Payload)
        /// </summary>
        /// <param name="apiKey">Публичный ключ аккаунта</param>
        /// <param name="apiSecret">Приватный ключ аккаунта</param>
        /// <param name="subaccountName">[Optional]Ник суб-аккаунта для работы с конкретным суб-аккаунтом от основного аккаунта биржи (можно указать не через конструктор и продолжать запросы с тем же экземпляром класса)</param>
        public RequestArranger( string apiKey,  string apiSecret,  Func<long> timestampFactory = null)
            :this(timestampFactory)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Cannot be empty!", nameof(apiKey));

            if (string.IsNullOrWhiteSpace(apiSecret))
                throw new ArgumentException("Cannot be empty!", nameof(apiSecret));

            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public int ActualityWindow { get; set; } = 5000;
        public string Nonce { get;set; }

        /// <summary>
        /// Метод создания запроса к бирже
        /// </summary>
        /// <param name="payload">Вся собранная информация запроса</param>
        /// <returns></returns>
        public IRequestContent Arrange( RequestPayload payload)
        {
            switch (payload)
            {
                case KeyedRequestPayload _payload:
                    return new KeyedRequest(payload, 
                        ApiKey, 
                        ApiSecret, 
                        Timestamp);
                default:
                    return new Request(payload, null);
            }
        }
    }

    
}