using System;
using HuobiMapper.Services;

namespace Huobi.Integrated.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SignerService service = new SignerService("66fa8a46-1426ecd9-vqgdf4gsga-70aa2","d8acadf9-b9e9ac56-2b852e0c-09e41","api.hbdm.com");
            
            var res = service.SendPost("/linear-swap-api/v1/swap_account_info", "{'contract_code':'BTC-USDT'}");
            Console.WriteLine(res);
            Console.Read();
        }
    }
}