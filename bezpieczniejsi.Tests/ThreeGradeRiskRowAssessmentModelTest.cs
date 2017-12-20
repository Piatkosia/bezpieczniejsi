// <copyright file="ThreeGradeRiskRowAssessmentModelTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using bezpieczniejsi;

namespace bezpieczniejsi.Tests
{
    /// <summary>This class contains parameterized unit tests for ThreeGradeRiskRowAssessmentModel</summary>
    [PexClass(typeof(ThreeGradeRiskRowAssessmentModel))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    public partial class ThreeGradeRiskRowAssessmentModelTest
    {
    }
}
