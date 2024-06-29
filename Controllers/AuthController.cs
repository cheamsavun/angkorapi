using Microsoft.AspNetCore.RateLimiting;

namespace AngkorAPI.Controllers;

public class AuthController(IAuthService authService) : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("Login")]
    [EnableRateLimiting(Constants.LIMIT_3TIMES_15S)]
    public async Task<ActionResult<LoginInfo>> LoginAsync(PasswordLoginInput input)
    {
        var login = await authService.LoginWithPasswordAsync(input);
        return login;
    }

    [HttpGet("Info")]
    public async Task<ActionResult<LoginInfo>> InfoAsync()
    {
        return await authService.InfoAsync();
    }

    [AllowAnonymous]
    [HttpPost("Refresh")]
    [EnableRateLimiting(Constants.LIMIT_3TIMES_15S)]
    public async Task<ActionResult<LoginInfo>> Refresh()  
    {
        return await authService.Refresh(); 
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        await authService.LogoutAsync();
        return Ok();
    }


    [HttpPost]
    [EnableRateLimiting(Constants.LIMIT_3TIMES_15S)]
    [Route("ChangePassword")]
    public async Task<IActionResult> ChangePasswordAsync(ChangePassordInput input)
    {
        await authService.ChangePasswordAsync(input);
        return Ok();
    }

    
}