using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.Mappings
{
    internal class BankMap : EntityTypeConfiguration<BankEntity>
    {
        public BankMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable($"{tableName}");

            Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_BankName", 1) { IsUnique = true }))
                ;

            Property(e => e.Closed)
                .HasColumnType("date")
                ;
        }
    }
}