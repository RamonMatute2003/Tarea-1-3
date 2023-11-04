namespace Tarea_1_3.Views;

public partial class Page_view_data : ContentPage
{
	public Page_view_data()
	{
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
}