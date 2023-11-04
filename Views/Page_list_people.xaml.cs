using Tarea_1_3.Models;

namespace Tarea_1_3.Views;

public partial class Page_list_people:ContentPage {
    public static string temp_names, temp_surnames, temp_email, temp_address;
    public static int temp_id, temp_age;
    People selectedItem = null;

    public Page_list_people() {
        InitializeComponent();
    }

    protected override async void OnAppearing() {
        base.OnAppearing();

        list.ItemsSource=await App.Instancia.list_people();
    }

    private void OnItemTapped(Object sender,SelectionChangedEventArgs e) {
        selectedItem=e.CurrentSelection.FirstOrDefault() as People;

        temp_names=selectedItem.names;
        temp_surnames=selectedItem.surnames;
        temp_email=selectedItem.email;
        temp_address=selectedItem.address;
        temp_age=selectedItem.age;
        temp_id=selectedItem.id;
    }

    private async void update_data(object sender,EventArgs e) {
        if(selectedItem!=null) {
            var response = await DisplayAlert("Accion","Desea editar los datos","NO","YES");

            if(!response) {
                await Navigation.PushAsync(new Page_update());
                selectedItem=null;
            }
        } else {
            await DisplayAlert("Alerta","Seleccione una persona","Ok");
        }
    }

    private async void view_data(object sender,EventArgs e) {
        if(selectedItem!=null){
            await Navigation.PushAsync(new Page_view_data());
            selectedItem=null;
        }else{
            await DisplayAlert("Alerta","Seleccione una persona","Ok");
        }
    }

    private async void question_delete(object sender,EventArgs e) {
        if(selectedItem!=null) {
            var response = await DisplayAlert("Accion","Desea eliminar la persona indicada","NO","YES");

            if(!response) {
                await App.Instancia.delete_people(selectedItem);
                list.ItemsSource=await App.Instancia.list_people();
                selectedItem=null;
            }
        } else {
            await DisplayAlert("Alerta","Seleccione un ubicacion","Ok");
        }
    }
}
