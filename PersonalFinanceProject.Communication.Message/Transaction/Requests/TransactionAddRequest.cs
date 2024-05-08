﻿using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.Transaction.Requests
{
    public record TransactionAddRequest
    {
        public required string Name { get; set; }

        public required double Amount { get; set; }

        public required int CategoryId { get; set; }

        public required int TypeId { get; set; }

        public required Guid SourceId { get; set; }

        public required DateTime CreateDate { get; set; }

        public required DateTime UpdateDate { get; set; }

        [SetsRequiredMembers]
        public TransactionAddRequest(string name, double amount, int categoryId, int typeId, Guid sourceId, DateTime createDate, DateTime updateDate)
        {
            Name = name;
            Amount = amount;
            CategoryId = categoryId;
            TypeId = typeId;
            SourceId = sourceId;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
    }
}