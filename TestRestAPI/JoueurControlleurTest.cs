using APIEquipe.Controllers;
using Moq;
using Services;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EquipeDTO;

namespace TestRestAPI
{
    
    public class JoueurControlleurTest
    {
        private readonly JoueurController _controller;
        private readonly Mock<IJoueurService> _mockJoueurService;


        public JoueurControlleurTest()
        {
            _mockJoueurService = new Mock<IJoueurService>();
            _controller = new JoueurController(_mockJoueurService.Object);
        }

        [Fact]
        public async Task TestJoueurGetAll()
        {
            // Arrange
            _mockJoueurService.Setup(x => x.GetAll());

            // Act
            var result = _controller.Index();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<JoueurDTO>>(okResult.Value);
            _mockJoueurService.Verify(x => x.GetAll(), Times.Once);
        }

        public async Task TestJoueurGetById()
        {
            // Arrange
            int id = 1;
            var product = new JoueurDTO { Id = id };
            _mockJoueurService.Setup(x => x.GetById(id))
                .Returns(product);

            // Act
            var result = _controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(product, okResult.Value);
            _mockJoueurService.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public async Task TestJoueurGetById_NotFound()
        {
            // Arrange
            int id = 1;
            _mockJoueurService.Setup(x => x.GetById(id))
                .Returns((JoueurDTO)null);

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockJoueurService.Verify(x => x.GetById(id), Times.Once);
        }

        [Fact]
        public async Task TestJoueurUpdate()
        {
            // Arrange
            int id = 1;
            var product = new JoueurDTO { Id = id };
            _mockJoueurService.Setup(x => x.GetById(id))
                .Returns(product);
            _mockJoueurService.Setup(x => x.Update(product,id));

            // Act
            var result = _controller.Update(id, product);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockJoueurService.Verify(x => x.GetById(id), Times.Once);
            _mockJoueurService.Verify(x => x.Update(product, id), Times.Once);
        }

        [Fact]
        public async Task TestJoueurUpdate_NotFound()
        {
            // Arrange
            int id = 1;
            var product = new JoueurDTO { Id = id };
            _mockJoueurService.Setup(x => x.GetById(id))
                .Returns((JoueurDTO)null);


            // Act
            var result = _controller.Update(id, product);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockJoueurService.Verify(x => x.GetById(id), Times.Once);
            _mockJoueurService.Verify(x => x.Update(product, id), Times.Never);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenProductNotExists()
        {
            // Arrange
            var productId = 1;
            var productServiceMock = new Mock<IJoueurService>();
            productServiceMock.Setup(x => x.GetById(productId)).Returns((JoueurDTO)null);
            var controller = new JoueurController(productServiceMock.Object);

            // Act
            var result = controller.Delete(productId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }



    }




}
