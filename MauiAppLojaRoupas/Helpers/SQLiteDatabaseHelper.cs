using MauiAppLojaRoupas.Models;
using SQLite;

namespace MauiAppLojaRoupas.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Roupa>().Wait();
        }

        public Task<int> Insert(Roupa r)
        {
            return _conn.InsertAsync(r);
        }

        public Task<List<Roupa>> Update(Roupa r)
        {
            string sql = "UPDATE Roupa SET Categoria=?, Tamanho=?, Cor=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Roupa>(
                sql, r.Categoria, r.Tamanho, r.Cor, r.Quantidade, r.Preco, r.Id
            );
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Roupa>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Roupa>> GetAll()
        {
            return _conn.Table<Roupa>().ToListAsync();
        }

        public Task<List<Roupa>> Search(string q)
        {
            string sql = "SELECT * FROM Roupa WHERE Categoria LIKE '%" + q + "%'";

            return _conn.QueryAsync<Roupa>(sql);
        }
    }
}
