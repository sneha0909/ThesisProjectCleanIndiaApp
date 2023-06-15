using API.DTOs;

public class StateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<CityDto> Cities { get; set; }
}
