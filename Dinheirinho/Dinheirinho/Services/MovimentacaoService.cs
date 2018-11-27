using Dinheirinho.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dinheirinho.Services
{
    public class MovimentacaoService
    {
        public async Task SalvarAsync(Movimentacao item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
                var result = await App.DinheirinhoDatabase.Connection.InsertAsync(item);
            }
            else
            {
                await App.DinheirinhoDatabase.Connection.UpdateAsync(item);
            }
        }

        public async Task DesativarAsync(Movimentacao item)
        {
            item.Ativa = false;
            await SalvarAsync(item);
        }

        public async Task<List<Movimentacao>> ListarTodasAsync(string descricao) =>
            await App.DinheirinhoDatabase.Connection.Table<Movimentacao>().Where(e =>
                e.Ativa
                && (descricao == null || e.Descricao.Contains(descricao))
            ).ToListAsync();

        public async Task<List<Movimentacao>> ListarEntradas(string descricao) =>
            await App.DinheirinhoDatabase.Connection.Table<Movimentacao>().Where(e =>
                e.Ativa
                && e.Tipo == "Entrada"
                && (descricao == null || e.Descricao.Contains(descricao))
            ).ToListAsync();

        public async Task<List<Movimentacao>> ListarSaidas(string descricao) =>
            await App.DinheirinhoDatabase.Connection.Table<Movimentacao>().Where(e =>
                e.Ativa
                && e.Tipo == "Saída"
                && (descricao == null || e.Descricao.Contains(descricao))
            ).ToListAsync();

        public async Task<decimal?> ObterSaldo() => await App.DinheirinhoDatabase.Connection.ExecuteScalarAsync<decimal?>(
            @"
                select 
                    sum (
                        case [Tipo] when 'Entrada' then
                            [Valor]
                        else 
                            [Valor] * -1
                        end
                    )   
                from [Movimentacao]
                where [Ativa] = 1
            "
        );
    }
}
