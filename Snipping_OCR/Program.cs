using Snipping_OCR;
#if NET481_OR_GREATER
using System;
using System.Windows.Forms;
#endif

namespace Snipping_OCR
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
#if NET481_OR_GREATER
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#else
            ApplicationConfiguration.Initialize();
#endif
            Application.Run(new Main());
        }
    }
}