using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Constants;
using BusinessLogic.DomainObjects;
using BusinessLogic.Services;
using DataAccess.FakeData;
using FluentAssertions;
using NUnit.Framework;

namespace BusinessLogic.Tests
{
    [TestFixture]
    public class EngineerServiceTests
    {
        private IEngineersService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new EngineersService();
        }

        [Test]
        public void ShouldReturnAllEngineers_WhenRotaIsEmpty()
        {
            // given
            var rota = new List<RotaEntry>();

            // when
            var availableEngineers = _sut.GetAvailableEngineers(FakeEntities.Engineers, rota);

            // then
            availableEngineers.Should().NotBeEmpty();
            availableEngineers.Count.Should().Be(FakeEntities.Engineers.Count);
        }

        [Test]
        public void ShouldNotReturnEngineersThatHadShiftDayBefore()
        {
            // given
            var unavailableEngineer = FakeEntities.Engineers.First();

            var rota = new List<RotaEntry>
            {
                new RotaEntry
                {
                    DateTime = new DateTime(2013, 11, 11),
                    Engineer = unavailableEngineer,
                    HoursInShift = ConstantValues.HoursInDailySupport
                }
            };

            // when
            var availableEngineers = _sut.GetAvailableEngineers(FakeEntities.Engineers, rota);

            // then
            availableEngineers.Should().NotBeEmpty();
            availableEngineers.Count.Should().Be(FakeEntities.Engineers.Count - 1);
            availableEngineers.SingleOrDefault(engineer => engineer.Id == unavailableEngineer.Id).Should().BeNull();
        }

        [Test]
        public void ShouldNotReturnEngineersThatHadTwoShiftInLastTwoWeeks()
        {
            // given
            var unavailableEngineer = FakeEntities.Engineers.First();

            var rota = new List<RotaEntry>
            {
                new RotaEntry
                {
                    DateTime = DateTime.Now.Date.AddDays(-2),
                    Engineer = unavailableEngineer,
                    HoursInShift = ConstantValues.HoursInDailySupport
                },

                new RotaEntry
                {
                    DateTime = DateTime.Now.Date.AddDays(-11),
                    Engineer = unavailableEngineer,
                    HoursInShift = ConstantValues.HoursInDailySupport
                }
            };

            // when
            var availableEngineers = _sut.GetAvailableEngineers(FakeEntities.Engineers, rota);

            // then
            availableEngineers.Should().NotBeEmpty();
            availableEngineers.Count.Should().Be(FakeEntities.Engineers.Count - 1);
            availableEngineers.SingleOrDefault(engineer => engineer.Id == unavailableEngineer.Id).Should().BeNull();
        }
    }
}
