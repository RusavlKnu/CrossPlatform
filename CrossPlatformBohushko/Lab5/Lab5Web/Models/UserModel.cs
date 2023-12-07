using System.Security.Claims;

namespace Lab5Web.Models;

public class UserModel
{
    private string? _userName;
    private string? _email;
    private string? _country;
    public UserModel(ClaimsPrincipal user)
    {
        _userName = user.Identity?.Name;
        _email = user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
        _country = user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Country)?.Value;
    }
}