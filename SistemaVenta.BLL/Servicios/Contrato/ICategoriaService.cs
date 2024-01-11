using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.DTO;
using SistemaVenta.Model.YourOutputDirectory;

namespace SistemaVenta.BLL.Servicios.Contrato
{
	public interface ICategoriaService
	{

		Task<List<CategoriaDTO>> Lista();

	}
}
