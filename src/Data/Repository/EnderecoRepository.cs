using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EnderecoRepository: Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ProdutosDbContext context): base(context) {}

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.FornecedorId == fornecedorId);
        }
    }
}
