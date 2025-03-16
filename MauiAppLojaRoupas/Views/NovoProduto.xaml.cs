using MauiAppLojaRoupas.Models; 

namespace MauiAppLojaRoupas.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Roupa r = new Roupa
            {
                Categoria = pickerCategoria.SelectedItem.ToString(), 
                Tamanho = pickerTamanho.SelectedItem.ToString(), 
                Cor = pickerCor.SelectedItem.ToString(),
                Quantidade = Convert.ToInt32(txtQuantidade.Text), 
                Preco = Convert.ToDouble(txtPreco.Text) 
            };
            ;

            await App.Db.Insert(r);
            await DisplayAlert("Sucesso!", "Registro Inserido", "Ok");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}