﻿using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IBuysRepository
    {
        ICollection<Buys> GetBuys();
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Buys</returns>
        Task<List<Buys>> AllAsync();
        /// <summary>
      
        Task<bool> CreateAsync(Buys data);
        /// <summary>
        /// Crea una Buys
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Buys</returns>
        Task<bool> UpdateAsync(int id, Buys data);
        /// <summary>
        /// Actualiza una Buys mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
