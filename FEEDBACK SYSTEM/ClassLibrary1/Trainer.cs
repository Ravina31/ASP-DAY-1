using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BusinessEntities
{      
    
    [DataContract]
    public class Trainer

    {   [DataMember]
        public int Trainer_ID { get; set; }

         [DataMember]
        public string Trainer_Name { get; set; }

         [DataMember]
        public string Email_ID { get; set; }

         [DataMember]
        public string Base_Location { get; set; }

         [DataMember]
        public string Profile_Link { get; set; }


    }
}
