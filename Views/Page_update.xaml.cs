using System.Collections.Generic;

namespace Tarea_1_3.Views;

public partial class Page_update:ContentPage {
    public Page_update() {
        InitializeComponent();
    }

    protected override void OnAppearing() {
        base.OnAppearing();

        txt_name.Text=Page_list_people.temp_names;
        txt_surname.Text=Page_list_people.temp_surnames;
        txt_email.Text=Page_list_people.temp_email;
        txt_age.Text=Page_list_people.temp_age.ToString();
        txt_address.Text=Page_list_people.temp_address;
    }

    private async void update_data(object sender,EventArgs e) {

        if(!(string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_surname.Text)||string.IsNullOrEmpty(txt_email.Text)||string.IsNullOrEmpty(txt_address.Text))) {
            var person = new Models.People {
                id=Page_list_people.temp_id,
                names=txt_name.Text,
                surnames=txt_surname.Text,
                age=Convert.ToInt32(txt_age.Text),
                email=txt_email.Text,
                address=txt_address.Text
            };

            await App.Instancia.update_person(person);
            await Navigation.PopAsync();
        } else {
            await DisplayAlert("Alerta","No dejar campos vacios","OK");
        }
    }
}