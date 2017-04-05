using System;
using System.Data.SqlClient;


namespace Group_AJR___SBC_Booking_System
{
    internal class CustomerTable : Entities.User
    {
       
        public MembershipType Membership { get; set; }

        public CustomerTable(int ID)
        {
            this.ID = ID;
        }

        public static CustomerTable Fromsql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
        {
            Customer customer = new Customertoken["CustomerId"].ToObject<int>());
            customer.Forename = token["firstname"].ToString();
            customer.Surname = token["surname"].ToString();
            customer.Address = token["address"].ToString();
            customer.Email = token["ema"].ToString();
            customer.PhoneNumber = token["phonenumber"].ToString();
            customer.Membership = MembershipFromString(token["premember"].ToString());
            return customer;
        }

        public static CustomerTable[] Fromsql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
        {
            Customer[] sessions = new Customer[tokens.Length];
            for (int i = 0; i < sessions.Length; i++)
                sessions[i] = Fromsql(tokens[i]);
            return sessions;
        }

        public static MembershipType MembershipFromString(string membership)
        {
            switch (membership)
            {
                case "Loyalty Member":
                    return MembershipType.Loyalty;
                case "Free Member":
                    return MembershipType.Free;
                case "Registered":
                    return MembershipType.Registered;
                default:
                    throw new ArgumentException("Invalid membership type", "membership");
            }
        }
        public CustomerTable makeCopy()
        {
            return (Customer)this.MemberwiseClone();
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", Forename, Surname);
        }
    }
}