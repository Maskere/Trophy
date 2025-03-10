namespace ClassLibraryTrophy{
    public class TrophiesRepository{
        List<Trophy> trophies = new();
        private int nextId = 1;

        public TrophiesRepository(){
            this.Add(new Trophy("Marathon", 2021));
            this.Add(new Trophy("Ironman", 2022));
            this.Add(new Trophy("FastCoding", 2022));
            this.Add(new Trophy("FastCoding", 2023));
            this.Add(new Trophy("FastCoding", 2024));
        }

        public List<Trophy>? Get(
                int? year = null,
                string? sortByAscending = null,
                string? sortByDescending = null){
            List<Trophy>? result = new(trophies);

            if(year != null){
                if(year < 1970){
                    throw new ArgumentException("Year cannot be lower than 1970");
                }
                if(year > 2025){
                    throw new ArgumentException("Year cannot be higher than 2025");
                }

                return result.FindAll(t => t.Year == year);
            }

            if(sortByAscending != null){
                if(sortByAscending == "Competition"){
                    //Null check to avoid compiler warning
                    result.Sort((t1,t2) => {
                            if(t1.Competition != null){
                                return t1.Competition.CompareTo(t2.Competition);
                            }

                            return 0;
                            });
                }
                else if(sortByAscending == "Year"){
                        result.Sort((t1,t2) => t1.Year - t2.Year); 
                }
            }

            if(sortByDescending != null){
                if(sortByDescending == "Competition"){
                    //Null check to avoid compiler warning
                    result.Sort((t1,t2) => {
                            if(t2.Competition != null){
                                return t2.Competition.CompareTo(t1.Competition);
                            }

                            return 0;
                            });
                }
                else if(sortByDescending == "Year"){
                    result.Sort((t1,t2) => t2.Year - t1.Year); 
                }
            }
            return result;
        }

        public Trophy? GetById(int id){
            Trophy? getById = trophies.Find(t => t.Id == id);
            if(getById == null){
                throw new ArgumentNullException("Trophy not found");
            }

            return getById;
        }

        public Trophy? Add(Trophy? trophy){
            if(trophy == null){
                throw new ArgumentNullException("Invalid input");
            }
            trophy.Id = nextId++;
            trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id){
            Trophy? toRemove = trophies.Find(t => t.Id == id);
            if (toRemove == null){
                throw new ArgumentNullException("Trophy not found");
            }
            trophies.Remove(toRemove);

            return toRemove;
        }

        public Trophy? Update(int id, Trophy? values){
            Trophy? toUpdate = trophies.Find(t => t.Id == id);

            if (toUpdate == null){
                throw new ArgumentNullException($"Could not find trophy with id {id}");
            }
            if (values != null)
            {
                toUpdate.Competition = values.Competition;
                toUpdate.Year = values.Year;
                return toUpdate;
            }
            else
            {
                throw new ArgumentNullException("Update values are null");
            }
        }
    }
}
