using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServiceTests
{
    public class PetControllerTests
    {
        private PetController _petController;
        private Mock<IPetRepository> _mocPetRepository;


        public PetControllerTests()
        {
            _mocPetRepository = new Mock<IPetRepository>();
            _petController = new PetController(_mocPetRepository.Object);
        }


        [Fact]
        public void GetAllPetsTest()
        {
            List<Pet> pets = new List<Pet>
            {
                new Pet(),
                new Pet(),
                new Pet()
            };

            _mocPetRepository.Setup(repository =>
                repository.GetAll()).Returns(pets);

            var result = _petController.GetAll();

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsAssignableFrom<List<Pet>>(((OkObjectResult)result.Result).Value);

            _mocPetRepository.Verify(repository => repository.GetAll(), Times.AtLeastOnce());
        }


        public static readonly object[][] CorrectCreatePetData =
        {
            new object[] { new DateTime(2019, 12, 3), 1, "Барсик"},
            new object[] { new DateTime(2020, 11, 2), 2, "Снежок"},
            new object[] { new DateTime(2021, 10, 1), 3, "Борис"},
        };


        [Theory]
        [MemberData(nameof(CorrectCreatePetData))]
        public void CreatePetTest(DateTime birthday, int clientId, string name)
        {
            _mocPetRepository.Setup(repository =>
            repository
                .Create(It.IsNotNull<Pet>()))
                .Returns(1).Verifiable();   

            var result = _petController.Create(new CreatePetRequest
            {
                Birthday = birthday,
                ClientId = clientId,
                Name = name
            });

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsAssignableFrom<int>(((OkObjectResult)result.Result).Value);
            _mocPetRepository.Verify(repository => repository.Create(It.IsNotNull<Pet>()), Times.AtLeastOnce());
        }

    }
}
