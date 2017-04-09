namespace FluentAssemblyScanner.NetCore.Tests.SpecClasses
{
    public class BBankPaymentMethod : IPaymentMethod
    {
        [Multitenant]
        public void PayMe()
        {
        }

        public void SomeBPaymentInternalMethod()
        {
        }
    }
}
