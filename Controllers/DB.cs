using SQLite;
using Tarea_1_3.Models;

namespace Tarea_1_3.Controllers {
    public class DB {
        readonly SQLiteAsyncConnection connection;
        public DB() {

        }

        public DB(string path) {
            try {
                connection=new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<People>().Wait();
            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        /*CRUD*/
        public Task<int> add_person(People person) {
            if(person.id==0) {
                return connection.InsertAsync(person);
            } else {
                return connection.UpdateAsync(person);
            }
        }

        public Task<List<People>> list_people() {
            return connection.Table<People>().ToListAsync();
        }

        public Task<People> get_person_id(int id) {
            return connection.Table<People>().Where(p => p.id==id).FirstOrDefaultAsync();
        }

        public Task<int> delete_people(People person) {
            return connection.DeleteAsync(person);
        }

        public Task<int> update_person(People person) {
            if(person.id!=0) {
                return connection.UpdateAsync(person);
            } else {
                throw new ArgumentException("No se puede actualizar una persona con ID 0",nameof(person));
            }
        }
    }
}
