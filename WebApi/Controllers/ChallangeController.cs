using Domain.Dtos;
using Infrastructura.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ChallangeController : ControllerBase
{
    private readonly IChallangeServices _ChallangeService;

    public ChallangeController(IChallangeServices ChallangeService)
    {
        _ChallangeService = ChallangeService;
    }

    [HttpGet]
    public async Task<Response<List<GEtChallangeDto>>> Get()
    {
        var Challanges = await _ChallangeService.GetChallange();
        return Challanges;
    }
    
    [HttpPost]
    public async Task<Response<AddChallangeDto>> Post(AddChallangeDto Challange)
    {
        var newChallange = await _ChallangeService.AddChallange(Challange);
        return newChallange;
    }
    
    [HttpPut]
    public async Task<Response<AddChallangeDto>> Put(AddChallangeDto Challange)
    {
        var updatedChallange = await _ChallangeService.UpdateChallange(Challange);
        return updatedChallange;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var Challange = await _ChallangeService.DaleteChallange(id);
        return Challange;
    }

}