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
    public class Feedback
    {
        [DataMember]
        public int Identity_ID { get; set; }
        [DataMember]
        public string Training_Name { get; set; }
        [DataMember]
        public string Trainer_Name { get; set; }
        [DataMember]
        public string Participant_Name { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string P_Email { get; set; }
        [DataMember]
        public string O_Email { get; set; }
        [DataMember]
        public string Mobile_No { get; set; }
        [DataMember]
        public string Office_No { get; set; }
        [DataMember]
        public string QOC { get; set; }
        [DataMember]
        public string QOE { get; set; }
        [DataMember]
        public string PSOT { get; set; }
        [DataMember]
        public string QSBT { get; set; }
        [DataMember]
        public string OQOP { get; set; }
        [DataMember]
        public string Interest { get; set; }
        [DataMember]
        public string Liked { get; set; }
        [DataMember]
        public string Disliked { get; set; }
        [DataMember]
        public string Comments { get; set; }

    }
}
