using ProjectS360.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.CORE.Mapping
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        #region Constructor
        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Status).HasColumnName("Status").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedADUserName).HasColumnName("CreatedADUserName").IsOptional();
            Property(x => x.CreatedBy).HasColumnName("CreatedBy").IsOptional();
            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").IsOptional();
            Property(x => x.CreatedIP).HasColumnName("CreatedIP").IsOptional();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedADUserName).HasColumnName("ModifiedADUserName").IsOptional();
            Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").IsOptional();
            Property(x => x.ModifiedComputerName).HasColumnName("ModifiedComputerName").IsOptional();
            Property(x => x.ModifiedIP).HasColumnName("ModifiedIP").IsOptional();
        } 
        #endregion
    }
}
