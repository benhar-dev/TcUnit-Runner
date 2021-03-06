﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcUnit.TcUnit_Runner
{
    class TcUnitTestResult : IEnumerable<TcUnitTestResult.TestSuiteResult>, IEnumerable
    {
        /* General test results */
        protected uint _numberOfTestSuites;
        protected uint _numberOfTestCases;
        protected uint _numberOfSuccessfulTestCases;
        protected uint _numberOfFailedTestCases;

        /* Test results for each individiual test suite */
        protected List<TestSuiteResult> _testSuiteResults = new List<TestSuiteResult>();

        public enum AssertionType
        {
            UNDEFINED = 0,
            ANY,

            /* Primitive types */
            BOOL,
            BYTE,
            DATE,
            DATE_AND_TIME,
            DINT,
            DWORD,
            INT,
            LINT,
            LREAL,
            LTIME,
            LWORD,
            REAL,
            SINT,
            STRING,
            TIME,
            TIME_OF_DAY,
            UDINT,
            UINT,
            ULINT,
            USINT,
            WORD,
    
            /* Array types */
            Array2D_LREAL,
            Array2D_REAL,
            Array3D_LREAL,
            Array3D_REAL,
            Array_BOOL,
            Array_BYTE,
            Array_DINT,
            Array_DWORD,
            Array_INT,
            Array_LINT,
            Array_LREAL,
            Array_LWORD,
            Array_REAL,
            Array_SINT,
            Array_UDINT,
            Array_UINT,
            Array_ULINT,
            Array_USINT,
            Array_WORD
        }

        public struct TestCaseResult
        {
            public string TestName;
            public string TestClassName;
            public string TestStatus;
            public string FailureMessage;
            public string AssertType;
            public uint NumberOfAsserts;
            public TestCaseResult(string testName, string testClassName, string testStatus, string failureMessage, string assertType, uint numberOfAsserts)
            {
                TestName = testName;
                TestClassName = testClassName;
                TestStatus = testStatus;
                FailureMessage = failureMessage;
                AssertType = assertType;
                NumberOfAsserts = numberOfAsserts;
            }
        }

        public struct TestSuiteResult
        {
            public string Name;
            public uint Identity;
            public uint NumberOfTests;
            public uint NumberOfFailedTests;
            public List<TestCaseResult> TestCaseResults;

            public TestSuiteResult(string name, uint identity, uint numberOfTests, uint numberOfFailedTests)
            {
                Name = name;
                Identity = identity;
                NumberOfTests = numberOfTests;
                NumberOfFailedTests = numberOfFailedTests;
                TestCaseResults = new List<TestCaseResult>();
            }
        }

        public void AddNewTestSuiteResult(TestSuiteResult testsuiteResult)
        {
            _testSuiteResults.Add(testsuiteResult);
        }

        public void AddGeneralTestResults(uint numberOfTestSuites, uint numberOfTestCases, uint numberOfSuccessfulTestCases, uint numberOfFailedTestCases)
        {
            _numberOfTestSuites = numberOfTestSuites;
            _numberOfTestCases = numberOfTestCases;
            _numberOfSuccessfulTestCases = numberOfSuccessfulTestCases;
            _numberOfFailedTestCases = numberOfFailedTestCases;
        }
        
        IEnumerator<TestSuiteResult> IEnumerable<TestSuiteResult>.GetEnumerator()
        {
            return _testSuiteResults.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _testSuiteResults.GetEnumerator();
        }

        public uint GetNumberOfTestSuites()
        {
            return _numberOfTestSuites;
        }

        public uint GetNumberOfTestCases()
        {
            return _numberOfTestCases;
        }
        
        public uint GetNumberOfSuccessfulTestCases()
        {
            return _numberOfSuccessfulTestCases;
        }
        
        public uint GetNumberOfFailedTestCases()
        {
            return _numberOfFailedTestCases;
        }
    }
}
