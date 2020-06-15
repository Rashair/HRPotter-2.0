namespace HRPotter.Helpers.Secrets
{
    public class AWSConnection : AwsSecret
    {
        public string Server { get; set; }

        public int Port { get; set; }

        public string Database { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public override string Value
        {
            get => $"Server={Server};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
            set
            {
            }
        }
    }
}
