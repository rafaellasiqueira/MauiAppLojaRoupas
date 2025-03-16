using System.Collections.ObjectModel;
using System.Linq;
using MauiAppLojaRoupas.Models;

namespace MauiAppLojaRoupas.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Roupa> lista = new ObservableCollection<Roupa>();

    public ListaProduto()
    {
        InitializeComponent();
        lst_produtos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        List<Roupa> tmp = await App.Db.GetAll();

        lista.Clear();
        foreach (var item in tmp)
        {
            lista.Add(item);
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        lista.Clear();

        List<Roupa> tmp = await App.Db.Search(q);

        foreach (var item in tmp)
        {
            lista.Add(item);
        }
    }

    private async void AddProduct(Roupa newProduct)
    {
        if (!lista.Any(p => p.Id == newProduct.Id))
        {
            lista.Add(newProduct);
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);
        string msg = $"O Total é {soma:C}";
        DisplayAlert("Total das Roupas", msg, "OK");
    }
}
