using Akka.Actor;
using System;
using System.Windows.Forms;

namespace ChartAppNew
{
    internal static class Program
    {
        /// <summary>
        /// ActorSystem we'll be using to publish data to charts
        /// and subscribe from performance counters
        /// </summary>
        public static ActorSystem? ChartActors;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ChartActors = ActorSystem.Create("ChartActors");
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}