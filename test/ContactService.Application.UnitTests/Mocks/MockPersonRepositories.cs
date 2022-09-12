using Contact.Domain.PersonAggregate;
using Contact.Shared.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Application.UnitTests.Mocks
{
    public static class MockPersonRepositories
    {
        public static Mock<IPersonRepository> GetPersonRepository()
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Name="TName 1",
                    Surname="TSurName 1",
                    Company = "Test Comp 1",
                    ContactInfo=new List<ContactInfo>{new ContactInfo { ContactContent="Izmir1", ContactType=ContactType.Location} }
                },
                new Person
                {
                     Name="TName 2",
                    Surname="TSurName 2",
                    Company = "Test Comp 2",
                    ContactInfo=new List<ContactInfo>{new ContactInfo { ContactContent="Izmir2", ContactType=ContactType.Location} }
                },
                new Person
                {
                    Name="TName 3",
                    Surname="TSurName 3",
                    Company = "Test Comp 3",
                    ContactInfo=new List<ContactInfo>{new ContactInfo { ContactContent="Izmir3", ContactType=ContactType.Location} }
                }
            };
            var mockRepo = new Mock<IPersonRepository>();

            mockRepo.Setup(r => r.Get()).Returns(persons);

            mockRepo.Setup(r => r.Create(It.IsAny<Person>())).Returns((Person person) =>
            {
                persons.Add(person);
                return persons;
            });

            return mockRepo;
        }
    }
}
