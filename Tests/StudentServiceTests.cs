using Application.DTOs;
using Application.Services;
using Domain.Models;
using Infrastructure.Repositories;
using Moq;

namespace Tests;

    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepo> _studentRepoMock;
        private readonly IStudentService _studentService;

        public StudentServiceTests()
        {
            _studentRepoMock = new Mock<IStudentRepo>();
            _studentService = new StudentService(_studentRepoMock.Object);
        }

        [Fact]
        public async Task GetStudentByIdAsync_ReturnsStudentDto_WhenStudentExists()
        {
            // Arrange
            var student = new Student(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true);
            _studentRepoMock.Setup(repo => repo.GetStudentByIdAsync(1)).ReturnsAsync(student);

            // Act
            var result = await _studentService.GetStudentByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetStudentByIdAsync_ReturnsNull_WhenStudentDoesNotExist()
        {
            // Arrange
            _studentRepoMock.Setup(repo => repo.GetStudentByIdAsync(1)).ReturnsAsync((Student)null);

            // Act
            var result = await _studentService.GetStudentByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllStudentsAsync_ReturnsListOfStudentDtos()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true),
                new Student(2, "Jane", "Smith", new DateTime(2001, 2, 2), "jane.smith@example.com", false)
            };
            _studentRepoMock.Setup(repo => repo.GetAllStudentsAsync()).ReturnsAsync(students);

            // Act
            var result = await _studentService.GetAllStudentsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddStudentAsync_ReturnsStudentDto()
        {
            // Arrange
            var studentDto = new StudentDto(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true);
            var student = new Student(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true);
            _studentRepoMock.Setup(repo => repo.AddStudentAsync(It.IsAny<Student>())).ReturnsAsync(student);

            // Act
            var result = await _studentService.AddStudentAsync(studentDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task UpdateStudentAsync_ReturnsTrue_WhenUpdateIsSuccessful()
        {
            // Arrange
            var studentDto = new StudentDto(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true);
            _studentRepoMock.Setup(repo => repo.UpdateStudentAsync(It.IsAny<Student>())).ReturnsAsync(true);

            // Act
            var result = await _studentService.UpdateStudentAsync(studentDto);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteStudentAsync_ReturnsTrue_WhenDeleteIsSuccessful()
        {
            // Arrange
            var student = new Student(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true);
            _studentRepoMock.Setup(repo => repo.GetStudentByIdAsync(1)).ReturnsAsync(student);
            _studentRepoMock.Setup(repo => repo.DeleteStudentAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _studentService.DeleteStudentAsync(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteStudentAsync_ReturnsFalse_WhenStudentDoesNotExist()
        {
            // Arrange
            _studentRepoMock.Setup(repo => repo.GetStudentByIdAsync(1)).ReturnsAsync((Student)null);

            // Act
            var result = await _studentService.DeleteStudentAsync(1);

            // Assert
            Assert.False(result);
        }
    }

