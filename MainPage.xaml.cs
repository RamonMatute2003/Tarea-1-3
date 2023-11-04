using Tarea_1_3.Views;

namespace Tarea_1_3 {
    public partial class MainPage:ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private async void save(object sender,EventArgs e) {
            if(!(string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_surname.Text)||string.IsNullOrEmpty(txt_email.Text)||string.IsNullOrEmpty(txt_address.Text))) {
                var person = new Models.People {
                    names=txt_name.Text,
                    surnames=txt_surname.Text,
                    age=Convert.ToInt32(txt_age.Text),
                    email=txt_email.Text,
                    address=txt_address.Text
                };

                if(await App.Instancia.add_person(person)>0) {
                    await DisplayAlert("Aviso","Persona agregada","OK");
                } else {
                    await DisplayAlert("Alerta","Ocurrio un error","OK");
                }
            }else{
                await DisplayAlert("Alerta","No dejar campos vacios","OK");
            }
        }

        private async void view_list(object sender,EventArgs e) {
            await Navigation.PushAsync(new Page_list_people());
        }
    }
}