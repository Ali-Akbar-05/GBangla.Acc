using Application.Common.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SSRS.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAcc.Controllers
{
    public class BaseController : Controller
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        #region SSRS Report Call
        /// <summary>
        /// ServerType ="Remote" = 0 Server
        /// /// ServerType ="Own" = 0 Server
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="parameters"></param>
        /// <param name="ReportFormat"></param>
        /// <returns></returns>
        [NonAction]
                                
        protected async Task<FileStreamResult> PrintSSRSReport(string reportName, IDictionary<string, object> parameters, string ReportFormat, int ServerConnectionString = 0,string ReportFolder= "GBAccReport")
        {

            try
            {

                string languageCode = "en-us";
                //byte[] reportContent = null;
                byte[] reportContent = await CallSSRSReport.RenderReport(reportName, parameters, languageCode, ReportFormat, ServerConnectionString, ReportFolder);
             //  byte[] reportContent = await  CallSSRSReport.RenderReportHr(reportName, parameters, languageCode, ReportFormat, ServerConnectionString, ReportFolder);
             //  byte[] reportContent = await  CallSSRSReport.GenerateSSRSReport(reportName, parameters, languageCode, ReportFormat, ServerConnectionString, ReportFolder);
             //  byte[] reportContent = await new SSRSReportExport().RenderReport(reportName, parameters, languageCode, ReportFormat, ServerConnectionString, "GBAccReport");
             //SSRSReportExport  byte[] reportContent = new byte[10];
                var ContentType = "";
                Stream stream = new MemoryStream(reportContent);
                
                if (ReportFormat == ReportExportFormat.ExcelFormat)
                {
                    ContentType = "application/vnd.ms-excel";

                }
                else if (ReportFormat == ReportExportFormat.PdfFormat)
                {
                    ContentType = "application/pdf";
                }
                return new FileStreamResult(stream, ContentType);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        #endregion
    }
}
