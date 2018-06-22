using System;
using System.Collections.Generic;
using System.Linq;
using ExampleTransferApi.Models;

namespace ExampleTransferApi.DataInit
{
    public static class TransferItemsData
    {
        public static IEnumerable<TransferItem> GetData()
        {
            return Enumerable.Range(1, 100).Select(i => new TransferItem()
            {
                IpBlock = $"{GetRandomIpAddress()}/1{i}",
                Date = DateTime.Now,
                From = $"From Company {i}",
                To = $"To Company {i}",
                TransferType = GetTransferType(i)
            });
        }
        
        public static string GetListOfIps(int i)
        {
            return i % 2 == 0 ? $"{GetRandomIpAddress()}/2{i}" : $"{GetRandomIpAddress()}/4{i}";
        }
        
        private static TransferType GetTransferType(int i)
        {
            return i % 2 == 0 ? TransferType.Policy : TransferType.MergerOrAcquisition;
        }
        
        private static string GetRandomIpAddress()
        {
            var random = new Random();
            return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        }
    }
}