namespace Group_AJR___SBC_Booking_System.gof
{
    internal class RegistrationController
    {
        public static Registration[] Fetchpremember(int MembershipId)
        {
            //creates request from the sql server and prints reponse
            Dictionary<string, object> Registration = new Dictionary<string, object>();
            booking.Add("MembershipId", MembershipId);
            DatabaseReply reply = DatabaseManager.DatabaseRequest("MembershipDisplay.sql", Registration);

            //takes array of members from the resposne
            return Prememeber.FromSql(reply.ReplyRows);
        }

        public static CustomerwithLoyalty[] GetCustomer(Registration premember)
        {
            DatabaseReply reply = DatabaseManager.DatabaseRequest("MembershipDisplay.sql",
                new Dictionary<string, object>() { { "MembershipId", Registration.premember } });
            Customer[] customers = Customer.FromSql(reply.ReplyRows);

            Customer[] customerClone = CloneFactory.getCustomerClone(customers);

            Registration.Customers = customers;
            CustomerwithLoyalty[] CustomerwithLoyalty = new CustomerwithLoyalty[customers.Length];
            for (int i = 0; i < customers.Length; i++)
                CustomerwithLoyalty[i] = new CustomerwithLoyalty(customers[i], reply.ReplyRows[i]["CustomerId"].ToObject<int>());

            return CustomerwithLoyalty;
        }

        public static CustomerwithFree[] GetCustomer(Registration premember)
        {
            DatabaseReply reply = DatabaseManager.DatabaseRequest("MembershipDisplay.sql",
                new Dictionary<string, object>() { { "MembershipId", Registration.premember } });
            Customer[] customers = Customer.FromSql(reply.ReplyRows);

            Customer[] customerClone = CloneFactory.getCustomerClone(customers);

            Registration.Customers = customers;
            CustomerwithFree[] CustomerwithFree = new CustomerwithFree[customers.Length];
            for (int i = 0; i < customers.Length; i++)
                CustomerwithFree[i] = new CustomerwithFree(customers[i], reply.ReplyRows[i]["CustomerId"].ToObject<int>());

            return CustomerwithFree;
        }
    }

    internal class CustomerwithLoyalty
    {
        public readonly Customer Customer;
        public readonly int prememebrID;

        public CustomerwithLoyalty(Customer customer, int CustomerId)
        {
            this.Customer = customer;
            this.prememberID = prememberID;
        }
    }

    internal class CustomerwithFree
    {
        public readonly Customer Customer;
        public readonly int prememebrID;

        public CustomerwithFree(Customer customer, int CustomerId)
        {
            this.Customer = customer;
            this.prememberID = prememberID;
        }
    }
}