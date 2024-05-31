
using Microsoft.AspNetCore.RateLimiting;

namespace AngkorAPI.Controllers;

public class AuthController : ApiControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("Login")]
    [EnableRateLimiting(Constants.LIMIT_3TIMES_15S)]
    public async Task<ActionResult<LoginInfo>> LoginAsync([FromBody] PasswordLoginInput input)
    {
        return await authService.LoginWithPasswordAsync(input);
    }

    [HttpGet("Info")]
    public async Task<ActionResult<LoginInfo>> InfoAsync()
    {
        return await authService.InfoAsync();
    }

    [AllowAnonymous]
    [HttpPost("Refresh")]
    [EnableRateLimiting(Constants.LIMIT_3TIMES_15S)]
    public async Task<ActionResult<LoginInfo>> Refresh() //RefreshTokenInput tokenApiModel)
    {
        return await authService.Refresh();//(tokenApiModel);
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

