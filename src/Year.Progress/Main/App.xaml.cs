namespace Year.Progress
{
    using System.Reflection;
    using System.Threading;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex;

        private App()
        {
            // Ref: 
            // http://www.c-sharpcorner.com/UploadFile/f9f215/how-to-restrict-the-application-to-just-one-instance/
            // https://www.codeproject.com/Articles/1173686/A-Csharp-System-Tray-Application-using-WPF-Forms

            var mutexName = Assembly.GetExecutingAssembly().GetType().GUID.ToString();
            mutex = new Mutex(true, mutexName, out bool createdNew);
            if (!createdNew)
            { 
                Current.Shutdown();
            }
        }
    }
}
