using System;
using System.Collections.Generic;
using ExampleTransferApi.Models;

namespace ExampleTransferApi.DataInit
{
    public static class TransferItemsData
    {
        public static IEnumerable<TransferItem> GetData()
        {
            var listToInsert = new List<TransferItem>();
            for (var i = 1; i <= 50; i++)
            {
                listToInsert.Add(new TransferItem()
                {
                    OriginalBlock = $"{GetRandomIpAddress()}/1{i}",
                    TransferredBlocks = GetTransferBlocks(i),
                    Date = DateTime.Now,
                    From = $"From Company {i}",
                    To = $"To Company {i}",
                    TransferType = GetTransferType(i)
                });
            }

            return listToInsert;
        }
        
        private static TransferType GetTransferType(int i)
        {
            return i % 2 == 0 ? TransferType.Policy : TransferType.MergerOrAcquisition;
        }

        private static string GetTransferBlocks(int i)
        {
            return i % 2 == 0 ? $"{GetRandomIpAddress()}/2{i}, {GetRandomIpAddress()}/3{i}" : $"{GetRandomIpAddress()}/4{i}";
        }
        
        private static string GetRandomIpAddress()
        {
            var random = new Random();
            return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        }
    }
}