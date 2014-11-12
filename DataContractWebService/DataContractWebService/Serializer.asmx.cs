using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DataContractWebService
{
    /// <summary>
    /// Summary description for Serializer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Serializer : System.Web.Services.WebService
    {

        [WebMethod]
        public void ToXml(string firstName, string lastName)
        {
            var user = new User(firstName, lastName);

            user.ToXmlFile();
        }

        [WebMethod]
        public string FromXml()
        {
            var user = new User().FromXmlFile();

            return user.Name;
        }
    }
}
