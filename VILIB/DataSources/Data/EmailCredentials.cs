using System.Configuration;

namespace VILIB.DataSources.Data
{
    public class EmailCredentials
    {
        private string _password;
        private int _smtpPort;
        private string _smtpServer;
        private string _username;

        public EmailCredentials()
        {
            GetEmailCredentialsFromFile();
        }

        private void GetEmailCredentialsFromFile()
        {
            var textFile = new TextFile();
            var credentials = textFile.ReadTextFile(
                ConfigurationManager.AppSettings["vilibEmail"]);
            foreach (var line in credentials)
            {
                var spLine = line.Split(' ');
                _username = spLine[0];
                _password = spLine[1];
                _smtpPort = int.Parse(spLine[3]);
                _smtpServer = spLine[2];
            }
        }

        public string GetUsername()
        {
            return _username;
        }

        public string GetPassword()
        {
            return _password;
        }

        public string GetServer()
        {
            return _smtpServer;
        }

        public int GetPort()
        {
            return _smtpPort;
        }
    }
}