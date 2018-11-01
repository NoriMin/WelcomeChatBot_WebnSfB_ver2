using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Bot.Builder.Dialogs;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            test1();

        }
        public async void test1()
        {
            var target = new WelcomeChatBot_WebnSfB_ver2.Dialogs.RootDialog();

            var context = new Mock<IDialogContext>();

            await target.StartAsync(context.Object);

            //System.Diagnostics.Trace.WriteLine(context.Object.ToString());

            System.Console.WriteLine(context.Object.ToString());
        }
    }

}
