﻿
using System;
using System.Diagnostics;
using System.Threading;
using Huobi.SDK.Core.WSBase.PrivateStreams.Enums;
using HuobiMapper.Extensions;

namespace Huobi.SDK.Core.WSBase.PrivateStreams
{
    public static class CombineSubscriberPrivate
    {
        /// <summary>
        /// CreateAuth
        /// </summary>
        /// <param name="api">Открытый ключ</param>
        /// <param name="secret">Закрытый ключ</param>
        /// <param name="uriSigner">Путь до signwshuobi.exe (нужно указывать строку для ProcessStartInfo.
        /// Старая строка состояла из: Environment.CurrentDirectory +  @"\ws\signwshuobi.exe")</param>
        /// <returns></returns>
        public static string CreateAuth(string api, string secret, string uriSigner)
        {
            string result = string.Empty;
            
            // ProcessStartInfo cmdStartInfo = new ProcessStartInfo(Environment.CurrentDirectory +  @"\ws\signwshuobi.exe");
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo(uriSigner);
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = true;
            
            Process cmdProcess;
            cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.ErrorDataReceived += (sender, args) =>
            {
                if (args.Data != null) result = args.Data;
            };
            cmdProcess.OutputDataReceived += (sender, args) =>
            {
                if (args.Data != null) result = args.Data;
            };
            
            cmdProcess.EnableRaisingEvents = true;
            cmdStartInfo.Arguments = $"{api} {secret}";
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
            cmdProcess.WaitForExit();
            
            while (true)
            {
                if(!string.IsNullOrEmpty(result))
                    break;
                
                Thread.Sleep(10);  
            }
            
            return result;
            
        }

        public static string CreateOrdersSub(string symbol, SubType subType)
        {
            var id = Guid.NewGuid().ToString();
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                symbol = "." + symbol;
            }

            return "{ \"op\": \""+ subType.GetEnumMemberAttributeValue() +"\", \"cid\": \""+ id +"\", \"topic\": \"orders"+ symbol.ToUpper() +"\" }";
        }
        public static string CreatePositionsSub(string symbol, SubType subType)
        {
            
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                symbol = "." + symbol;
            }
            var id = Guid.NewGuid().ToString();
            return "{ \"op\": \""+ subType.GetEnumMemberAttributeValue() +"\", \"cid\": \""+ id +"\", \"topic\": \"positions"+ symbol.ToUpper() +"\" }";
        }
        public static string CreatePrivateTradeSub(string symbol, SubType subType)
        {
            
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                symbol = "." + symbol;
            }
            var id = Guid.NewGuid().ToString();
            return "{ \"op\": \""+ subType.GetEnumMemberAttributeValue() +"\", \"cid\": \""+ id +"\", \"topic\": \"matchOrders"+ symbol.ToLower() +"\" }";
        }
    }
}