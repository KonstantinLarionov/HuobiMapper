using System;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.Requests
{
    public struct DateTimeWithZone
    {
        private readonly DateTime utcDateTime;
        private readonly TimeZoneInfo timeZone;
        public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
        {
            var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
            this.timeZone = timeZone;
        }
        public DateTime UniversalTime { get { return utcDateTime; } }
        public TimeZoneInfo TimeZone { get { return timeZone; } }
        public DateTime LocalTime
        {
            get
            {
                return TimeZoneInfo.ConvertTime(utcDateTime, timeZone);
            }
        }
    }
    public sealed class RequestArranger
    {   [NotNull]
        private readonly Func<long> _timestampFactory;
        public RequestArranger(Func<long> timestampFactory = null) =>
          _timestampFactory = timestampFactory ?? (() => DateTime.UtcNow.ToUnixTimeMilliseconds());

        private long Timestamp => _timestampFactory.Invoke();
        public int TimestampShiftInMilliseconds { get; set; }

        /// <summary>
        /// Конструктор для создания приватных запросов из (Payload)
        /// </summary>
        /// <param name="apiKey">Публичный ключ аккаунта</param>
        /// <param name="apiSecret">Приватный ключ аккаунта</param>
        /// <param name="subaccountName">[Optional]Ник суб-аккаунта для работы с конкретным суб-аккаунтом от основного аккаунта биржи (можно указать не через конструктор и продолжать запросы с тем же экземпляром класса)</param>
        public RequestArranger(string apiKey,  string apiSecret, string host, string signMethod, string signatureVersion,  Func<long> timestampFactory = null)
            :this(timestampFactory)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Cannot be empty!", nameof(apiKey));
            
            if (string.IsNullOrWhiteSpace(host))
                throw new ArgumentException("Cannot be empty!", nameof(host));

            if (string.IsNullOrWhiteSpace(apiSecret))
                throw new ArgumentException("Cannot be empty!", nameof(apiSecret));

            this.ApiKey = apiKey;
            this.ApiSecret = apiSecret;
            this.Host = host;
            this.SignatureMethod = signMethod;
            this.SignatureVersion = signatureVersion;
        }

        public string Host { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string SignatureMethod { get; set; }
        public string SignatureVersion { get; set; }

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
                        Host,
                        SignatureMethod,
                        SignatureVersion,
                        Timestamp);
                default:
                    return new Request(payload, null);
            }
        }
    }

    
}