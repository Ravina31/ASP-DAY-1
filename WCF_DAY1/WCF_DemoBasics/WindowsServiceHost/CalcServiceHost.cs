﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ContractsLib;
using ServicesLib;
using System.ServiceModel;

namespace WindowsServiceHost
   
{
    public partial class CalcServiceHost : ServiceBase
    {
        private ServiceHost host = null;

        public CalcServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(Calc));
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
