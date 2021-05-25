using Microsoft.EntityFrameworkCore.Migrations;

namespace Twitter.Model.Migrations
{
    public partial class enumAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retweets_HashTags_TagID",
                table: "Retweets");

            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "Retweets",
                newName: "HashTagID");

            migrationBuilder.RenameIndex(
                name: "IX_Retweets_TagID",
                table: "Retweets",
                newName: "IX_Retweets_HashTagID");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Tweets",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Retweets_HashTags_HashTagID",
                table: "Retweets",
                column: "HashTagID",
                principalTable: "HashTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retweets_HashTags_HashTagID",
                table: "Retweets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tweets");

            migrationBuilder.RenameColumn(
                name: "HashTagID",
                table: "Retweets",
                newName: "TagID");

            migrationBuilder.RenameIndex(
                name: "IX_Retweets_HashTagID",
                table: "Retweets",
                newName: "IX_Retweets_TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Retweets_HashTags_TagID",
                table: "Retweets",
                column: "TagID",
                principalTable: "HashTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
