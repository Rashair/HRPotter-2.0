namespace HRPotter.Helpers.Secrets
{
    public class AwsSecret
    {
        public virtual string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
