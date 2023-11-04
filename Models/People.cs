using SQLite;

namespace Tarea_1_3.Models {
    public class People {
        [PrimaryKey, AutoIncrement]
        public int id
        {
            get; set;
        }

        [MaxLength(100)]
        public string names
        {
            get; set;
        }

        [MaxLength(100)]
        public string surnames
        {
            get; set;
        }

        [MaxLength(2)]
        public int age
        {
            get; set;
        }

        [MaxLength(100)]
        public string email
        {
            get; set;
        }

        [MaxLength(200)]
        public string address
        {
            get; set;
        }
    }
}
