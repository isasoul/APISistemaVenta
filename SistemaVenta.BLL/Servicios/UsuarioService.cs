using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model.YourOutputDirectory;


namespace SistemaVenta.BLL.Servicios
{
	public class UsuarioService :IUsuarioService
	{

		private readonly IGenericRepository<Rol> _usuarioRepositorio;

		private readonly IMapper _mapper;

		public UsuarioService(IGenericRepository<Rol> usuarioRepositorio, IMapper mapper)
		{
			_usuarioRepositorio = usuarioRepositorio;
			_mapper = mapper;
		}

		public async Task<List<UsuarioDTO>> Lista()
		{
			try
			{
				var queryUsuario = await _usuarioRepositorio.Consultar();
				var listaUsuarios = queryUsuario.Include(rol => rol.IdRolNavigation).ToList();

				return _mapper.Map<List<UsuarioDTO>>(listaUsuarios);
			}
			catch 
			{

				throw;
			}
		}

		public Task<SesionDTO> ValidarCredenciales(string correo, string clave)
		{
			throw new NotImplementedException();
		}

		public Task<UsuarioDTO> Crear(UsuarioDTO modelo)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Editar(UsuarioDTO modelo)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Eliminar(int id)
		{
			throw new NotImplementedException();
		}

	
	}
}
