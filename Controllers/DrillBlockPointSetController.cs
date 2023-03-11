using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task5_CRUD.Domain;
using Task5_CRUD.Domain.Interfaces;
using Task5_CRUD.Models.DrillBlockPointSet;

namespace Task5_CRUD.Controllers;

[ApiController]
[Route("drillBlockPointSets/")]
public class DrillBlockPointSetController : Controller
{
    private readonly IDrillBlockPointSetRepository _drillBlockPointSetRepository;
    private readonly IMapper _mapper;

    public DrillBlockPointSetController(
        IDrillBlockPointSetRepository drillBlockPointSetRepository,
        IMapper mapper
        )
    {
        _drillBlockPointSetRepository = drillBlockPointSetRepository ??
            throw new ArgumentNullException(nameof(drillBlockPointSetRepository));

        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AddDrillBlockPointSetAsync(
        [FromBody] AddDrillBlockPointSetRequestDto addDrillBlockPointSetRequestDto
        )
    {               
        DrillBlockPointSet drillBlockPointSet = _mapper.Map<DrillBlockPointSet>(addDrillBlockPointSetRequestDto);
        
        await _drillBlockPointSetRepository.AddAsync(drillBlockPointSet);
        
        return NoContent();
        
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<GetDrillBlockPointSetResponseDto>))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetDrillBlockPointSetResponseDto>> GetDrillBlockPointSetAsync(
        [FromRoute] int id
        )
    {   
        DrillBlockPointSet drillBlockPointSet = await _drillBlockPointSetRepository.GetByIdAsync(id);

        var getDrillBlockPointSetResponseDto = _mapper.Map<GetDrillBlockPointSetResponseDto>(drillBlockPointSet);

        return Ok(getDrillBlockPointSetResponseDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdateHoleAsync(
        [FromRoute] int id,
        [FromBody] UpdateDrillBlockPointSetRequestDto updateDrillBlockPointSetRequestDto
    )
    {  
        DrillBlockPointSet updatedDrillBlockPointSet = _mapper.Map<DrillBlockPointSet>(updateDrillBlockPointSetRequestDto);
        updatedDrillBlockPointSet.Id = id;

        await _drillBlockPointSetRepository.UpdateAsync(updatedDrillBlockPointSet);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDrillBlockPointSetAsync(
        [FromRoute] int id
    )
    {
        await _drillBlockPointSetRepository.RemoveAsync(new DrillBlockPointSet { Id = id });
                    
        return NoContent();
    }
}
