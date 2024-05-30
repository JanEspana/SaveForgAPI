namespace FrogGameAPI.Models.DTO
{
    // resposta a totes les peticions API que enviem
    public class ResponseDTO
    {
        public object? Data { get; set; } //
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; } = "";
    }
}
