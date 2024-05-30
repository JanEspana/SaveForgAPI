using Microsoft.AspNetCore.Mvc;
using FrogGameAPI.Data;
using FrogGameAPI.Models;
using FrogGameAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace FrogGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDTO _response;

        public ScoreController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDTO();
        }

        [HttpGet("GetScores")]
        public ResponseDTO GetScores()
        {
            try
            {
                IEnumerable<Score> scores = _context.Scores.ToList();
                _response.Data = scores;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetScoreById/{id}")]
        public ResponseDTO GetScoreById(int id)
        {
            try
            {
                Score score = _context.Scores.FirstOrDefault(x => x.Id == id);
                _response.Data = score;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet("GetScoresByCharacter/{name}")]
        public ResponseDTO GetScoresByCharacter(string name)
        {
            try
            {
                IEnumerable<Score> scores = _context.Scores.Where(x => x.Character == name).ToList();
                _response.Data = scores;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost("PostScore")]
        public ResponseDTO AddScore(Score score)
        {
            try
            {
                _context.Scores.Add(score);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteScore/{id}")]
        public ResponseDTO DeleteScore(int id)
        {
            try
            {
                Score score = _context.Scores.FirstOrDefault(x => x.Id == id);
                _context.Scores.Remove(score);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
