using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using Core.Extensions;
using Core.Services;
using DataAccess.FakeData;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class RotaBuilderTests
    {
        private readonly DateTime _anyDate = new DateTime(2018, 07, 02);

        private Mock<IDateTimeProvider> _dateTimeProvider;
        private Mock<IEngineerRepository> _engineerRepository;
        private Mock<IRandomService> _randomService;
        private Mock<IEngineersService> _engineersService;
        private IRotaBuilder _sut;

        [SetUp]
        public void SetUp()
        {
            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _engineerRepository = new Mock<IEngineerRepository>();
            _randomService = new Mock<IRandomService>();
            _engineersService = new Mock<IEngineersService>();

            _dateTimeProvider
                .SetupGet(provider => provider.Now)
                .Returns(_anyDate);

            _randomService
                .Setup(service => service.GetNumberBetween(0, It.IsAny<int>()))
                .Returns(0);

            _randomService
                .Setup(service => service.GetDifferentNumbersFromRange(0, It.IsAny<int>(), 2))
                .Returns(new List<int> {0, 1});

            _engineerRepository
                .Setup(repository => repository.GetEngineers())
                .ReturnsAsync(FakeEntities.Engineers);

            _engineersService
                .Setup(service =>
                    service.GetAvailableEngineers(It.IsAny<IList<Engineer>>(),
                        It.IsAny<IList<RotaEntry>>()))
                .Returns(FakeEntities.Engineers);

            _sut = new RotaBuilder(_dateTimeProvider.Object,
                _engineerRepository.Object,
                _randomService.Object,
                _engineersService.Object);
        }

        [Test]
        public async Task ShouldNotInvoleWeekends()
        {
            // when
            var rota = await _sut.BuildRota(_anyDate.AddDays(14));

            // then
            rota.Any(entry =>
                    entry.DateTime.IsWeekend())
                .Should().BeFalse();
        }

        [Test]
        public async Task ShouldReturnEmptyRota_WhenNoEngineersAreAvailable()
        {
            // given
            _engineerRepository
                .Setup(repo => repo.GetEngineers())
                .ReturnsAsync(new List<Engineer>());

            // when
            var rota = await _sut.BuildRota(_anyDate.AddDays(14));

            // then
            rota.Count.Should().Be(0);
        }
    }
}
