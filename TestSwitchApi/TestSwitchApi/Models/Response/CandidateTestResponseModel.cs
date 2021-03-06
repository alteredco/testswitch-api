﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Guid { get; set; }
        public IEnumerable<CandidateTestSummary> TestSubmissions { get; set; }

        public CandidateTestResponseModel(IEnumerable<CandidateTestModel> candidateTests, CandidateDataModel candidate)
        {
            TestSubmissions = candidateTests.Select(candidateTest => new CandidateTestSummary(candidateTest));
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
            Guid = candidate.Guid;
        }
    }
}