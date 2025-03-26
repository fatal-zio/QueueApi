using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QueueApi.Entities;
using QueueApi.Models;
using QueueApi.Services;

namespace QueueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController(IQueueRepository queueRepository, IMapper mapper) : ControllerBase
    {
        private readonly IQueueRepository _queueRepository = queueRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = await _queueRepository.GetStatusesAsync();
            return Ok(_mapper.Map<IEnumerable<StatusDto>>(statuses));
        }

        [HttpGet("{statusId}")]
        public async Task<IActionResult> GetStatus(int statusId)
        {
            var status = await _queueRepository.GetStatusAsync(statusId);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StatusDto>(status));
        }

        [HttpPut("{statusId}")]
        public async Task<IActionResult> UpdateStatus(int statusId, StatusForUpdateDto statusForUpdateDto)
        {
            var status = await _queueRepository.GetStatusAsync(statusId);

            if (status == null)
            {
                return NotFound();
            }

            _mapper.Map(statusForUpdateDto, status);
            await _queueRepository.SaveAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatus(StatusForCreationDto statusForCreationDto)
        {
            var status = _mapper.Map<Status>(statusForCreationDto);
            await _queueRepository.AddStatusAsync(status);
            await _queueRepository.SaveAsync();
            var statusToReturn = _mapper.Map<StatusDto>(status);
            return CreatedAtRoute("GetStatus", new { statusId = statusToReturn.Id }, statusToReturn);
        }

        [HttpDelete("{statusId}")]
        public async Task<IActionResult> DeleteStatus(int statusId)
        {
            var status = await _queueRepository.GetStatusAsync(statusId);

            if (status == null)
            {
                return NotFound();
            }

            _queueRepository.DeleteStatus(status);
            await _queueRepository.SaveAsync();
            return NoContent();
        }
    }
}
