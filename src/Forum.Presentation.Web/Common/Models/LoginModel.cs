namespace Forum.Presentation.Web.Common.Models;

public record LoginModel(
    Guid? Id,
    string? Username,
    string? Password,
    string? Token
);