using System.IO;
using System.Linq;
using System.Windows;
using log4net;
using log4net.Appender;
using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]

namespace LogForNetSample
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var logger = log;
            logger.Error("Pau");
            var appenders = logger.Logger.Repository.GetAppenders();

            var firstOrDefault = appenders.OfType<FileAppender>().FirstOrDefault();
            var readAllText = File.ReadAllText(firstOrDefault.File);
            MessageBox.Show(readAllText);
        }
    }
}
