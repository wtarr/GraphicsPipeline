using CGPipelineClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GPUnitTestClass
{
    
    
    /// <summary>
    ///This is a test class for ClippingTest and is intended
    ///to contain all ClippingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClippingTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


       

        /// <summary>
        /// Test line returns same when points are (0.5, 0.5) (-0.2, 0.87)
        ///</summary>
        [TestMethod()]        
        public void Test_clip_returns_same_line_when_all_points_are_internal()
        {
            Clipping clip = new Clipping();
            Line expected   = new Line(0.5, 0.5, -0.2, 0.87);
            Line linetoClip = new Line(0.5, 0.5, -0.2, 0.87);
            Line clippedline = clip.ClipLine(linetoClip);

            Assert.AreEqual(expected, clippedline);
        }

        /// <summary>
        /// Test line returns new cliped line when points are (2, 2) (0, -1.5)
        ///</summary>
        [TestMethod()]
        public void Test_clip_returns_new_line_when_all_points_require_clipping()
        {
            Clipping clip = new Clipping();
            Line expected = new Line(1, 0.25, 0.2857, -1);
            Line linetoClip = new Line(2, 2, 0, -1.5);
            Line clippedline = clip.ClipLine(linetoClip);
            Assert.AreEqual(expected, clippedline);
        }

        /// <summary>
        /// Test line returns new cliped line when points are (1.1, 2) (-2, -1.2)
        ///</summary>
        [TestMethod()]
        public void Test_clip_returns_new_line_when_points_require_clipping()
        {
            Clipping clip = new Clipping();
            Line expected = new Line(0.131, 1, -1, -0.167);
            Line linetoClip = new Line(1.1, 2, -2, -1.2);
            Line clippedline = clip.ClipLine(linetoClip);
            Assert.AreEqual(expected, clippedline);
        }

        /// <summary>
        /// Test line returns new cliped line when points are (2, 0.3) (-2, -1.2)
        ///</summary>
        [TestMethod()]
        public void Test_clip_RandomData1()
        {
            Clipping clip = new Clipping();
            Line expected = new Line(0.2, 0.3, 1, 0.8455);
            Line linetoClip = new Line(0.2, 0.3, -2, -1.2);
            Line clippedline = clip.ClipLine(linetoClip);
            Assert.AreEqual(expected, clippedline);
        }

        /// <summary>
        /// Test line returns new cliped line when points are (-2, 0.3) (2, 0.3)
        ///</summary>
        [TestMethod()]
        public void Test_clip_RandomData2()
        {
            Clipping clip = new Clipping();
            Line expected = new Line(-1, 0.3, 1, 0.3);
            Line linetoClip = new Line(-2, 0.3, 2, 0.3);
            Line clippedline = clip.ClipLine(linetoClip);
            Assert.AreEqual(expected, clippedline);
        }

        /// <summary>
        /// Test line returns new cliped line when points are (-1, 0.3) (1, 0.3)
        ///</summary>
        [TestMethod()]
        public void Test_clip_RandomData3()
        {
            Clipping clip = new Clipping();
            Line expected = new Line(-1, 0.3, 1, 0.3);
            Line linetoClip = new Line(-2, 0.3, 2, 0.3);
            Line clippedline = clip.ClipLine(linetoClip);
            Assert.AreEqual(expected, clippedline);
        }

        /// <summary>
        /// Test line returns NULL when points are (2, 0.5) (0.5, 1.3)
        ///</summary>
        [TestMethod()]
        public void Test_clip_RandomData4()
        {
            Clipping clip = new Clipping();
            Line expected = null;
            Line linetoClip = new Line(2, 0.5, 0.5, 1.3);
            Line clippedline = clip.ClipLine(linetoClip);
            Assert.AreEqual(expected, null);
        }
    }
}
