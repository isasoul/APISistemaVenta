using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace SistemaVenta.DAL.Repositorios
{
	public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
	{

		private readonly DbContext _dbContext;

		public GenericRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}


		public Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
		{
			try
			{
				TModel modelo = await
			}
			catch (Exception)
			{

				throw;
			}
		}

		public Task<TModel> Crear(TModel modelo)
		{
			try
			{

			}
			catch (Exception)
			{

				throw;
			}
		}

		public Task<bool> Editar(TModel modelo)
		{
			try
			{

			}
			catch (Exception)
			{

				throw;
			}
		}
	

		public Task<bool> Eliminar(TModel modelo)
		{
			try
			{

			}
			catch (Exception)
			{

				throw;
			}
		}

		public Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
		{
			try
			{

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
