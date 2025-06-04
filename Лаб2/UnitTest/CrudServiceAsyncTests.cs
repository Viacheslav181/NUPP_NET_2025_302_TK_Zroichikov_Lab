using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Healthcare.Common;
using Moq;
using Xunit;

namespace Healthcare.Tests
{
    public class CrudServiceAsyncTests
    {
        private readonly Mock<ICrudServiceAsync<Patient>> _mockService;
        private readonly Patient _testPatient;

        public CrudServiceAsyncTests()
        {
            _mockService = new Mock<ICrudServiceAsync<Patient>>();

            _testPatient = new Patient
            {
                Name = "Test Patient",
                Age = 45,
                Gender = "Female",
                PatientId = Guid.NewGuid().ToString(),
                Diagnosis = "Cold",
                InsuranceId = "INS001"
            };
        }

        [Fact]
        public async Task CreateAsync_ReturnsTrue()
        {
            _mockService.Setup(s => s.CreateAsync(_testPatient)).ReturnsAsync(true);

            var result = await _mockService.Object.CreateAsync(_testPatient);

            Assert.True(result);
        }

        [Fact]
        public async Task ReadAsync_ReturnsPatient()
        {
            var id = Guid.NewGuid();
            _mockService.Setup(s => s.ReadAsync(id)).ReturnsAsync(_testPatient);

            var result = await _mockService.Object.ReadAsync(id);

            Assert.NotNull(result);
            Assert.Equal("Test Patient", result.Name);
        }

        [Fact]
        public async Task ReadAllAsync_ReturnsList()
        {
            var list = new List<Patient> { _testPatient };
            _mockService.Setup(s => s.ReadAllAsync()).ReturnsAsync(list);

            var result = await _mockService.Object.ReadAllAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task ReadAllPaged_ReturnsPagedList()
        {
            var paged = new List<Patient> { _testPatient };
            _mockService.Setup(s => s.ReadAllAsync(1, 1)).ReturnsAsync(paged);

            var result = await _mockService.Object.ReadAllAsync(1, 1);

            Assert.Single(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsTrue()
        {
            _mockService.Setup(s => s.UpdateAsync(_testPatient)).ReturnsAsync(true);

            var result = await _mockService.Object.UpdateAsync(_testPatient);

            Assert.True(result);
        }

        [Fact]
        public async Task RemoveAsync_ReturnsTrue()
        {
            _mockService.Setup(s => s.RemoveAsync(_testPatient)).ReturnsAsync(true);

            var result = await _mockService.Object.RemoveAsync(_testPatient);

            Assert.True(result);
        }

        [Fact]
        public async Task SaveAsync_ReturnsTrue()
        {
            _mockService.Setup(s => s.SaveAsync()).ReturnsAsync(true);

            var result = await _mockService.Object.SaveAsync();

            Assert.True(result);
        }
    }
}
