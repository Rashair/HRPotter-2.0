using Newtonsoft.Json;

namespace HRPotter.Helpers.Secrets
{
    public static class SecretsFactory
    {
        public static AWSSecret Get(this Secret secret)
        {
            var serialized = AwsTools.GetSerializedSecret(secret.ToString());
            return secret.Get(serialized);
        }

        public static AWSSecret Get(this Secret secret, string serialized)
        {
            switch (secret)
            {
                case Secret.AWSDbConnection:
                    return JsonConvert.DeserializeObject<AWSConnection>(serialized);
            }

            return JsonConvert.DeserializeObject<AWSSecret>(serialized);
        }
    }
}
