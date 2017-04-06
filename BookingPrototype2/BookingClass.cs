using System;
using System.Data.SqlClient;


namespace Group_AJR___SBC_Booking_System
{
    internal class BookingController : Entities.User
    {
       
        public BookingTabel { get; set; }

        public idBox (int ID)
        {
            this.ID = ID;
        }

        public static CustomerTable Fromsql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
        {
            Customer customer = new Customertoken["CustomerId"].ToObject<int>());
            customer.Forename = token["firstname"].ToString();
            customer.Surname = token["surname"].ToString();
            customer.Address = token["address"].ToString();
            customer.Email = token["email"].ToString();
            customer.PhoneNumber = token["phonenumber"].ToString();
            customer.Membership = MembershipFromString(token["premember"].ToString());
            return customer;
        }

        public static customerTable[] Fromsql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
        {
            Customer[] sessions = new Customer[tokens.Length];
            for (int i = 0; i<sessions.Length; i++)
                sessions[i] = Fromsql(tokens[i]);
            return sessions;
        }
        public static staff Fromsql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
        {
            Staff staff = new staff token["staffID"].ToObject<int>());
            customer.Forename = token["firstname"].ToString();
            customer.Surname = token["lastname"].ToString();
            customer.Address = token["address"].ToString();
            customer.phone = token["phone"].ToString();
            customer.email = token["email"].ToString();
            customer.work = token["work"].ToString();
            customer.Instructor = InstructorFromString(token["Instructor"].ToString());
            return customer;
        }

        public static staff[] Fromsql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=|DataDirectory|\SBCDatabaseV2.mdf;Integrated Security=True;Connect Timeout=30");
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
                case "Yes":
                    return Instructor.Yes;
                case "No":
                    return Instructor.No;
                default:
                    throw new ArgumentException("please input if instructor required", "instructor");
            }
        }
        public CustomerTable makeCopy()
        {
            return (Customer)this.MemberwiseClone();
        }
        public override string ToString()
        {
            return string.Format("{Yes} {No}");
        }
    }
}