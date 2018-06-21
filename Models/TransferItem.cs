using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExampleTransferApi.Models
{
    public class TransferItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string OriginalBlock { get; set; }
        [Required]
        public string TransferredBlocks { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TransferType TransferType { get; set; }
    }

    public class TransfersWrapper
    {
        public List<TransferItem> Transfers { get; set; }

        public TransfersWrapper(List<TransferItem> transfers)
        {
            Transfers = transfers;
        }
    }
}