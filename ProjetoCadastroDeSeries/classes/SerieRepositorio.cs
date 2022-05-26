using System;
using System.Collections.Generic;
using ProjetoCadastroDeSeries.Interfaces;

namespace ProjetoCadastroDeSeries.classes
{
    public class SerieRepositorio : IRepositório<Series>
    {
        private List<Series> listaSerie = new List<Serie>();
        public void Atualiza(int id, Series entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Series entidade)
        {
            throw new NotImplementedException();
        }

        public List<Series> Lista()
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }

        public Serie RetornaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}