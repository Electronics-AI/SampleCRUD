using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task5_CRUD.Domain;
using Task5_CRUD.Domain.Interfaces;
using Task5_CRUD.Models.HolePointSet;

namespace Task5_CRUD.Controllers;

[ApiController]
[Route("holePointSets/")]
public class HolePointSetController : Controller
{
    private readonly IHolePointSetRepository _holePointSetRepository;
    private readonly IMapper _mapper;

    public HolePointSetController(
        IHolePointSetRepository holePointSetRepository,
        IMapper mapper
        )
    {
        _holePointSetRepository = holePointSetRepository ??
            throw new ArgumentNullException(nameof(holePointSetRepository));

        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AddHolePointSetAsync(
        [FromBody] AddHolePointSetRequestDto addHolePointSetRequestDto
        )
    {               
        HolePointSet holePointSet = _mapper.Map<HolePointSet>(addHolePointSetRequestDto);
        
        await _holePointSetRepository.AddAsync(holePointSet);
        
        return NoContent();
        
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<GetHolePointSetResponseDto>))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetHolePointSetResponseDto>> GetHolePointSetAsync(
        [FromRoute] int id
        )
    {   
        HolePointSet holePointSet = await _holePointSetRepository.GetByIdAsync(id);

        var getHolePointSetResponseDto = _mapper.Map<GetHolePointSetResponseDto>(holePointSet);

        return Ok(getHolePointSetResponseDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdateHolePointSetAsync(
        [FromRoute] int id,
        [FromBody] UpdateHolePointSetRequestDto updateHolePointSetRequestDto
    )
    {  
        HolePointSet updatedHolePointSet = _mapper.Map<HolePointSet>(updateHolePointSetRequestDto);
        updatedHolePointSet.Id = id;

        await _holePointSetRepository.UpdateAsync(updatedHolePointSet);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteHolePointSetAsync(
        [FromRoute] int id
    )
    {
        await _holePointSetRepository.RemoveAsync(new HolePointSet { Id = id });
                    
        return NoContent();
    }
}