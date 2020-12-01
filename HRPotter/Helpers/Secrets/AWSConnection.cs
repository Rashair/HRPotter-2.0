namespace HRPotter.Helpers.Secrets
{
    public class AWSConnection : AWSSecret
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Dbname { get; set; }


        public override string Value
        {
            get => $"Server={Host};Port={Port};Database={Dbname};Uid={Username};Pwd={Password};";
            set
            {
            }
        }
    }
}
