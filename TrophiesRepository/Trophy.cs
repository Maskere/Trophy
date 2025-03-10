namespace ClassLibraryTrophy {
    public class Trophy {
        private int id;
        private string? competition;
        private int year;

        public Trophy(string? competition, int year){
            Id = id;
            Competition = competition;
            Year = year;
        }

        public int Id{
            get => id;
            set{
                id = value;
            }
        }

        public string? Competition{
            get => competition;
            set{
                if(value == null){
                    throw new ArgumentNullException("Value cannot be null");
                }
                if(value.Length < 3){
                    throw new ArgumentException("Value cannot be lower than 3 characters");
                }
                competition = value;
            }
        }

        public int Year{
            get => year;
            set{
                if(value < 1970){
                    throw new ArgumentException("Value cannot be lower than 1970");
                }
                if(value > 2025){
                    throw new ArgumentException("Value cannot be higher than 2025");
                }
                year = value;
            }
        }

        public override string ToString() {
            return $"Trophy {Id}\nCompetition {Competition}\nYear {Year}";
        }
    }
}
