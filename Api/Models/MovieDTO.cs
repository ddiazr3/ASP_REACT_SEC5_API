namespace Api.Models
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CastDTO> Casts { get; set; } = new List<CastDTO>();
    }
}
