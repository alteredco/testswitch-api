﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;
using TestSwitchApi.Repositories;
using TestSwitchApi.Services;

namespace TestSwitchApi.Controllers
{
    [ApiController]
    [Route("/candidates")]
    public class CandidateController : Controller
    {
        private readonly ICandidatesRepo _candidates;

        public CandidateController(ICandidatesRepo candidates)
        {
            _candidates = candidates;
        }

        [HttpGet("")]
        public ActionResult<CandidateListResponse> GetCandidates([FromQuery] PageRequest pageRequest)
        {
            var candidates = _candidates.GetAllCandidates(pageRequest);
            var candidateCount = _candidates.Count(pageRequest);
            return CandidateListResponse.Create(pageRequest, candidates, candidateCount);
        }

        [HttpPost("create")]
        public ActionResult<CandidateDataModel> RegisterCandidate([FromForm] CandidateRequest candidateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCandidate = _candidates.Register(candidateRequest);
            return newCandidate;
        }
    }
}