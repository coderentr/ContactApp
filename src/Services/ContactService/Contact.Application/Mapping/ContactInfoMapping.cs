using Contact.Application.Queries.Response;
using Contact.Domain.PersonAggregate;
using Contact.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Mapping
{
    public static class ContactInfoMapping
    {
        public static List<ContactInfoQueryResponse> ToDto(this List<ContactInfo> contactInfos)
        {
            var response=new List<ContactInfoQueryResponse>();
            foreach (var item in contactInfos)
            {
                response.Add(new ContactInfoQueryResponse
                {
                    ContactType = item.ContactType,
                    ContantContent = item.ContactContent,
                    ContantTypeStr = Enum.GetName(typeof(ContactType), item.ContactType)
                });
            }
            return response;
        }
    }
}
