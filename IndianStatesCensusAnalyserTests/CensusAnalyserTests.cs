using IndianStateCensusProblem;
using IndianStateCensusProblem.DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static IndianStateCensusProblem.CensusAnalyser;

namespace IndianStatesCensusAnalyserTests
{
    class CensusAnalyserTests
    {
        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\WrongIndiaStateCode.csv";

        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\USCsvFiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\USCsvFiles\USData.csv";
        static string wrongUSCensusFileType = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\USCsvFiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\USCsvFiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"C:\Users\Mayank\source\repos\IndianStatesCensusAnalyser\CSV Files\USCsvFiles\DelimiterUSCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
    }
}
