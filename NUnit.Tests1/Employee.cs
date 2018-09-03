namespace NUnit.Tests1
{
    public class Employee
    {
        public string Name { get; set; }

        public bool ContainsIllegalChars()
        {
            if (this.Name.Contains("$"))
            {
                return true;
            }
            return false;
        }
    }

    public class Manager : Employee { }

    public class DeliveryManager : Employee { }
}