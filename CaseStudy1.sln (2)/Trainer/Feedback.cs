using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class Feedback
    {
        public string Training_Name { get; set; }
        public string Trainer_Name { get; set; }
        public string Participant_Name { get; set; }

        public string Designation { get; set; }
        public string P_Email { get; set; }

        public string O_Email { get; set; }
        public string Mobile_No { get; set; }

        public string Office_No { get; set; }
        public string QOC { get; set; }

        public string QOE { get; set; }
        public string PSOT { get; set; }
        public string QSBT { get; set; }
        public string OQOP { get; set; }
        public string Interest { get; set; }
        public string Liked { get; set; }
        public string Disliked { get; set; }
        public string Comments { get; set; }
    }
}
