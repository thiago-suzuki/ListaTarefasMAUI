using SQLite;

namespace ListaTarefas.Models
{
    public class Tarefa
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Nota { get; set; }
        public bool Concluido { get; set; }
    }
}
