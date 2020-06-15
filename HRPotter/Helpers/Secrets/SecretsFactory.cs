using Newtonsoft.Json;

namespace HRPotter.Helpers.Secrets
{
    public static class SecretsFactory
    {
        public static AwsSecret Get(this Secret secret)
        {
            var serialized = AwsTools.GetSerializedSecret(secret.ToString());
            return secret.Get(serialized);
        }

        public static AwsSecret Get(this Secret secret, string serialized)
        {
            switch (secret)
            {
                case Secret.AWSConnection:
                    return JsonConvert.DeserializeObject<AWSConnection>(serialized);
            }

            return JsonConvert.DeserializeObject<AwsSecret>(serialized);
        }
    }
}
