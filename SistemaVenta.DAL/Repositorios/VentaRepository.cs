using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorios;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.Model.YourOutputDirectory;


//-------------------------------METODO PARA REGISTRAR VENTA------------------------------------------------------------

namespace SistemaVenta.DAL.Repositorios
{
	public class VentaRepository : GenericRepository<Venta>, IVentaRepository
	{
		private readonly DbventaContext _dbContext;

		public VentaRepository(DbventaContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Venta> Registrar(Venta modelo)
		{
			Venta ventaGenerada = new Venta();

			using (var transaction = _dbContext.Database.BeginTransaction())
			{
				try
				{
					foreach (DetalleVenta dv in modelo.DetalleVenta)
					{
						Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
						producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
						_dbContext.Productos.Update(producto_encontrado);
					}
					await _dbContext.SaveChangesAsync();

					NumeroDocumento correlativo = _dbContext.NumeroDocumentos.First();
					correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
					correlativo.FechaRegistro = DateTime.Now;

					_dbContext.NumeroDocumentos.Update(correlativo);
					await _dbContext.SaveChangesAsync();

					// formato de numero pedido
					int CantidadDigitos = 4;
					string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
					string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
					numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);

					modelo.NumeroDocumento = numeroVenta;

					await _dbContext.AddAsync(modelo);
					await _dbContext.SaveChangesAsync();

					ventaGenerada = modelo;

					transaction.Commit();

					
                }
				catch (Exception)
				{

					transaction.Rollback();
					throw;
				}
				return ventaGenerada;
			}
		}
	}
}
