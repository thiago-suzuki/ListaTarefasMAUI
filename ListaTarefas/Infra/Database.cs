using SQLite;
using ListaTarefas.Models;

namespace ListaTarefas.Infra
{
    public class Database
    {
        private static SQLiteAsyncConnection DatabaseConnection;

        public Database()
        {
            DatabaseConnection = new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
        }

        public static async Task<Database> Instance()
        {
            var instance = new Database();
            try
            {
                await DatabaseConnection.CreateTableAsync<Tarefa>();
            }
            catch
            {
                throw;
            }
            return instance;
        }

        public Task<List<Tarefa>> GetTarefas()
        {
            return DatabaseConnection.Table<Tarefa>().ToListAsync();
        }

        public Task<int> SalvarTarefa(Tarefa item)
        {
            if (item.ID != 0)
                return DatabaseConnection.UpdateAsync(item);
            else
                return DatabaseConnection.InsertAsync(item);
        }

        public Task<int> DeletarTarefa(Tarefa item)
        {
            return DatabaseConnection.DeleteAsync(item);
        }
    }
}
