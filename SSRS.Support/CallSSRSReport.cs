using Application.Common.CommonModels;
using ServiceReference;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SSRS.Support
{
    public static class CallSSRSReport
    {
        public async static Task<byte[]> RenderReport(string reportName, IDictionary<string, object> parameters, string languageCode, string exportFormat, int ServerConnectionString = 0, string ReportFolder = "HRMS")
        {
            //
            // SSRS report path. Note: Need to include parent folder directory and report name.
            // Such as value = "/[report folder]/[report name]".
            //
            //string reportPath = string.Format("{0}{1}", ConfigSettings.ReportingServiceReportFolder, reportName);
            string reportPath = string.Format("/{0}/{1}", ReportFolder, reportName);
            //
            // Binding setup, since ASP.NET Core apps don't use a web.config file
            //
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            // start New Add
            //  binding.Security.Transport.ProxyCredentialType =HttpProxyCredentialType.Ntlm;


            // End New Add
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm; // May Be Change
            binding.MaxReceivedMessageSize = 100000000; //this.ConfigSettings.ReportingServiceReportMaxSize; //It is 10MB size limit on response to allow for larger PDFs
                                                        // For Time Out
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            //binding.time
            //Create the execution service SOAP Client
            //  ReportExecutionServiceSoapClient reportClient = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(this.ConfigSettings.ReportingServiceUrl));
            ReportExecutionServiceSoapClient reportClient = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(StaticConfigs.GetConfig("ReportingServiceUrl")));
            //Setup access credentials. Here use windows credentials.
            // var clientCredentials = new NetworkCredential(this.ConfigSettings.ReportingServiceUserAccount, this.ConfigSettings.ReportingServiceUserAccountPassword, this.ConfigSettings.ReportingServiceUserAccountDomain);
            var clientCredentials = new NetworkCredential(StaticConfigs.GetConfig("ReportingServiceUserAccount"), StaticConfigs.GetConfig("ReportingServiceUserAccountPassword"), StaticConfigs.GetConfig("ReportingServiceUserAccountDomain"));
            reportClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            reportClient.ClientCredentials.Windows.ClientCredential = clientCredentials;

            //This handles the problem of "Missing session identifier"
            reportClient.Endpoint.EndpointBehaviors.Add(new ReportingServiceEndPointBehavior());




            string historyID = null;
            TrustedUserHeader trustedUserHeader = new TrustedUserHeader();
            ExecutionHeader execHeader = new ExecutionHeader();

            trustedUserHeader.UserName = clientCredentials.UserName;

            //
            // Load the report
            //
            var taskLoadReport = await reportClient.LoadReportAsync(trustedUserHeader, reportPath, historyID);

            // Fixed the exception of "session identifier is missing".
            execHeader.ExecutionID = taskLoadReport.executionInfo.ExecutionID;

            //
            //Set the parameteres asked for by the report
            //
            ParameterValue[] reportParameters = null;
            if (parameters != null && parameters.Count > 0)
            {
                reportParameters = taskLoadReport.executionInfo.Parameters.Where(x => parameters.ContainsKey(x.Name)).Select(x => new ParameterValue() { Name = x.Name, Value = parameters[x.Name] == null ? "" : parameters[x.Name].ToString() }).ToArray();
            }

            /*Database Security*/
            var connectionBuilder = new SqlConnectionStringBuilder();

            connectionBuilder = new SqlConnectionStringBuilder(GetServerConnectionString(ServerConnectionString));
            var user = connectionBuilder.UserID;
            var pwd = connectionBuilder.Password;
            var datasource = connectionBuilder.DataSource;
            var dbname = connectionBuilder.InitialCatalog;

            var dbParm = new List<ParameterValue>(); ;
            dbParm.Add(new ParameterValue() { Name = "ServerName", Value = datasource });
            dbParm.Add(new ParameterValue() { Name = "DatabaseName", Value = dbname });
            if (reportParameters != null && reportParameters.Count() > 0)
            {
                dbParm.AddRange(reportParameters);
            }

            DataSourceCredentials dataSourceCredentials;
            DataSourceCredentials[] dsCredentials = new DataSourceCredentials[taskLoadReport.executionInfo.DataSourcePrompts.Length];
            /*
            if (taskLoadReport.executionInfo.DataSourcePrompts.Length > 0)
            {

                dataSourceCredentials.DataSourceName = taskLoadReport.executionInfo.DataSourcePrompts.Where(x=>x.Prompt!="SubReport").ToList()[0].Name;
            }
            else
                dataSourceCredentials.DataSourceName = "AK-JT";
            */
            if (taskLoadReport.executionInfo.DataSourcePrompts.Length > 0)
            {
                for (int e = 0; e < taskLoadReport.executionInfo.DataSourcePrompts.Length; e++)
                {
                    dataSourceCredentials = new DataSourceCredentials();
                    dataSourceCredentials.UserName = user;
                    dataSourceCredentials.Password = pwd;
                    dataSourceCredentials.DataSourceName = taskLoadReport.executionInfo.DataSourcePrompts[e].Name;
                    dsCredentials[e] = dataSourceCredentials;
                }
            }
            else
            {
                dataSourceCredentials = new DataSourceCredentials();
                dataSourceCredentials.DataSourceName = "AK-JT";
            }




            await reportClient.SetExecutionCredentialsAsync(execHeader, trustedUserHeader, dsCredentials);


            /*End Database Security*/
            #region  New Add For Timeout

            #endregion
            //reportClient.SetExecutionCredentialsAsync();
            await reportClient.SetExecutionParametersAsync(execHeader, trustedUserHeader, dbParm.ToArray(), languageCode);
            // run the report
            const string deviceInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

            var response = await reportClient.RenderAsync(new RenderRequest(execHeader, trustedUserHeader, exportFormat ?? "PDF", deviceInfo));

            //spit out the result
            return response.Result;
        }

        public static string  GetServerConnectionString(int ServerConnectionString)
        {
            string _connectionString = "";
            switch (ServerConnectionString)
            {
                case 0:
                    _connectionString = StaticConfigs.GetConnectionString("GBAccConnection");
                    break;

                default:
                    _connectionString = StaticConfigs.GetConnectionString("GBAccConnection");
                    break;
            }



            return _connectionString;
        }
    }
}