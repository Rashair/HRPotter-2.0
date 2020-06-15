namespace HRPotter.Helpers.Secrets
{
    public class AWSSecret
    {
        public virtual string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
