using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuarioDTOs = new List<UsuarioDTO>();

            foreach (var usuario in usuarios)
            {
                usuarioDTOs.Add(new UsuarioDTO
                {
                    Id = usuario.Id,
                    NomeUsuario = usuario.NomeUsuario,
                    Email = usuario.Email,
                    Role = usuario.Role,
                    Ativo = usuario.Ativo
                });
            }
            return usuarioDTOs;
        }

        public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Role = usuario.Role,
                Ativo = usuario.Ativo
            };
        }

        public async Task AddUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = new UsuarioEntity
            {
                NomeUsuario = usuarioDTO.NomeUsuario,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha,
                Role = usuarioDTO.Role,
                Ativo = usuarioDTO.Ativo,
                DataCriacao = DateTime.UtcNow
            };
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioDTO.Id);
            if (usuario != null)
            {
                usuario.NomeUsuario = usuarioDTO.NomeUsuario;
                usuario.Email = usuarioDTO.Email;
                usuario.Role = usuarioDTO.Role;
                usuario.Ativo = usuarioDTO.Ativo;
                usuario.DataAtualizacao = DateTime.UtcNow;
                await _usuarioRepository.UpdateAsync(usuario);
            }
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
