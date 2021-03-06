﻿using FanSoft.AM.Domain.Contracts.Repositories;
using FanSoft.AM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoft.AM.Infra.Data.ADO.Repositories
{
    public class PacienteReadRepositoryADO : IPacienteReadRepository
    {
        private readonly AgendaMedicaDataContext _ctx;
        private string _query;

        public PacienteReadRepositoryADO(AgendaMedicaDataContext ctx)
        {
            _ctx = ctx;
            _query = $@"SELECT 
	                        p.Id, p.Nome, p.Sobrenome, p.Nascimento, p.SexoId FROM Paciente p";
        }

        public IEnumerable<Paciente> Get()
        {
            
            var dr = _ctx.ExecuteCommandWithData(_query);

            if (dr.HasRows)
            {
                var pacientes = new List<Paciente>();
                while (dr.Read())
                {
                    pacientes.Add(
                            new Paciente(
                                (int)dr["Id"], dr["Nome"].ToString(), 
                                dr["Sobrenome"].ToString(), (DateTime)dr["Nascimento"],
                                (int)dr["SexoId"])
                        );
                }
                dr.Close();
                return pacientes;
            }

            return null;
        }

        public Paciente Get(int id)
        {
            var dr = _ctx.ExecuteCommandWithData(_query + $" WHERE p.Id = '{id}'");

            if (dr.HasRows)
            {
                var pacientes = new List<Paciente>();
                while (dr.Read())
                {
                    pacientes.Add(
                            new Paciente(
                                (int)dr["Id"], dr["Nome"].ToString(),
                                dr["Sobrenome"].ToString(), (DateTime)dr["Nascimento"],
                                (int)dr["SexoId"])
                        );
                }
                dr.Close();
                return pacientes.First();
            }

            return null;
        }

        public async Task<IEnumerable<Paciente>> GetAsync()
        {
            var dr = await _ctx.ExecuteCommandWithDataAsync(_query);

            if (dr.HasRows)
            {
                var pacientes = new List<Paciente>();
                while (dr.Read())
                {
                    pacientes.Add(
                            new Paciente(
                                (int)dr["Id"], dr["Nome"].ToString(),
                                dr["Sobrenome"].ToString(), (DateTime)dr["Nascimento"],
                                (int)dr["SexoId"])
                        );
                }
                dr.Close();
                return pacientes;
            }

            return null;
        }

        public async Task<Paciente> GetAsync(int id)
        {
            _query += $" WHERE p.Id = '{id}'";
            var dr = await _ctx.ExecuteCommandWithDataAsync(_query);

            if (dr.HasRows)
            {
                var pacientes = new List<Paciente>();
                while (dr.Read())
                {
                    pacientes.Add(
                            new Paciente(
                                (int)dr["Id"], dr["Nome"].ToString(),
                                dr["Sobrenome"].ToString(), (DateTime)dr["Nascimento"],
                                (int)dr["SexoId"])
                        );
                }
                dr.Close();
                return pacientes.First();
            }

            return null;
        }
    }
}
