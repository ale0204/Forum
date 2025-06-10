namespace Forum.Presentation.Web.Common.Models;

public record UserModel(
    Guid? Id,
    string? Username,
    string? Password,
    string? PasswordConfirm
);
