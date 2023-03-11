using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task5_CRUD.Domain;
using Task5_CRUD.Domain.Interfaces;
using Task5_CRUD.Models;
using Task5_CRUD.Models.DrillBlock;

namespace Task5_CRUD.Controllers;

[ApiController]
[Route("drillBlocks/")]
public class DrillBlockController : Controller
{
    private readonly IDrillBlockRepository _drillBlockRepository;
    private readonly IMapper _mapper;

    public DrillBlockController(
        IDrillBlockRepository drillBlockRepository,
        IMapper mapper
        )
    {
        _drillBlockRepository = drillBlockRepository ??
            throw new ArgumentNullException(nameof(drillBlockRepository));

        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AddDrillBlockAsync(
        [FromBody] AddDrillBlockRequestDto addDrillBlockRequestDto
        )
    {               
        DrillBlock drillBlock = _mapper.Map<DrillBlock>(addDrillBlockRequestDto);
        drillBlock.UpdateDate = DateTime.UtcNow;
        
        await _drillBlockRepository.AddAsync(drillBlock);
        
        return NoContent();
        
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<GetDrillBlockResponseDto>))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetDrillBlockResponseDto>> GetDrillBlockAsync(
        [FromRoute] int id
        )
    {   
        DrillBlock drillBlock = await _drillBlockRepository.GetByIdAsync(id);

        var getHDrillBlockResponseDto = _mapper.Map<GetDrillBlockResponseDto>(drillBlock);

        return Ok(getHDrillBlockResponseDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdateDrillBlockAsync(
        [FromRoute] int id,
        [FromBody] UpdateDrillBlockRequestDto updateDrillBlockRequestDto
    )
    {  
        DrillBlock updatedDrillBlock = _mapper.Map<DrillBlock>(updateDrillBlockRequestDto);
        updatedDrillBlock.Id = id;
        updatedDrillBlock.UpdateDate = DateTime.UtcNow;

        await _drillBlockRepository.UpdateAsync(updatedDrillBlock);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDrillBlockAsync(
        [FromRoute] int id
    )
    {
        await _drillBlockRepository.RemoveAsync(new DrillBlock { Id = id });
                    
        return NoContent();
    }
}