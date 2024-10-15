using System.Text.Json;

namespace Data.ViewModels{
    public class ErrorVM
    {
    public int StatusCode { get; set; }
    public required string Message { get; set; }
    public required string Path { get; set; }
    public override string ToString(){
        return JsonSerializer.Serialize(this);
    }
    }
}