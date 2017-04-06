using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bookingUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CodedUIRegistrationTest()
        {
            //Perform automated test
            this.UIMap.RecordedMethodUpdate();

            string rtxt = UIMap.UIUpdateSessionWindow.UITxtsessionIDWindow.label5.Text;

            this.UIMap.RecordedMethodSubmit();

            //Validation that the data is there
            Verify verify = new Verify();
            bool i = verify.getSessionAvailability(rtxt, rbox, rbutt);
            if (i == false)
            {
                Assert.Fail();
            }
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

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
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
