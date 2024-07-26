using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Application.MediaR;
using MinimalWebApi1.Controllers;

namespace Tests;

    public class StudentsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly StudentsController _controller;

        public StudentsControllerTests()
        {
            // Mock<IMediator> is used to mock the MediatR mediator to test
            // the controller methods without invoking actual handlers. (using the Db)
            _mediatorMock = new Mock<IMediator>();
            _controller = new StudentsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAllStudents_ReturnsOkResult_WithListOfStudents()
        {
            // Arrange
            var students = new List<StudentDto>
            {
                new StudentDto(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true),
                new StudentDto(2, "Jane", "Smith", new DateTime(2001, 2, 2), "jane.smith@example.com", false)
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllStudentsCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(students);

            // Act
            var result = await _controller.GetAllStudents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<StudentDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetStudentById_ReturnsOkResult_WithStudent()
        {
            // Arrange
            var student = new StudentDto(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true);
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetStudentByIdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(student);

            // Act
            var result = await _controller.GetStudentById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<StudentDto>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task GetStudentById_ReturnsNotFoundResult_WhenStudentNotFound()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetStudentByIdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((StudentDto)null);

            // Act
            var result = await _controller.GetStudentById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task AddStudent_ReturnsCreatedAtAction_WithStudent()
        {
            // Arrange
            var studentDto = new StudentDto(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true);
            _mediatorMock.Setup(m => m.Send(It.IsAny<AddStudentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(studentDto);

            // Act
            var result = await _controller.AddStudent(studentDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<StudentDto>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task UpdateStudent_ReturnsOkResult()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateStudentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateStudent(new StudentDto(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true));

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateStudent_ReturnsNotFoundResult_WhenUpdateFails()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateStudentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateStudent(new StudentDto(1, "John", "Doe", new DateTime(2000, 1, 1), "john.doe@example.com", true));

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteStudent_ReturnsOkResult()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteStudentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteStudent(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteStudent_ReturnsNotFoundResult_WhenDeleteFails()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteStudentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteStudent(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }

