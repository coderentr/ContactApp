using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportBgService.Models.Response
{
    public class ReportResponse
    {
        public List<ListPersonQueryResponse> ListPersonQueryResponse { get; set; }
    }
    public class ListPersonQueryResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ContactInfoQueryResponse> ContactInfo { get; set; }
    }
    public class ContactInfoQueryResponse
    {
        public string ContantContent { get; set; }
        public string ContantTypeStr { get; set; }

    }
}
