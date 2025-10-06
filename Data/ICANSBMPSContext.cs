using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Models;

public partial class ICANSBMPSContext : DbContext
{
    public ICANSBMPSContext()
    {
    }

    public ICANSBMPSContext(DbContextOptions<ICANSBMPSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EntityHistoryTracking> EntityHistoryTrackings { get; set; }
    public virtual DbSet<EntityHistoryTrackingView> EntityHistoryTrackingViews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityHistoryTracking>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EntityHistoryTracking");

            entity.Property(e => e.Etc).HasColumnName("ETC");
            entity.Property(e => e.ImportDate).HasColumnType("datetime");
            entity.Property(e => e.ImportEntityNumber).HasMaxLength(255);
            entity.Property(e => e.Fec).HasColumnName("FEC");
        });

        modelBuilder.Entity<EntityHistoryTrackingView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EntityHistoryTrackingView");

            entity.Property(e => e.ReceiverName).HasMaxLength(255);
            entity.Property(e => e.EntityTypeCode).HasColumnName("EntityTypeCode");
            entity.Property(e => e.EntityCode).HasColumnName("EntityCode");
            entity.Property(e => e.ReceiveDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}