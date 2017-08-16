using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ComLog.Db.Entities;

namespace ComLog.Db.MsSql.Mappings
{
    public class AccountTypeMap : EntityTypeConfiguration<AccountTypeEntity>
    {
        public AccountTypeMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable($"{tableName}");

            Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_AccountTypeName", 1) {IsUnique = true}))
                ;

        }

    }
}