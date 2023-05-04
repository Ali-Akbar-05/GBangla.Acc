using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class ReturnMessage
    {
        public static string SaveMessage { get; set; } = "Save Successfully";
        public static string UpdateMessage { get; set; } = "Updated Successfully";
        public static string DeleteMessage { get; set; } = "Deleted Successfully";
        public static string ErrorMessage { get; set; } = "<b>Error Occoured</b>";
        public static string DuplicateMessage { get; set; } = "Duplicate Data Found";
        public static string InvalidModelMessage { get; set; } = "Model is not valid";
        public static string FileUploadMessage { get; set; } = "File Uploaded Successfully";
        public static string ApprovedMessage { get; set; } = "Approved Successfully";
    }
}
