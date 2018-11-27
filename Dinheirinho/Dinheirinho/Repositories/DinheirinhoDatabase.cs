using Dinheirinho.Models;
using SQLite;

namespace Dinheirinho.Repositories
{
    public class DinheirinhoDatabase
    {
        public SQLiteAsyncConnection Connection { get; private set; }

        public DinheirinhoDatabase(string databasePath)
        {
            Connection = new SQLiteAsyncConnection(databasePath);

            Connection.CreateTableAsync<Movimentacao>();
        }
    }
}
