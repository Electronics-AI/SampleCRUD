using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task5_CRUD.Domain;
using Task5_CRUD.Domain.Interfaces;
using Task5_CRUD.Models.Hole;

namespace Task5_CRUD.Controllers;

[ApiController]
[Route("holes/")]
public class HoleController : Controller
{
    private readonly IHoleRepository _holeRepository;
    private readonly IMapper _mapper;

    public HoleController(
        IHoleRepository holeRepository,
        IMapper mapper
        )
    {
        _holeRepository = holeRepository ??
            throw new ArgumentNullException(nameof(holeRepository));

        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> AddHoleAsync(
        [FromBody] AddHoleRequestDto addHoleRequestDto
        )
    {               
        Hole hole = _mapper.Map<Hole>(addHoleRequestDto);
        
        await _holeRepository.AddAsync(hole);
        
        return NoContent();

    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<GetHoleResponseDto>))]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<GetHoleResponseDto>> GetHoleAsync(
        [FromRoute] int id
        )
    {   
        Hole hole = await _holeRepository.GetByIdAsync(id);

        var getHoleResponseDto = _mapper.Map<GetHoleResponseDto>(hole);

        return Ok(getHoleResponseDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> UpdateHoleAsync(
        [FromRoute] int id,
        [FromBody] UpdateHoleRequestDto updateHoleRequestDto
    )
    {  
        Hole updatedHole = _mapper.Map<Hole>(updateHoleRequestDto);
        updatedHole.Id = id;

        await _holeRepository.UpdateAsync(updatedHole);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteHoleAsync(
        [FromRoute] int id
    )
    {
        await _holeRepository.RemoveAsync(new Hole { Id = id });
                    
        return NoContent();
    }
}