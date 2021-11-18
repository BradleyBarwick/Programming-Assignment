using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Programming_Assignment.TestProject
{
    [TestClass]
    public class UnitTest1



    {
        [TestMethod]
        public void DrawRectangleMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Parser.ParseCommand("rect 50,50"));
        }
        [TestMethod]
        public void DrawRectangleMissingParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("rect 50"));
        }
        [TestMethod]
        public void DrawRectangleInvalidParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("rect 50,x"));
        }
        //test to see if the rectangle functions work correctly


        [TestMethod]
        public void DrawCircleMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Parser.ParseCommand("circle 50"));
        }
        [TestMethod]
        public void DrawCircleMissingParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("circle"));
        }
        [TestMethod]
        public void DrawCircleInvalidParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("circle x"));
        }

        //test to see if the circle functions work correctly

        [TestMethod]
        public void DrawTriangleMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Parser.ParseCommand("triangle 50,50,50"));
        }
        [TestMethod]
        public void DrawTriangleMissingParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("triangle 50"));
        }
        [TestMethod]
        public void DrawTriangleInvalidParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("triangle 50,50,x"));
        }

        //test to see if the triangle functions work correctly

        [TestMethod]
        public void MoveToMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Parser.ParseCommand("moveto 50,50"));
        }
        [TestMethod]
        public void MoveToMissingParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("moveto 50"));
        }
        [TestMethod]
        public void MoveToInvalidParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("moveto 50,x"));
        }

        //test to see if the moveto functions work correctly

        [TestMethod]
        public void SetPenColourMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Parser.ParseCommand("pen blue"));
        }
        [TestMethod]
        public void SetPenColourMissingParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("pen"));
        }
        [TestMethod]
        public void SetPenColourInvalidParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("pen colours"));
        }

        //test to see if the pen colour functions work correctly

        [TestMethod]
        public void FillMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Parser.ParseCommand("fill 1"));
        }
        [TestMethod]
        public void FillMissingParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("fill"));
        }


        //test to see if the fill functions work correctly

        [TestMethod]
        public void DrawToMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Parser.ParseCommand("drawto 50,50"));
        }
        [TestMethod]
        public void DrawToMissingParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("drawto 50"));
        }
        [TestMethod]
        public void DrawToInvalidParameterMethod()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Parser.ParseCommand("drawto 50,x"));

        }

        //test to see if the drawto functions work correctly
        [TestMethod]
        public void TestScript()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsTrue(form1.Script.ParseCommand("rect 50,50\r\ncircle 50\r\n"));

        }


        [TestMethod]
        public void variablescriptinput()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Script.ParseCommand("x=5\r\nrect 50,x\r\n"));

        }


        [TestMethod]
        public void whilescriptinput()
        {
            Programming_Assignment.Form1 form1 = new Form1();
            Assert.IsFalse(form1.Script.ParseCommand("x=0\r\nwhile x<5\r\nx++\r\n"));

        }
    }
}