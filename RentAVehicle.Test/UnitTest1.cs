using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.Test
{
    [TestClass]
    public class UnitTest1
    {
        //test
        [TestMethod]
        public void TestMethod1()
        {
            var clientManager = new ClientManager();

            clientManager.AddClient(new BL.DTO.ClientDTO { FirstName = "test" });

        }
    }
}
