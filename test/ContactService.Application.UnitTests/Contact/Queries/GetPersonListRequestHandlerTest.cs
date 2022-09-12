using AutoMapper;
using Contact.Application.Handlers.QueryHandlers;
using Contact.Application.Queries.Request;
using Contact.Application.Queries.Response;
using Contact.Domain.PersonAggregate;
using ContactService.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Application.UnitTests.Contact.Queries
{
    public class ListPersonListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPersonRepository> _mockRepo;
        public ListPersonListRequestHandlerTest()
        {
            _mockRepo = MockPersonRepositories.GetPersonRepository();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new ListPersonQueryHandle(_mockRepo.Object);

            var result = await handler.Handle(new ListPersonQueryRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ListPersonQueryResponse>>();

            result.Count.ShouldBe(3);
        }
    }
}
