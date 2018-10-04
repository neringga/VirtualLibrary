namespace VirtualLibrary.DataSources.Data
{
    class EmailCredentials
    {
        private readonly string _username;
        private readonly string _password;

        EmailCredentials()
        {
            TextFile textFile = new TextFile();
            var credentials = textFile.ReadTextFile(Constants.emailCredentialsFile);
            foreach (string line in credentials)
            {
                var spLine = line.Split(' ');
                _username = spLine[0];
                _password = spLine[1];
            }
        }

        public string GetUsername ()
        {
            return _username;
        }

        public string GetPassword ()
        {
            return _password;
        }
    }
}
