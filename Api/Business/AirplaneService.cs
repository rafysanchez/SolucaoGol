using Api.Data;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class AirplaneService
    {
        private ApplicationDbContext _context;
        public AirplaneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public AirplaneModel Obter(int id =0)
        {
            
            if (id>=0)
            {
                return _context.Airplanes.Where(
                    p => p.AirplaneId == id).FirstOrDefault();
            }
            else
                return null;
        }

        public IEnumerable<AirplaneModel> ListarTodos()
        {
            return _context.Airplanes
                .OrderBy(p => p.AirplaneId).ToList();
        }

        public Resultado Incluir(AirplaneModel dados)
        {
            Resultado resultado = DadosValidos(dados);
            resultado.Acao = "Inclusão de Aeroplano";

            if (resultado.Inconsistencias.Count == 0 &&
                _context.Airplanes.Where(
                p => p.AirplaneId == dados.AirplaneId).Count() > 0)
            {
                resultado.Inconsistencias.Add(
                    "Aeroplano já cadastrado");
            }

            if (resultado.Inconsistencias.Count == 0)
            {
                _context.Airplanes.Add(dados);
                _context.SaveChanges();
            }

            return resultado;
        }

        public Resultado Atualizar(AirplaneModel dados)
        {
            Resultado resultado = DadosValidos(dados);
            resultado.Acao = "Atualização de Aeroplano";

            if (resultado.Inconsistencias.Count == 0)
            {
                AirplaneModel aeroplano = _context.Airplanes.Where(
                    p => p.AirplaneId == dados.AirplaneId).FirstOrDefault();

                if (aeroplano == null)
                {
                    resultado.Inconsistencias.Add(
                        "Aeroplano não encontrado");
                }
                else
                {
                    aeroplano.Modelo = dados.Modelo;
                    aeroplano.QuantidadePassageiros = dados.QuantidadePassageiros;
                    aeroplano.DtCriacao = dados.DtCriacao;
                    _context.SaveChanges();
                }
            }

            return resultado;
        }

        public Resultado Excluir(int id)
        {
            Resultado resultado = new Resultado();
            resultado.Acao = "Exclusão de Aeroplano";

            AirplaneModel aeroplano = Obter(id);
            if (aeroplano == null)
            {
                resultado.Inconsistencias.Add(
                    "Aeroplano não encontrado");
            }
            else
            {
                _context.Airplanes.Remove(aeroplano);
                _context.SaveChanges();
            }

            return resultado;
        }

        private Resultado DadosValidos(AirplaneModel aeroplano)
        {
            var resultado = new Resultado();
            if (aeroplano == null)
            {
                resultado.Inconsistencias.Add(
                    "Preencha os dados do aeroplano");
            }
            else
            {
               
                if (String.IsNullOrWhiteSpace(aeroplano.Modelo))
                {
                    resultado.Inconsistencias.Add(
                        "Preencha o Nome do Modelo");
                }
                if (aeroplano.QuantidadePassageiros <= 0)
                {
                    resultado.Inconsistencias.Add(
                        "A quantidade de passageiros deve ser maior do que zero");
                }
            }

            return resultado;
        }






    }
}
