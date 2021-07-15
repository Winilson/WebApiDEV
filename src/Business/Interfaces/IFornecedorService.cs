using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<Boolean>Adicionar(Fornecedor fornecedor);
        Task<Boolean>Atualizar(Fornecedor fornecedor);
        Task<Boolean> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
