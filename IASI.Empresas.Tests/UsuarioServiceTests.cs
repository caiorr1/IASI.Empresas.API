using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASI.Empresas.Tests
{
    public class UsuarioServiceTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();

            _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object);
        }

        [Fact]
        public async Task GetUsuarioByIdAsync_ReturnsUsuarioDto_WhenUsuarioExists()
        {
            // Arrange
            var usuarioId = 1;
            var usuario = new UsuarioEntity
            {
                Id = usuarioId,
                NomeUsuario = "João da Silva",
                Email = "joao.silva@example.com",
                Role = "Gerente"
            };

            _usuarioRepositoryMock.Setup(repo => repo.GetByIdAsync(usuarioId))
                .ReturnsAsync(usuario);

            // Act
            var result = await _usuarioService.GetUsuarioByIdAsync(usuarioId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(usuarioId, result.Id);
            Assert.Equal("João da Silva", result.NomeUsuario);
            Assert.Equal("joao.silva@example.com", result.Email);
            Assert.Equal("Gerente", result.Role);
        }

        [Fact]
        public async Task AddUsuarioAsync_AddsUsuarioToRepository()
        {
            // Arrange
            var usuarioDto = new UsuarioDTO
            {
                NomeUsuario = "Maria Oliveira",
                Email = "maria.oliveira@example.com",
                Role = "Analista"
            };

            _usuarioRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<UsuarioEntity>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            await _usuarioService.AddUsuarioAsync(usuarioDto);

            // Assert
            _usuarioRepositoryMock.Verify(repo => repo.AddAsync(It.Is<UsuarioEntity>(u =>
                u.NomeUsuario == usuarioDto.NomeUsuario &&
                u.Email == usuarioDto.Email &&
                u.Role == usuarioDto.Role
            )), Times.Once);
        }
    }
}
