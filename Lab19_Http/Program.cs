﻿using System;
using System.Net;
using System.Diagnostics;

namespace Lab19_Http
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("https://www.bbc.co.uk/weather");

            Console.WriteLine($"Host is: {uri.Host}, The Port is: {uri.Port}, The path is: {uri.AbsolutePath}");

            // Get Page

            var webClient = new WebClient() { Proxy = null };
            webClient.DownloadFile(uri, "localPage.html");
            // run the webpage locally
            Process.Start("notepad.exe");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localPage.html");

        }
    }
}
