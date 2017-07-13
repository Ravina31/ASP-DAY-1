using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace BusinessEntities
{
    [DataContract]
    public class Client
    { 
        [DataMember]
        public int Client_ID { get; set; }
        [DataMember]
        public string Client_Name { get; set; }
        [DataMember]
        public string Client_Location { get; set; }

       
    }
}
