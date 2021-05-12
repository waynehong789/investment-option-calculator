using System;

namespace Customers.Core.Aggregates
{
    public class Customer
    {
        #region Properties

        public Guid ID { get; set; }
        public DateTime? CreatedDateUtc { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {get; set;}
        public string Phone {get; set;}
        public string Status { get; set; }

        #endregion

        #region Constructors

        protected Customer()
        {
            CreatedDateUtc = DateTime.UtcNow;
        }

        public Customer(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion

        #region Methods



        #endregion

    }
}
