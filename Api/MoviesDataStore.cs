using Api.Models;

namespace Api
{
    public class MoviesDataStore
    {
        public static MoviesDataStore Current { get; } = new MoviesDataStore();
        public List<MovieDTO> Movies { get; set; }
        public MoviesDataStore() => Movies = new List<MovieDTO>()
            {
               new MovieDTO
               {
                    Id = 1,
                    Name= "Pandillas de Nueva York",
                    Description="Gangs of new York",
                    Casts = new List<CastDTO>
                    {
                        new CastDTO {Id=1, Name="Daniel Day-Lewis", Character="DDL"},
                        new CastDTO {Id=2, Name="Leonardo Dicaprio", Character="LD"},
                        new CastDTO {Id=3, Name="Liam Neeso", Character="LN"}
                    }
               },
               new MovieDTO
               {
                    Id = 2,
                    Name= "Forrest Gump",
                    Description="Es un chico que sufre un cierto retraso mental",
                    Casts = new List<CastDTO>
                    {
                        new CastDTO {Id=1, Name="Daniel Day-Lewis 2", Character="DDL2"},
                        new CastDTO {Id=2, Name="Leonardo Dicaprio 2", Character="LD2"},
                        new CastDTO {Id=3, Name="Liam Neeso 2", Character="LN2"}
                    }
               },
               new MovieDTO
               {
                    Id = 3,
                    Name= "Taxi Driver",
                    Description="Un taxi en camino",
                    Casts = new List<CastDTO>
                    {
                        new CastDTO {Id=1, Name="Daniel Day-Lewis 3", Character="DDL3"},
                        new CastDTO {Id=2, Name="Leonardo Dicaprio 3", Character="LD3"},
                        new CastDTO {Id=3, Name="Liam Neeso 3", Character="LN3"}
                    }
               }
            };
        
    }
    
}
