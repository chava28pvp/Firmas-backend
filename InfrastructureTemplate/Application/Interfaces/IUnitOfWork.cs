﻿using InfrastructureTemplate.Model;
using System;
using System.Threading.Tasks;

namespace InfrastructureTemplate.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Usuario> UsuarioRepository { get; }
        Task<int> SaveAsync();
    }
}
