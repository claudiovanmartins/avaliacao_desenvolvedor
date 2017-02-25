namespace Avaliacao.WorkinHub.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        Cliente = c.String(nullable: false, maxLength: 255),
                        Descricao = c.String(nullable: false, maxLength: 255),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        Endereco = c.String(maxLength: 255),
                        Fornecedor = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.PedidoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedido");
        }
    }
}
