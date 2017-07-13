using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CaseStudyDALServicesLib;
using BusinessEntities;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
           ServiceHost host = new ServiceHost(typeof(TrainerDAL), new Uri("http://localhost:8083/casestudy1/trainerdalservice"));
           ServiceHost host1 = new ServiceHost(typeof(ClientDAL), new Uri("http://localhost:8085/casestudy1/clientdalservice"));
           ServiceHost host2 = new ServiceHost(typeof(Schedule_TrainingDAL), new Uri("http://localhost:8087/casestudy1/schedule_trainingdalservice"));
            ServiceHost host3 = new ServiceHost(typeof(FeedbackDAL), new Uri("http://localhost:8089/casestudy1/feedbackdalservice"));
         
           host.AddDefaultEndpoints();
           host1.AddDefaultEndpoints();
           host2.AddDefaultEndpoints();
           host3.AddDefaultEndpoints();
           host.Open();
          host1.Open();
           host2.Open();
            host3.Open();
            Console.WriteLine("FEEDBACK DAL services up and runningtgy");
            Console.WriteLine("press any key to stop");
            Console.ReadKey();
           host.Close();
            host1.Close();
            host2.Close();
            host3.Close();
        }
    }
}
