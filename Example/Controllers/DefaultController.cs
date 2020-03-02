using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/")]
public class DefaultController : ControllerBase
{
    public string DefaultGet()
    {
        return "Hello wrold 👲";
    }
}