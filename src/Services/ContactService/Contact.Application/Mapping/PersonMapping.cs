using Contact.Application.Queries.Response;
using Contact.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Mapping
{
    public static class PersonMapping
    {
        public static List<ListPersonQueryResponse> ToDto(this IEnumerable<Person> persons)
        {
            var response=new List<ListPersonQueryResponse>();

            foreach (var item in persons)
            {
                response.Add(new ListPersonQueryResponse
                {
                    Id = item.Id.ToString(),
                    Company = item.Company,
                    ContactInfo = item.ContactInfo?.ToDto().ToList(),
                    FullName = $"{item.Name} {item.Surname}"
                });
            }
            return response.ToList();
        }
    }
}
