﻿using Ioasys.IMDb.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Ioasys.IMDb.Domain.Interfaces
{
    public interface IAdministradorRepository: IRepository<Administrador>
    {
        Task<Administrador> ObterAdministradorPor(Guid id);
        Task DesativarAdministrador(Administrador administrador);
    }
}