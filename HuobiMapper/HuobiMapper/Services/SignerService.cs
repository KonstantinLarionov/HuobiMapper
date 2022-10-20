using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace HuobiMapper.Services
{
    public class SignerService
    {
        private readonly string _apikey;
        private readonly string _secret;
        private readonly string _host;

        ProcessStartInfo cmdStartInfo = new ProcessStartInfo(@"D:\dist\http_private\http_private.exe");
        private readonly Process cmdProcess;

        public delegate void DataEventCMD(string val); 
        public event DataEventCMD DataEvent;
        public delegate void DataEventErrorCMD(string val); 
        public event DataEventErrorCMD ErrorEvent;

        private string LastDataReceive = string.Empty;
        public SignerService(string apikey, string secret,string host)
        {
            _apikey = apikey;
            _secret = secret;
            _host = host;
            
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = true;
            
            cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.ErrorDataReceived += cmd_Error;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
        }

        public string SendPost(string path, string param)
        {
            cmdStartInfo.Arguments = $"{_apikey} {_secret} {_host} {path} {param}";
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
            cmdProcess.WaitForExit();
            
            while (true)
            {
                if (!string.IsNullOrEmpty(LastDataReceive)) 
                    return LastDataReceive;
                Thread.Sleep(10);
            }
        }

        private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                LastDataReceive = e.Data;
                DataEvent?.Invoke(e.Data);
            }
        }

        private void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                LastDataReceive = e.Data;
                ErrorEvent?.Invoke(e.Data);
            }
        }
    }
}