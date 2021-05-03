﻿using BasketBall.Server.Data;
using BasketBall.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketBall.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //this controller is in ..../api/games
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GamesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        //Bellow I am creating an endpoint that is responding to HttpPost
        public async Task<ActionResult> Post(Game game)
        {
            _dbContext.Add(game);
            await _dbContext.SaveChangesAsync();
            return Ok(); //just to signify that it was created
        }
        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await _dbContext.Games.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int gameId)
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(x => x.GameId == gameId);
            if(game == null)
            {
                return NotFound();
            }
            else
            {
                return game;
            }
        }
        [HttpPut]
        public async Task<ActionResult>Put(Game game)
        {
            _dbContext.Attach(game).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
