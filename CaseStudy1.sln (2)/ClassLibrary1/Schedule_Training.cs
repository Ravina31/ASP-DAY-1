using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BusinessEntities
{
    [DataContract]
    public class Schedule_Training
    {
        [DataMember]
        public int Training_ID { get; set; }
        [DataMember]
        public string Training_Name { get; set; }
        [DataMember]
        public string Trainer_Name { get; set; }
        [DataMember]
        public DateTime Start_Date { get; set; }
        [DataMember]
        public DateTime End_Date { get; set; }

    }
}
