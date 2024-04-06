using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceProject.Business.Transactions.Migrations
{
    /// <inheritdoc />
    public partial class RenameTransactionCategoriesTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_transactions",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactionTypes",
                table: "transactionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactionCategories",
                table: "transactionCategories");

            migrationBuilder.RenameTable(
                name: "transactions",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "transactionTypes",
                newName: "TransactionTypes");

            migrationBuilder.RenameTable(
                name: "transactionCategories",
                newName: "TransactionCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTypes",
                table: "TransactionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionCategories",
                table: "TransactionCategories");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "transactions");

            migrationBuilder.RenameTable(
                name: "TransactionTypes",
                newName: "transactionTypes");

            migrationBuilder.RenameTable(
                name: "TransactionCategories",
                newName: "transactionCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactions",
                table: "transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactionTypes",
                table: "transactionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactionCategories",
                table: "transactionCategories",
                column: "Id");
        }
    }
}
