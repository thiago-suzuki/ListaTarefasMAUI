using ListaTarefas.Infra;
using ListaTarefas.Models;
using System.Threading.Tasks;

namespace ListaTarefas.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TarefaPage : ContentPage
{
    public Database Database { get; set; }
	public TarefaPage()
	{
		InitializeComponent();
	}

    public async void Salvar(object sender, EventArgs e)
    {
        var tarefa = (Tarefa)BindingContext;

        if (tarefa.Nome == "" || tarefa.Nome == null || tarefa.Nota == "" || tarefa.Nota == null)
            await DisplayAlert("Erro", "Preencha os dados corretamente!", "OK");
        else
        {
            await Database.SalvarTarefa(tarefa);
            await Navigation.PopAsync();
        } 
    }

    public async void Deletar(object sender, EventArgs e)
    {
        var tarefa = (Tarefa)BindingContext;
        await Database.DeletarTarefa(tarefa);
        await Navigation.PopAsync();
    }

    public async void Cancelar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}