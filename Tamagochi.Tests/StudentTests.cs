using System;
using FluentAssertions;
using NUnit.Framework;
using Tamagochi.Core;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_be_alive_after_birth()
        {
            var student = new Student("John");
            student.IsAlive().Should().BeTrue();
        }

        [TestCase("")]
        [TestCase((string) null)]
        public void Should_not_allow_empty_name(string name)
        {
            Action studentCreation = () => new Student(name);
            studentCreation.Should().Throw<ArgumentException>();
        }
    }
}