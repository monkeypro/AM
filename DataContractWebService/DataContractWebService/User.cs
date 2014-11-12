using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DataContractWebService
{
    [DataContract]
    public class User : IDataContract
    {
        [DataMember(Order = 0)]
        public Guid ID { get; set; }

        [DataMember(Name = "FirstName", Order = 1)]
        private string _firstName;

        [DataMember(Name = "LastName", Order = 2)]
        private string _lastName;

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", _firstName, _lastName);
            }
        }

        public User()
        { }

        public User(string firstName, string lastName) : this()
        {
            ID = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}