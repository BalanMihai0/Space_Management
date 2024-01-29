using DataLibrary;
using SpaceLibrary;
using UserLibrary;
using SharedLibrary;
using System.Numerics;

namespace Individual_sem2
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
            ApplicationConfiguration.Initialize();

            IUserDataInterface userDataStorage = new UserDataHandler();
            ISpaceDataInterface spaceDataInterface = new SpaceDataHandler();
            SpaceApp.Initialize(userDataStorage, spaceDataInterface);
            //SpaceApp.Instance.SpaceManager.StartTimeFlow();

            Application.Run(new FormLogin());
        }
    }
}