﻿using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Business.Transaction.Entities
{
    public class TransactionType
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public TransactionType()
        {
        }

        [SetsRequiredMembers]
        public TransactionType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}