﻿namespace Tarea_1_3 {
    public partial class App:Application {

        static Controllers.DB db_proc;
        public static Controllers.DB Instancia
        {
            get {
                if(db_proc==null) {
                    string db_name = "PeopleDB.db3";
                    string db_path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string db_full = Path.Combine(db_path,db_name);
                    db_proc=new Controllers.DB(db_full);
                }

                return db_proc;
            }
        }

        public App() {
            InitializeComponent();

            MainPage=new AppShell();
        }
    }
}