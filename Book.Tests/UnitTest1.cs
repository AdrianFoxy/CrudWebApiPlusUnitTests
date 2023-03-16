using CrudWebApiPlusUnitTests.Controllers;
using CrudWebApiPlusUnitTests.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Tests
{
    public class BookControllerTests
    {
        [Fact]
        public async void GetBooks_ReturnsOkResult()
        {
            // Arrange
            var controller = new BookController();
            // Act
            var result = await controller.GetBooks();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void GetSingleBook_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var controller = new BookController();
            int id = 1;
            // Act
            var result = await controller.GetSingleBook(id);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void GetSingleBook_WithInvalidId_ReturnsBadRequestResult()
        {
            // Arrange
            var controller = new BookController();
            int id = 10;
            // Act
            var result = await controller.GetSingleBook(id);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async void AddBook_ReturnsOkResult()
        {
            // Arrange
            var controller = new BookController();
            var newBook = new CrudWebApiPlusUnitTests.Models.Book { Id = 3, Title = "Glass throne", Author = "Sara Maas", Genre = "Fantasy", Price = 300 };
            // Act
            var result = await controller.AddBook(newBook);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void UpdateBook_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var controller = new BookController();
            var bookToUpdate = new CrudWebApiPlusUnitTests.Models.Book { Id = 1, Title = "New Title", Author = "George R. R. Martin", Genre = "Action · Adventure · Fantasy · Serial drama", Price = 200 };
            // Act
            var result = await controller.UpdateBook(bookToUpdate);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void UpdateBook_WithInvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var controller = new BookController();
            var bookToUpdate = new CrudWebApiPlusUnitTests.Models.Book { Id = 8, Title = "New Title", Author = "New Author", Genre = "New Genre", Price = 300 };
            // Act
            var result = await controller.UpdateBook(bookToUpdate);
            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }


        [Fact]
        public async void Delete_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var controller = new BookController();
            int idToDelete = 2;
            // Act
            var result = await controller.Delete(idToDelete);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void Delete_WithInvalidId_ReturnsBadRequestResult()
        {
            // Arrange
            var controller = new BookController();
            int idToDelete = 8;
            // Act
            var result = await controller.Delete(idToDelete);
            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }
    }
}