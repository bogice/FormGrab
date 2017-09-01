using NUnit.Framework;

namespace WFDUnitTest
{
    [TestFixture]
    public class WDFFormTest
    {
        [TestCase("ha", "ha")]
        public void Is_Retrieval_Files_From_WebServer_Folder_Every30Sec(string input, string expected)
        {

            Assert.AreEqual(input, expected);
        }

        [TestCase]
        public void Is_Not_Retrive_File_During_Backup_Time()
        {
        }

        [TestCase]
        public void Is_Trigger_Form_Proc_When_There_Is_File_On_Destination_Dir() { }
    }
}

