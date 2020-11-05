using FluentAssertions;
using Humanis.Application.DTO;
using Humanis.Application.Services;
using Humanis.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Domain = Humanis.Domain.Model;
using DTO = Humanis.Application.DTO;

namespace Application.Services.Tests
{
    [TestClass]
    public class PersonServiceTests
    {
        IPersonService target;
        Mock<IPersonRepository> personRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            this.personRepositoryMock = new Mock<IPersonRepository>();
            this.target = new PersonService(this.personRepositoryMock.Object);
        }


        [TestMethod]
        //method_scenario_expectedResult
        public void GetAll_ValidCall_ReturnResults()
        {
            //Arrange

            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();

            // The result we want to have
            var expectedResult = new List<DTO.Person>
            {              
                  new DTO.Person { Id = id1, FirstName = "FirstName1", LastName = "LastName1"},
                  new DTO.Person { Id = id2, FirstName = "FirstName2", LastName = "LastName2" },
                  new DTO.Person { Id = id3, FirstName = "FirstName3", LastName = "LastName3" }
            };

            // setup the repository assumption
            var persons = new List<Domain.Person>
            {
                  new Domain.Person { Id = id1, FirstName = "FirstName1", LastName = "LastName1" },
                  new Domain.Person { Id = id2, FirstName = "FirstName2", LastName = "LastName2" },
                  new Domain.Person { Id = id3, FirstName = "FirstName3", LastName = "LastName3" }
            };

            this.personRepositoryMock.Setup(x => x.GetAll()).Returns(persons);

  
            //Act
            //Invocation of the service method
            var result = this.target.GetAll();

            //Assert
            // Validation of the expected result comparing to the returned from the service
            // using fluent Assertions we can assert full collections 
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        [DataRow("3f54fd1c-2ab1-4954-b765-b9f6aed80bc3")]
        public void GetById_ValidId_ReturnsValidResponse(string personGuid)
        {
            //Arrange
            var id = new Guid(personGuid);

            // The result we want to have
            var expectedResult = new DTO.Person { Id = id, FirstName = "FirstName1", LastName = "LastName1" };

            // setup the repository assumption

            var person = new Domain.Person { Id = id, FirstName = "FirstName1", LastName = "LastName1" };            

            this.personRepositoryMock.Setup(x => x.GetById(id)).Returns(person);


            //Act
            //Invocation of the service method
            var result = this.target.GetById(id);

            //Assert
            // Validation of the expected result comparing to the returned from the service
            // using fluent Assertions we can assert full collections 
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        [DataRow("3f54fd1c-2ab1-4954-b765-b9f6aed80bc3")]
        public void GetById_NotExistent_ReturnsInvalidResponse(string personGuid)
        {
            //Arrange
            var id = new Guid(personGuid);

            // The result we want to have
            var expectedResult = default(Person);

            // setup the repository assumption

            this.personRepositoryMock.Setup(x => x.GetById(id)).Returns(default(Domain.Person));

            //Act
            //Invocation of the service method
            var result = this.target.GetById(id);

            //Assert
            // Validation of the expected result comparing to the returned from the service
            // using fluent Assertions we can assert full collections 
            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]        
        public void GetById_NotExistent_ReturnsInvalidResponse_v2()
        {
            //Arrange            
            var id = Guid.NewGuid();

            // setup the repository assumption

            this.personRepositoryMock.Setup(x => x.GetById(id)).Returns(default(Domain.Person));

            //Act
            //Invocation of the service method
            var result = this.target.GetById(id);

            //Assert
            // Validation of the expected result comparing to the returned from the service
            // using fluent Assertions we can assert full collections 
            Assert.IsNull(result);
        }




    }
}
